using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.OTP.Sms;
using Innoplatform.Service.DTOs.Registrations;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Extensions;
using Innoplatform.Service.Interfaces.IOTPServices;
using Innoplatform.Service.Interfaces.IUserServices;
using Microsoft.Extensions.Caching.Memory;
using Innoplatform.Service.DTOs.Organizations;
using Innoplatform.Service.DTOs.Registrations.OrganizationRegistrations;
using Innoplatform.Service.Interfaces.IOrganizationServices;
using Microsoft.EntityFrameworkCore;
using Innoplatform.Service.Interfaces.IRegistrationServices;

namespace Innoplatform.Service.Services.RegistrationServices
{
    public class OrganizationRegistrationService : IOrganizationRegistrationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ISmsService _smsService;
        private readonly IUserService _userService;
        private readonly IOrganizationService _organizationService;


        public OrganizationRegistrationService(IRepository<User> userRepository, IMapper mapper, IMemoryCache cache, ISmsService smsService, IUserService userService, IRepository<Organization> organizationRepository, IOrganizationService organizationService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _cache = cache;
            _smsService = smsService;
            _userService = userService;
            _organizationRepository = organizationRepository;
            _organizationService = organizationService;
        }

        public async Task<OrganizationRegistrationForResultDto> AddAsync(OrganizationRegistrationForCreationDto dto)
        {
            var CheckUser = await this._userRepository.SelectAll().Where(e => e.PhoneNumber == dto.PhoneNumber || e.Email == dto.Email && e.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if (CheckUser != null)
            {
                throw new InnoplatformException(400, "This User is exist");
            }
            var CheckOrganization = await this._organizationRepository.SelectAll().Where(e => e.PhoneNumber == dto.PhoneNumber || e.Email == dto.Email && e.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if (CheckOrganization != null)
            {
                throw new InnoplatformException(400, "This User is exist");
            }

            if (dto.VerificationCode == null)
            {
                throw new InnoplatformException(400, "Invalid Verifaction code");
            }
            if (CheckUser == null)
            {
                var PhoneVerification = new CodeVerification()
                {
                    PhoneNumber = dto.PhoneNumber,
                    VerificationCode = dto.VerificationCode,
                };

                var IsVerified = await VerifyCodeAsync(PhoneVerification);
                if (IsVerified == true)
                {
                    _cache.Remove($"{dto.PhoneNumber}_VerificationCode");
                    var HashedPassword = PasswordHelper.Hash(dto.Password);
                    var NewOrganization = this._mapper.Map<OrganizationForCreationDto>(dto);
                    NewOrganization.ImagePath = null;
                    var Result = await this._organizationService.AddAsync(NewOrganization);
                    return this._mapper.Map<OrganizationRegistrationForResultDto>(Result);
                }
                else
                {
                    throw new InnoplatformException(400, "Verification code is not verified");
                }

            }

            throw new InnoplatformException(400, "This User is Exist");



        }

        public async Task<string> SendVerificationCodeAsync(SendVerificationCode dto)
        {
            var existingUser = await this._userRepository
                            .SelectAll()
                            .Where(e => e.PhoneNumber == dto.PhoneNumber && e.IsDeleted == false)
                            .FirstOrDefaultAsync();
            var CheckOrganization = await this._organizationRepository.SelectAll().Where(e => e.PhoneNumber == dto.PhoneNumber && e.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if (CheckOrganization != null)
            {
                throw new InnoplatformException(400, "This User is exist");
            }

            if (existingUser == null)
            {
                var verificationCode = GenerateCodeForPhoneNumberVerificationAsync();
                var cacheKey = $"{dto.PhoneNumber}_VerificationCode";
                var cacheExpiration = TimeSpan.FromSeconds(30000); // Set expiration time to 2 minutes

                try
                {
                    // Store the verification code in the cache with a 2-minute expiration
                    _cache.Set(cacheKey, verificationCode, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = cacheExpiration
                    });

                    // Send the verification code to the user via email
                    var message = new Message()
                    {
                        PhoneNumber = dto.PhoneNumber,
                        MessageContent = $"Innoplatform tasdiqlash kodingiz: {verificationCode}"
                    };

                    await _smsService.SendAsync(message);

                    return verificationCode;
                }
                catch (Exception ex)
                {
                    // Handle exceptions related to cache or email sending
                    // Log the exception or provide a more meaningful error message
                    throw new InnoplatformException(500, "Error occurred while sending verification code.");
                }
            }
            else
            {
                throw new InnoplatformException(400, "This user already exists.");
            }


        }
        public async Task<bool> VerifyCodeAsync(CodeVerification dto)
        {
            var storedCode = _cache.Get<string>($"{dto.PhoneNumber}_VerificationCode");

            if (storedCode != null && storedCode == dto.VerificationCode)
            {
                return true;
            }

            return false;
        }


        private string GenerateCodeForPhoneNumberVerificationAsync()
        {
            string code = Guid.NewGuid().ToString("N").Substring(0, 6);
            return code;
        }


    }
}
