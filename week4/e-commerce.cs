using System;
using System.Collections.Generic;

namespace ECommerceApplication
{
    
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int StockQuantity { get; set; }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {Name}, Price: {Price}, Stock: {StockQuantity}";
        }
    }

    public class Cart
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public float TotalPrice { get; private set; }

        public void AddProduct(Product product)
        {
            if (product.StockQuantity > 0)
            {
                Products.Add(product);
                TotalPrice += product.Price;
                product.StockQuantity--; 
                Console.WriteLine($"{product.Name} added to cart.");
            }
            else
            {
                Console.WriteLine($"{product.Name} is out of stock.");
            }
        }

        public void RemoveProduct(Product product)
        {
            if (Products.Remove(product))
            {
                TotalPrice -= product.Price;
                product.StockQuantity++; 
                Console.WriteLine($"{product.Name} removed from cart.");
            }
            else
            {
                Console.WriteLine($"{product.Name} not found in cart.");
            }
        }

        public void ShowCart()
        {
            Console.WriteLine("Current Cart:");
            foreach (var item in Products)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Total Price: ${TotalPrice:F2}");
        }
    }


    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public Cart Cart { get; set; } = new Cart();
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product { ProductId = "P001", Name = "Laptop", Price = 999.99f, StockQuantity = 10 },
                new Product { ProductId = "P002", Name = "Smartphone", Price = 499.99f, StockQuantity = 20 },
                new Product { ProductId = "P003", Name = "Headphones", Price = 199.99f, StockQuantity = 30 }
            };

            User user = new User { UserId = "U001", Name = "John Doe" };


            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }

            user.Cart.AddProduct(products[0]);
            user.Cart.AddProduct(products[1]);
            user.Cart.ShowCart();

            
            user.Cart.RemoveProduct(products[0]); 
            user.Cart.ShowCart();
        }
    }
}
