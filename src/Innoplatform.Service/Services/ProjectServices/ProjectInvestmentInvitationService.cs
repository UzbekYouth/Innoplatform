using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.ProjectInvestmentInvitations;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces.IProjectServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.ProjectServices
{
    public class ProjectInvestmentInvitationService : IProjectInvestmentInvitationService
    {
        private readonly IRepository<ProjectInvestmentInvitation> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Project> _projectRepository;

        public ProjectInvestmentInvitationService(IRepository<Project> projectRepository, IRepository<User> userRepository, IMapper mapper, IRepository<ProjectInvestmentInvitation> repository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProjectInvestmentInvitationForResultDto> AddAsync(ProjectInvestmentInvitationForCreationDto dto)
        {
            var CheckUser = await _userRepository.SelectAll()
                .Where(u => u.IsDeleted == false && u.Id == dto.UserId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if(CheckUser is null)
                throw new InnoplatformException(404, "User not found");
            var CheckProject = await _projectRepository.SelectAll()
                .Where(p => p.IsDeleted == false && p.Id == dto.ProjectId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if(CheckProject is null)
                throw new InnoplatformException(404, "Project not found");
            var mappedProjectInvestmentInvitation = _mapper.Map<ProjectInvestmentInvitation>(dto);
            var createdProjectInvestmentInvitation = await _repository.CreateAsync(mappedProjectInvestmentInvitation);
            return _mapper.Map<ProjectInvestmentInvitationForResultDto>(createdProjectInvestmentInvitation);

        }

        public async Task<IEnumerable<ProjectInvestmentInvitationForResultDto>> GetAllAsync()
        {
            var projectInvestmentInvitations = await _repository.SelectAll()
                .Where(p => p.IsDeleted == false)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<IEnumerable<ProjectInvestmentInvitationForResultDto>>(projectInvestmentInvitations);
        }

        public async Task<ProjectInvestmentInvitationForResultDto> GetByIdAsync(long id)
        {
            var Check = await _repository.SelectAll()
                .Where(p => p.IsDeleted == false && p.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if(Check is null)
                throw new InnoplatformException(404, "Project Investment Invitation not found");
            return _mapper.Map<ProjectInvestmentInvitationForResultDto>(Check);
        }

        public async Task<ProjectInvestmentInvitationForResultDto> ModifyAsync(long id, ProjectInvestmentInvitationForUpdateDto dto)
        {
            var Check = await _repository.SelectAll()
                .Where(p => p.IsDeleted == false && p.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if(Check is null)
                throw new InnoplatformException(404, "Project Investment Invitation not found");
            var Mapped = _mapper.Map(dto, Check);
            var Modified = await _repository.UpdateAsync(Mapped);
            return _mapper.Map<ProjectInvestmentInvitationForResultDto>(Modified);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var Check = await _repository.SelectAll()
                .Where(p => p.IsDeleted == false && p.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if(Check is null)
                throw new InnoplatformException(404, "Project Investment Invitation not found");
            return await _repository.DeleteAsync(id);
        }
    }
}
