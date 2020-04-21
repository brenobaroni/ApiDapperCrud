using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDapperCrud.Connection
{
    public class SqlDbConnection : ISqlDbConnection
    {
        private string connectionString;

        public SqlDbConnection()
        {
            connectionString = @"Data Source=apidappercrud.cyveqhehh7ab.sa-east-1.rds.amazonaws.com,1433;Initial Catalog=ApiDapperCrud;User ID=apiDapperCrudDev;Password=apiDapperCrudDev123456;Connect Timeout=30;Encrypt=False;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
