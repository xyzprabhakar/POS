using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pigyrentApi.Classes.Enums
{
    public enum enmRole
    {
        User=1,
        Broker=2
    }
    public enum enmGender
    {
        Male=1,
        Female=2,
        Other=3
    }
    public enum enmDataType
    { 
        Numeric,
        Text,
        Decimal,
        DateTime
    }
    public enum enmApprovalStatus
    {
        Pending=0,
        Approve=1,
        Rejected=2,
        InProcess=3
    }
    public enum enmProductStatus
    {

        Active=1,
        Hold=2,
        Booked=3,
        Release=4,
        Deactive = 5,

    }
}
