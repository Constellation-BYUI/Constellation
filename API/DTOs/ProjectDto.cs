using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class ProjectDto
    {
        public int ProjectID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string PhotoPath { get; set; }

        public  IEnumerable<ProjectLinkDto> ProjectLinks { get; set; }

        public  IEnumerable<UserProjectDto> UserProjects { get; set; }

        public  IEnumerable<ProjectPostingsDto> ProjectPostings { get; set; }

        public  IEnumerable<ProjectSkillsDto> ProjectSkills { get; set; }

    }
}