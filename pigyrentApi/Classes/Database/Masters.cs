using pigyrentApi.Classes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pigyrentApi.Classes.Database
{
    #region ************************ Product Category ***********************
    public class tbl_Product_Category: tbl_Created_Modified_By
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string CategoryName { get; set; }
        [ForeignKey("tbl_Product_Parent_Category")]
        public int? ParentCategoryId { get; set; }
        public tbl_Product_Category tbl_Product_Parent_Category { get; set; }        
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }

    public class tbl_Product_Category_Tree 
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Sno{ get; set; }
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public int DepthId { get; set; }
        public bool IsActive { get; set; }
    }

    


    public class tbl_Category_Attribute : tbl_Created_Modified_By
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AttributeId { get; set; }
        [MaxLength(50)]
        public string AttributeName { get; set; }
        public int DisplayOrder { get; set; }
        public enmDataType DataType { get; set; }        
        public bool IsRequired { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string RegularExpression { get; set; }
        public string DefaultValue { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("tbl_Product_Category")]
        public int? CategoryId { get; set; }
        public tbl_Product_Category tbl_Product_Category { get; set; }
    }
    #endregion

    public class tbl_Product_Master:tbl_Created_Modified_Approved_By, Itbl_Address
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public ulong ProductId { get; set; }
        [MaxLength(200)]
        public string ProductName { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        [ForeignKey("tbl_Product_Category")]
        public int? CategoryId { get; set; }
        public tbl_Product_Category tbl_Product_Category { get; set; }
        string Itbl_Address.Address { get; set; }
        int? Itbl_Address.CountryId { get; set; }
        string Itbl_Address.latitude { get; set; }
        int? Itbl_Address.LocaltyId { get; set; }
        string Itbl_Address.longitude { get; set; }
        int? Itbl_Address.StateId { get; set; }         
        public DateTime ValidFromDate { get; set; }
        public DateTime ValidToDate { get; set; }
        public double Price { get; set; }        
        public enmProductStatus ProductStatus { get; set; }
    }

    public class tbl_Product_Details : tbl_Modified_By
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public ulong ProductDetailId { get; set; }
        [ForeignKey("tbl_Product_Master")]
        public ulong? ProductId { get; set; }
        public tbl_Product_Master tbl_Product_Master { get; set; }
        [ForeignKey("tbl_Category_Attribute")]
        public int? AttributeId { get; set; }
        public tbl_Category_Attribute tbl_Category_Attribute { get; set; }
        [MaxLength(2000)]
        public string AttributeValue { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class tbl_Product_Status_Detail : tbl_Modified_By
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StatusDetailId { get; set; }
        [ForeignKey("tbl_Product_Master")]
        public ulong? ProductId { get; set; }
        public tbl_Product_Master tbl_Product_Master { get; set; }
        public enmProductStatus ProductStatus { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
    }

}
