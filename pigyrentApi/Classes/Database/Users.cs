using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pigyrentApi.Classes.Database
{
    public class tbl_User_Master : IdentityUser
    {
        public bool IsTerminated { get; set; }
        
    }

    public class tbl_User_detail
    {   
        [Key]
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? SponsorId { get; set; }
        public DateTime JoiningDt { get; set; }
        public bool TerminatedDate { get; set; }
        [ForeignKey("tbl_User_Master")]
        public string UserId { get; set; }
        public  tbl_User_Master tbl_User_Master { get; set; }
    }

}
