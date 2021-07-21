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
    public class tbl_Category_Addition_Attribute : tbl_Created_Modified_By
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

    public class tbl_Product_Master:tbl_Created_Modified_Approved_By
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        
    }




}
