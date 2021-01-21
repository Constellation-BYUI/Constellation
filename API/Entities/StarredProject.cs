using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class StarredProject
    {
        public int StarredProjectID { get; set; }
        public int UserID { get; set; }
        public  AppUser User { get; set; }
        public int ProjectID { get; set; }
        public  Project Project { get; set; }
    }
}
