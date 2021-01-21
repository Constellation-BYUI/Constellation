using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 namespace API.Entities
{
    public class SkillLink
    {
        public int SkillLinkID { get; set; }

        public string SkillLinkUrl { get; set; }
 
        public string SkilLinkLabel { get; set; }

        public int SkillLinkOwner {get; set; }

        public  ICollection<UserSkillLink> UserSkillLinks { get; set; }



    }
}
