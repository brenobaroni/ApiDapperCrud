using ApiDapperCrud.Connection;
using ApiDapperCrud.Interfaces;
using ApiDapperCrud.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDapperCrud.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ISqlDbConnection _sqlDbConnection;

        public ProductRepository(ISqlDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;
        }


        public void Add(Product product)
        {
            using (_sqlDbConnection.Connection)
            {
                string sQuery = @"INSERT INTO Products (Name, quantity, Price) VALUES(@Name,@Quantity,@Price)";
                _sqlDbConnection.Connection.Open();
                _sqlDbConnection.Connection.Execute(sQuery, product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (_sqlDbConnection.Connection)
            {
                string sQuery = @"SELECT * FROM Products";
                _sqlDbConnection.Connection.Open();
                return _sqlDbConnection.Connection.Query<Product>(sQuery);
            }
        }

        public Product GetById(int id)
        {
            using (_sqlDbConnection.Connection)
            {
                string sQuery = @"SELECT * FROM Products WHERE ProductId = @Id";
                _sqlDbConnection.Connection.Open();
                return _sqlDbConnection.Connection.QueryFirstOrDefault<Product>(sQuery, new { Id = id });
            }
        }

        public void Delete(int id)
        {
            using (_sqlDbConnection.Connection)
            {
                if (id > 0)
                {
                    string sQuery = @"DELETE FROM Products WHERE ProductId = @Id";
                    _sqlDbConnection.Connection.Open();
                    _sqlDbConnection.Connection.Execute(sQuery, new { Id = id });
                }
                else
                {
                    throw new Exception("Invalid Id for Deleting.");
                }
            }
        }

        public void Update(Product product)
        {
            using (_sqlDbConnection.Connection)
            {
                string sQuery = @"UPDATE Products SET Name=@Name, Quantity=@Quantity, Price=@Price Where ProductId=@ProductId";
                _sqlDbConnection.Connection.Open();
                _sqlDbConnection.Connection.Query(sQuery, product);
            }
        }


    }
}
