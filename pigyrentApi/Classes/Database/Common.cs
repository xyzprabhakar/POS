﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pigyrentApi.Classes.Database
{
    
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

    public class tbl_Created_By: ICreatedBy
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


    public class tbl_Address
    {
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? LocaltyId { get; set; }
        public string Address { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}
