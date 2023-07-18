using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Model;
using System.Xml.Linq;

namespace FriendsAPI.Controllers
{
    public class ProductsController : Controller
    {
        static List<int> cart = new List<int>();
        Product product = new Product();


        [HttpGet]
        [Route("plist")]
        public IActionResult ShowAllProducts()
        {
            var products = product.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("plist/{name}")]
        public IActionResult GetProductByName(string name)
        {
            try
            {
                var result = product.GetProductByName(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("plist/category/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            var products = product.GetProductsByCategory(category);
            if (products != null && products.Any())
            {
                return Ok(products);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("plist/stock/{true}")]
        public IActionResult GetProductsByStock(bool inStock)
        {
            var products = product.GetProductsInStock(inStock);
            if (products != null && products.Any())
            {
                return Ok(products);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("plist/add")]
        public IActionResult AddProduct(Product newProduct)
        {
            var result = product.AddProduct(newProduct);
            return Created("", result);
        }

        [HttpPut]
        [Route("plist/edit")]
        public IActionResult UpdateProduct(Product newProduct)
        {
            try
            {
                var result = product.UpdateProduct(newProduct);
                return Accepted(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("plist/delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var result = product.DeleteProduct(id);
                return Accepted(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }




        [HttpPost]
        [Route("product/cart/add/tocart/pid")]
        public IActionResult AddToCart(int pid)
        {
            cart.Add(pid);
            return Created("", "added to your Cart");
        }

        [HttpGet]
        [Route("plist/cart")]
        public IActionResult GetCartProudcts()
        {
            try
            {
                var result = product.GetProductById(cart);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
