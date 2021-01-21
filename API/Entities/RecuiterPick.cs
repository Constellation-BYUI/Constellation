using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 namespace API.Entities
{
    public class RecruiterPicks
    {
        public int RecuiterPicksID { get; set; }

        public string ListTitle { get; set; }

        public int RecuiterID { get; set; }

        public int CandidateID { get; set; }

        public int PostingID { get; set; }

        public  AppUser Recuiter { get; set; }

        public  Posting Posting { get; set; }

        public  AppUser Candidate { get; set; }

    }
}
