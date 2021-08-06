using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pigyrentApi.Classes
{
    public enum enmError
    {
        InvalidParentNode
    }

    public class PgError : Exception
    {
        public enmError ErrorCode { get; }
        public override string Message { get; }
        public PgError()
        {
        }
        public PgError(enmError errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}
