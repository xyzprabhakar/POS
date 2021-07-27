using pigyrentApi.Classes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pigyrentApi.Classes.Database
{
    #region ******************* Created By ****************************
    public interface ICreatedBy
    {
        public ulong CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
    }
    public interface IModifiedBy
    {
        public ulong ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        [NotMapped]
        public string ModifiedByName { get; set; }
    }

    public class tbl_Created_By : ICreatedBy
    {
        public ulong CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
    }
    public class tbl_Modified_By : IModifiedBy
    {
        public ulong ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        [NotMapped]
        public string ModifiedByName { get; set; }
    }

    public class tbl_Created_Modified_By : ICreatedBy, IModifiedBy
    {
        public ulong CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public ulong ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        [NotMapped]
        public string ModifiedByName { get; set; }
    }

    public interface IApprovedBy
    {
        string ApprovalReamrsk { get; set; }
        enmApprovalStatus ApprovalStatus { get; set; }
        ulong ApprovedBy { get; set; }
        string ApprovedByName { get; set; }
        DateTime ApprovedDt { get; set; }
    }

    public class tbl_Approved_By : IApprovedBy
    {
        public enmApprovalStatus ApprovalStatus { get; set; }
        public string ApprovalReamrsk { get; set; }
        public ulong ApprovedBy { get; set; }
        public DateTime ApprovedDt { get; set; }
        [NotMapped]
        public string ApprovedByName { get; set; }
    }
    public class tbl_Created_Modified_Approved_By: ICreatedBy, IModifiedBy, IApprovedBy
    {
        public enmApprovalStatus ApprovalStatus { get; set; }
        public string ApprovalReamrsk { get; set; }
        public ulong ApprovedBy { get; set; }
        public DateTime ApprovedDt { get; set; }
        [NotMapped]
        public string ApprovedByName { get; set; }
        public ulong CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public ulong ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        [NotMapped]
        public string ModifiedByName { get; set; }
    }



    #endregion

    public interface Itbl_Address
    {
        string Address { get; set; }
        int? CountryId { get; set; }
        string latitude { get; set; }
        int? LocaltyId { get; set; }
        string longitude { get; set; }
        int? StateId { get; set; }
    }
    public class tbl_Address : Itbl_Address
    {
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? LocaltyId { get; set; }
        public string Address { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}
