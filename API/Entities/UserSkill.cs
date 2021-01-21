using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class UserSkill
    {
        public int UserSkillID { get; set; }
        public int SkillID { get; set; }
        public int UserID { get; set; }
        public  ICollection<UserSkillLink> UserSkillLinks { get; set; }
        public  Skill Skills { get; set; }
        public  AppUser Users { get; set; }

    }
}