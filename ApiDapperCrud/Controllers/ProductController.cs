using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDapperCrud.Interfaces;
using ApiDapperCrud.Model;
using ApiDapperCrud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDapperCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]Product product)
        {
            if (ModelState.IsValid)
                _productRepository.Add(product);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product)
        {
            product.ProductId = id;
            if (ModelState.IsValid)
                _productRepository.Update(product);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }


    }
}