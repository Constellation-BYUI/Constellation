using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class IntrestedCandidate
    {
        public int IntrestedCandidateID { get; set; }
        public int UserID { get; set; }
        public AppUser User { get; set; }
        public int PostingID { get; set; }
        public Posting Posting { get; set; }
    }
}
