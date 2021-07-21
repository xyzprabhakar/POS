using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pigyrentApi.Classes.Database
{
    [Index(nameof(CountryCode))]
    public class tbl_Country_Master : tbl_Created_Modified_By
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }
        [MaxLength(3)]
        public string CountryCode { get; set; }
        [MaxLength(2)]
        public string CountryCodeIso2 { get; set; }
        [MaxLength(200)]
        public string CountryName { get; set; }
        [MaxLength(30)]
        public string PhoneCode { get; set; }
        [MaxLength(200)]
        public string Capital { get; set; }
        [MaxLength(100)]
        public string currency { get; set; }
        [MaxLength(100)]
        public string CurrencySymbol { get; set; }
        [MaxLength(100)]
        public string Domain { get; set; }
        [MaxLength(100)]
        public string Native { get; set; }
        [MaxLength(100)]
        public string Region { get; set; }
        [MaxLength(100)]
        public string SubRegion { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(200)]
        public string Remarks { get; set; }
    }    
    public class tbl_State_Master : tbl_Created_Modified_By
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }
        [MaxLength(10)]
        public string StateCode { get; set; }
        [MaxLength(200)]
        public string StateName { get; set; }
        [ForeignKey("tbl_Country_Master")]
        public int? CountryId { get; set; }
        public tbl_Country_Master tbl_Country_Master { get; set; }
        public bool IsUT { get; set; }
        public bool IsActive { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        [NotMapped]
        public virtual string CountryName { get; set; }
    }
    public class tbl_District_Master
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DistrictId { get; set; }
        [MaxLength(10)]
        public string DistrictCode { get; set; }
        [MaxLength(200)]
        public string DistrictName { get; set; }
        [ForeignKey("tbl_State_Master")]
        public int? StateId { get; set; }
        public tbl_State_Master tbl_State_Master { get; set; }
        public bool IsActive { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        [NotMapped]
        public virtual string CountryName { get; set; }
        [NotMapped]
        public virtual string StateName { get; set; }
    }
    public class tbl_Localty_Master
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int LocaltyId { get; set; }
        [MaxLength(10)]
        public string LocaltyCode { get; set; }
        [MaxLength(200)]
        public string LocaltyName { get; set; }
        [ForeignKey("tbl_District_Master")]
        public int? DistrictId { get; set; }
        public tbl_District_Master tbl_District_Master { get; set; }
        [ForeignKey("tbl_State_Master")]
        public int? StateId { get; set; }
        public tbl_State_Master tbl_State_Master { get; set; }
        public bool IsActive { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        [NotMapped]
        public virtual string CountryName { get; set; }
        [NotMapped]
        public virtual string StateName { get; set; }
    }
    public class tblBankMaster
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BankId { get; set; }
        [Required]
        [MaxLength(100)]
        public string BankName { get; set; }
        public bool IsActive { get; set; }
    }

}
