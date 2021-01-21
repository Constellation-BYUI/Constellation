using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }

        public ICollection<UserLike> LikedByUsers { get; set; }
        public ICollection<UserLike> LikedUsers { get; set; }

        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }

         public  ICollection<IntrestedCandidate> IntrestedCandidates { get; set; }
        public  ICollection<RecruiterPicks> Candidates { get; set; }
        public  ICollection<RecruiterPicks> Recuiter { get; set; }
        public  ICollection<StarredPosting> StarredPostings { get; set; }
        public  ICollection<StarredUser> StarredOwner { get; set; }
        public  ICollection<StarredUser> StarredUsers { get; set; }
        public  ICollection<StarredProject> StarredProjects { get; set; }
        public  ICollection<Posting> Postings { get; set; }
        public  ICollection<ContactLink> ContactLinks { get; set; }
        public  ICollection<UserProject> UserProjects { get; set; }
        public  ICollection<UserSkill> UserSkills { get; set; }

    }
}