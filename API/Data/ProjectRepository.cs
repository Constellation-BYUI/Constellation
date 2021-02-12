using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProjectRepository : IProjectRepository
    {

         private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProjectRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Update(Project project)
        {
        _context.Entry(project).State = EntityState.Modified;
        }

           public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
              return await _context.Projects
                .ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
             return await _context.Projects
                .Include(p => p.UserProjects)
                .SingleOrDefaultAsync(x => x.ProjectID == id);
        }
     

        public async Task<PagedList<ProjectDto>> GetProjectsDtoAsync(UserParams userParams)
        {
            var query = _context.Projects.AsQueryable();


            var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
            var maxDob = DateTime.Today.AddYears(-userParams.MinAge);


            query = userParams.OrderBy switch
            {
                "created" => query.OrderByDescending(u => u.CreationDate),
                _ => query.OrderByDescending(u => u.CreationDate)
            };
            
            return await PagedList<ProjectDto>.CreateAsync(query.ProjectTo<ProjectDto>(_mapper
                .ConfigurationProvider).AsNoTracking(), 
                    userParams.PageNumber, userParams.PageSize);

        }

    
        public async Task<ProjectDto> GetProjectDtoAsync(int projectId)
        {
             return await _context.Projects
                .Where(x => x.ProjectID == projectId)
                .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

              public async Task<IEnumerable<UserProjectDto>> GetAllUserProjectsOfSite()
        {
              return await _context.UserProjects
                .ProjectTo<UserProjectDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

         public async Task<IEnumerable<ProjectLinkDto>> GetAllProjectLinksOfSite()
        {
              return await _context.ProjectLinks
                .ProjectTo<ProjectLinkDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectLinkDto>> GetProjectLinksByProjectId(int projectId)
        {
              return await _context.ProjectLinks
                .Where(i => i.Projects.ProjectID == projectId)
                .ProjectTo<ProjectLinkDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectPostingsDto>> GetAllProjectPostingsOfSite()
        {
              return await _context.ProjectLinks
                .ProjectTo<ProjectPostingsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

           public async Task<IEnumerable<ProjectSkillsDto>> GetAllProjectSkillsOfSite()
        {
              return await _context.ProjectSkills
                .ProjectTo<ProjectSkillsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}