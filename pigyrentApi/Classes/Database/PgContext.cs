using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pigyrentApi.Classes.Database
{
    public class PgContext : IdentityDbContext<tbl_User_Master,tbl_role_master,ulong>
    {
        #region ********************Common Masters *******************************   
        public DbSet<tbl_Country_Master> tblTboTokenDetails { get; set; }
        public DbSet<tbl_State_Master> tbl_State_Master { get; set; }
        public DbSet<tbl_District_Master> tbl_District_Master { get; set; }
        public DbSet<tbl_Localty_Master> tbl_Localty_Master { get; set; }
        public DbSet<tbl_Country_Bank> tbl_Country_Bank { get; set; }
        public DbSet<tbl_Bank_Master> tbl_Bank_Master { get; set; }
        public DbSet<tbl_Currency_Master> tbl_Currency_Master { get; set; }
        public DbSet<tbl_Country_Currency> tbl_Country_Currency { get; set; }
        #endregion

        #region ********************User Masters *******************************   
        public DbSet<tbl_User_Master> tbl_User_Master { get; set; }
        #endregion
    }
}
