using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IProjectRepository
    {
       void Update(Project project);
        Task<IEnumerable<Project>> GetProjectsAsync();


        Task<Project> GetProjectByIdAsync(int id);
        Task<PagedList<ProjectDto>> GetProjectsDtoAsync(UserParams userParams);
        Task<ProjectDto> GetProjectDtoAsync(int projectId);

        Task<IEnumerable<UserProjectDto>> GetAllUserProjectsOfSite();
        Task<IEnumerable<ProjectLinkDto>> GetAllProjectLinksOfSite();
        Task<IEnumerable<ProjectLinkDto>> GetProjectLinksByProjectId(int projectId);
        Task<IEnumerable<ProjectPostingsDto>> GetAllProjectPostingsOfSite();
        Task<IEnumerable<ProjectSkillsDto>> GetAllProjectSkillsOfSite();


    }
}