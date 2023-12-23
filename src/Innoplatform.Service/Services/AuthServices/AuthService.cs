using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.Login;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Extensions;
using Innoplatform.Service.Interfaces.IAuthServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml;

namespace Innoplatform.Service.Services.AuthServices
{
    // optimiza authrentication
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Organization> _organizationRepository;

        public AuthService(IConfiguration configuration, IRepository<User> userRepository, IRepository<Organization> organizationRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
        }

        public async Task<LoginForResultDto> AuthenticateAsync(LoginForCreationDto dto)
        {
            var user = await _userRepository.SelectAll().Where(x => x.PhoneNumber == dto.PhoneNumber && x.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            
            var organization = await _organizationRepository.SelectAll().Where(x => x.PhoneNumber == dto.PhoneNumber && x.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
            // write other logic here
            if(user != null)
            {
                var hashedPassword = PasswordHelper.Verify(dto.Password, user.Salt, user.Password);
                if(hashedPassword == false)
                {
                    throw new InnoplatformException(400, "PhoneNumber or Password is incorrect");
                }
                return new LoginForResultDto
                {
                    Role = user.Role.ToString(),
                    Token = GenerateToken(user),
                };

            }
            else if(organization != null)
            {
                var hashedPassword = PasswordHelper.Verify(dto.Password, organization.Salt, organization.Password);
                if(hashedPassword == false)
                {
                    throw new InnoplatformException(400, "PhoneNumber or Password is incorrect");
                }   
                return new LoginForResultDto
                {
                    Role = organization.Role.ToString(),
                    Token = GenerateOrganizationToken(organization),
                };
            }
            throw new InnoplatformException(400, "PhoneNumber or Password is incorrect");
     
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString()),  // Use the role passed as an argument
                }),
                Audience = _configuration["JWT:Audience"],
                Issuer = _configuration["JWT:Issuer"],
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JWT:Expire"])),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateOrganizationToken(Organization organization)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", organization.Id.ToString()),
                    new Claim(ClaimTypes.Role, organization.Role.ToString()),  // Use the role passed as an argument
                }),
                Audience = _configuration["JWT:Audience"],
                Issuer = _configuration["JWT:Issuer"],
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JWT:Expire"])),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
