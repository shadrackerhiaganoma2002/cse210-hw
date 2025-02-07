using System;
using System.Collections.Generic;
using System.Text;

// Address class
public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.InvariantCultureIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// Customer class
public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }
    
    public string Name => name;
    public Address Address => address;
}

// Product class
public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal TotalCost()
    {
        return price * quantity;
    }

    public string Name => name;
    public string ProductId => productId;
}

// Order class
public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.TotalCost();
        }
        decimal shippingCost = customer.LivesInUSA() ? 5m : 35m;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (var product in products)
        {
            sb.AppendLine($"Product: {product.Name}, ID: {product.ProductId}");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Shipping Label:");
        sb.AppendLine($"Customer: {customer.Name}");
        sb.AppendLine(customer.Address.GetFullAddress());
        return sb.ToString();
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Elm St", "London", "N/A", "UK");
        
        Customer customer1 = new Customer("Alice Johnson", address1);
        Customer customer2 = new Customer("Bob Smith", address2);
        
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "P002", 19.99m, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "P003", 499.99m, 1));
        order2.AddProduct(new Product("Charger", "P004", 24.99m, 1));
        
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():F2}");
    }
}
