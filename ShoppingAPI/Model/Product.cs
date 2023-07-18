using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace ShoppingAPI.Model
{
    public class Product
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public double pPrice { get; set; }
        public string pDescription { get; set; }
        public bool pIsInStock { get; set; }


        static List<Product> productList = new List<Product>()
            {
                new Product(){pId=1,pName="Dell Vostro",pCategory="Laptop",pPrice=40000, pDescription="",pIsInStock=true },
                new Product(){pId=2,pName="Dell Inspiron",pCategory="Laptop",pPrice=50000, pDescription="",pIsInStock=true },
                new Product(){pId=3,pName="Dell Latitude",pCategory="Laptop",pPrice=60000, pDescription="",pIsInStock=true },
                new Product(){pId=4,pName="Lenovo ThinkBook",pCategory="Laptop",pPrice=70000, pDescription="",pIsInStock=true },
                new Product(){pId=5,pName="Lenovo IdeaPad",pCategory="Laptop",pPrice=80000, pDescription="",pIsInStock=true },
                new Product(){pId=6,pName="Lenovo ThinkPad",pCategory="Laptop",pPrice=90000, pDescription="",pIsInStock=true },
                new Product(){pId=7,pName="Lenovo Legion",pCategory="Laptop",pPrice=40000, pDescription="",pIsInStock=true },
                new Product(){pId=8,pName="Lenovo Yoga",pCategory="Laptop",pPrice=40000, pDescription="",pIsInStock=true },
                new Product(){pId=9,pName="Apple Mackbook Air",pCategory="Laptop",pPrice=200000, pDescription="",pIsInStock=false },
                new Product(){pId=10,pName="Apple Mackbook Pro",pCategory="Laptop",pPrice=150000, pDescription="",pIsInStock=true },
            };


        public List<Product> GetAllProducts()
        {
            return productList;
        }

        public Product GetProductByName(string name)
        {
            var product = productList.Where(x => x.pName == name)?.FirstOrDefault();
            if (product != null)
            {
                return product;
            }
            throw new Exception("Product not found");
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return productList.Where(x => x.pCategory == category).ToList();
        }

        public List<Product> GetProductsInStock(bool inStock)
        {
            return productList.Where(x => x.pIsInStock == inStock).ToList();
        }

        public string AddProduct(Product product)
        {
            if (product != null)
            {
                productList.Add(product);
                return "Product added Successfully!";
            }
            return "Faild to add a Product!"; ;
        }

        public string UpdateProduct(Product updatedProduct)
        {

            var product = productList.Where(x => x.pId == updatedProduct.pId)?.FirstOrDefault();
            if (product != null)
            {
                product.pName = updatedProduct.pName;
                product.pCategory = updatedProduct.pCategory;
                product.pPrice = updatedProduct.pPrice;
                product.pDescription = updatedProduct.pDescription;
                product.pIsInStock = updatedProduct.pIsInStock;
                return "Product information Updated Successfully!";
            }
            throw new Exception("Product not found");
        }

        public List<Product> GetProductById(List<int> ids)
        {
            var products = productList.Where(x => ids.Contains(x.pId)).ToList();
            if (products != null && products.Any())
            {
                return products;
            }
            throw new Exception("No Products found in Cart");
        }

        public string DeleteProduct(int productId)
        {
            var product = productList.Where(x => x.pId == productId)?.FirstOrDefault();
            if (product != null)
            {
                productList.Remove(product);
                return "Product deleted";
            }
            throw new Exception("Product Not found and thus not deleted");
        }
    }
}
