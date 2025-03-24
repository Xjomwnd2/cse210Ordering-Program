using System;
using System.Collections.Generic;

// Address class
class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    // Method to check if address is in USA
    public bool IsInUSA()
    {
        return _country.ToUpper() == "USA";
    }

    // Method to get a formatted address string
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}

// Customer class
class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Getters
    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    // Method to check if customer lives in USA
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}

// Product class
class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Getters
    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    // Method to calculate total cost of the product
    public decimal CalculateTotalCost()
    {
        return _price * _quantity;
    }
}

// Order class
class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate total price of the order
    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;
        
        // Sum up all product costs
        foreach (Product product in _products)
        {
            totalPrice += product.CalculateTotalCost();
        }
        
        // Add shipping cost based on customer location
        decimal shippingCost = _customer.IsInUSA() ? 5 : 35;
        totalPrice += shippingCost;
        
        return totalPrice;
    }

    // Method to generate packing label
    public string GetPackingLabel()
    {
        string packingLabel = "PACKING LABEL:\n";
        
        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        
        return packingLabel;
    }

    // Method to generate shipping label
    public string GetShippingLabel()
    {
        string shippingLabel = "SHIPPING LABEL:\n";
        shippingLabel += $"Customer: {_customer.GetName()}\n";
        shippingLabel += _customer.GetAddress().GetFullAddress();
        
        return shippingLabel;
    }
}

// Program class
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System\n");

        // Create first order
        Console.WriteLine("Order #1:");
        
        // Create address and customer for first order
        Address address1 = new Address("123 Main St", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        
        // Create order
        Order order1 = new Order(customer1);
        
        // Add products to the order
        Product product1 = new Product("Laptop", "TECH001", 999.99m, 1);
        Product product2 = new Product("Wireless Mouse", "TECH002", 24.99m, 2);
        Product product3 = new Product("USB Cable", "TECH003", 9.99m, 3);
        
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);
        
        // Display order information
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalPrice()}");
        
        Console.WriteLine("\n----------------------------------------\n");

        // Create second order
        Console.WriteLine("Order #2:");
        
        // Create address and customer for second order
        Address address2 = new Address("456 High Street", "London", "England", "UK");
        Customer customer2 = new Customer("Jane Doe", address2);
        
        // Create order
        Order order2 = new Order(customer2);
        
        // Add products to the order
        Product product4 = new Product("Headphones", "AUDIO001", 59.99m, 1);
        Product product5 = new Product("Bluetooth Speaker", "AUDIO002", 79.99m, 1);
        
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        
        // Display order information
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotalPrice()}");
    }
}