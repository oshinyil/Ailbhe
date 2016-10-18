using Ailbhe.WebApi.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace Ailbhe.WebApi.Controllers
{
    [EnableCors("http://localhost:8237", "*", "*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            try
            {
                var repository = new ProductRepository();
                return Ok(repository.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Product product;
                var repository = new ProductRepository();

                if (id > 0)
                {
                    var products = repository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = repository.Create();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var repository = new ProductRepository();
                var newProduct = repository.Save(product);
                if (newProduct == null)
                {
                    return Conflict();
                }

                return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(), newProduct);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var repository = new ProductRepository();
                var updatedProduct = repository.Save(id, product);
                if (updatedProduct == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
