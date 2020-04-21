using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDapperCrud
{
    public interface ISqlDbConnection
    {
        public IDbConnection Connection { get; }
    }
}
