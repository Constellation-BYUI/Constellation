using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class StarredUser
    {
        //Primary Key
        public int StarredUserID { get; set; }

        //User who is being starred Foriegn Key
        public int UserStarredID { get; set; }

        //User who is starring the other person
        public int StarredOwnerID { get; set; }

        //Naviagation Properties
        //user who is starring the other navigation property
        public  AppUser StarOwner { get; set; }
        
        //User who is being starred navigation Property
        public  AppUser StarredPerson { get; set; }
    }
}