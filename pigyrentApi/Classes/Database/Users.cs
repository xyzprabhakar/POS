using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using pigyrentApi.Classes.Enums;

namespace pigyrentApi.Classes.Database
{
    public class tbl_User_Master : IdentityUser<ulong>
    {

        [ForeignKey("tbl_Broker_Master")]
        public ulong BrokerId { get; set; }
        public tbl_Broker_Master tbl_Broker_Master { get; set; }

    }

    public class tbl_role_master : IdentityRole<ulong>
    { 

    }
    
    public class tbl_Broker_Master
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong BrokerId { get; set; }
        public enmGender Gender { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [ForeignKey("tbl_Broker_Master")]
        public ulong? SponsorBrokerId { get; set; }
        public tbl_Broker_Master tbl_SponsorBroker{ get; set; }
        public DateTime JoiningDt { get; set; }
        public DateTime Dob { get; set; }
        public bool TerminatedDate { get; set; }
        public bool IsTerminated { get; set; }
    }

    public class tbl_Broker_Tree
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Sno { get; set; }
        public ulong BrokerId { get; set; }
        public int? SponsorBrokerId { get; set; }
        public int DepthId { get; set; }
        public bool IsActive { get; set; }
    }



}
