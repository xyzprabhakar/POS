using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pigyrentApi.Classes.Database
{
    
    public interface ICreatedBy
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        [NotMapped]
        public string CreatedByName { get; set; }
    }
    public interface IModifiedBy
    {
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        [NotMapped]
        public string ModifiedByName { get; set; }
    }

    public class tbl_Created_By: ICreatedBy
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        [NotMapped]
        public string CreatedByName { get; set; }
    }
    public class tbl_Modified_By : IModifiedBy
    {
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        [NotMapped]
        public string ModifiedByName { get; set; }
    }

    public class tbl_Created_Modified_By : ICreatedBy, IModifiedBy
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public string ModifiedByName { get; set; }
    }
}
