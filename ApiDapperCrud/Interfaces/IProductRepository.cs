using ApiDapperCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDapperCrud.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Delete(int id);
        void Update(Product product);
    }
}
