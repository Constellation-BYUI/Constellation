using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 namespace API.Entities
{
    public class SkillDiscipline
    {
        public int DisciplineID { get; set; }

        public int SkillID { get; set; }

        public  Skill Skills { get; set; }

        public  Discipline Disciplines { get; set; }
    }
}
