using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    //comment to make a new branch possible
    public class UserProject
    {
        public int UserID { get; set; }
        public  AppUser User { get; set; }
        public int ProjectID { get; set; }
        public  Project Project { get; set; }
        public string CollaborationTitle { get; set; }
    }
}