using Ailbhe.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace Ailbhe.WebApi.Controllers
{
    [EnableCors("http://localhost:8237", "*", "*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery]
        public IQueryable<Product> Get()
        {
            var repository = new ProductRepository();
            return repository.Retrieve().AsQueryable();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            Product product;
            var repository = new ProductRepository();

            if (id > 0)
            {
                var products = repository.Retrieve();
                product = products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                product = repository.Create();
            }

            return product;
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            var repository = new ProductRepository();
            var newProduct = repository.Save(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product)
        {
            var repository = new ProductRepository();
            var newProduct = repository.Save(id, product);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
