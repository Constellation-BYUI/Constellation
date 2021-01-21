using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace API.Entities
{
    public class StarredPosting
    {
        public int StarredPostingID { get; set; }
        public int UserID { get; set; }
        public  AppUser User { get; set; }
        public int PostingID { get; set; }
        public  Posting Posting { get; set; }


    }
}
