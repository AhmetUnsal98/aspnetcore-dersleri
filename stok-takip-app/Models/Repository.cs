using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stok_takip_app.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();
        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, CategoryName = "Telefon" });
            _categories.Add(new Category { CategoryId = 2, CategoryName = "Bilgisayar" });

            _products.Add(new Product {ProductId = 0, Name = "IPhone 14", Price = 40000, IsActive = true,Image = "1.jpg",CategoryId = 1 });
            _products.Add(new Product {ProductId = 1, Name = "IPhone 15", Price = 50000, IsActive = false,Image = "2.jpg",CategoryId = 1 });
            _products.Add(new Product {ProductId = 2, Name = "IPhone 16", Price = 60000, IsActive = true,Image = "3.jpg",CategoryId = 1 });
            _products.Add(new Product {ProductId = 3, Name = "IPhone 17", Price = 70000, IsActive = false,Image = "4.jpg",CategoryId = 1 });
            
            _products.Add(new Product {ProductId = 4, Name = "Macbook Air", Price = 80000, IsActive = false,Image = "5.jpg",CategoryId = 2 });
            _products.Add(new Product {ProductId = 5, Name = "Macbook Pro", Price = 90000, IsActive = true,Image = "6.jpg",CategoryId = 2 });
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

         public static  List<Category> Categories
        {
                get{
                    return _categories;
                }
        }


        public static void CreatePorduct(Product entity) {
            _products.Add(entity);
        }

        public static void EditProduct(Product updatedProduct) {
            Console.WriteLine(_products[0].ProductId);
            Console.WriteLine(updatedProduct.ProductId);
            var entity = _products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
            if(entity != null) {
                entity.Name = updatedProduct.Name;
                entity.Price = updatedProduct.Price;
                entity.Image =  updatedProduct.Image;
                entity.IsActive = updatedProduct.IsActive;
                entity.CategoryId = updatedProduct.CategoryId;
            }
       
        }
        public static void DeleteProduct(Product deletedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == deletedProduct.ProductId);

            if(entity != null) 
            {
                _products.Remove(entity);
            }
        }
    }
}