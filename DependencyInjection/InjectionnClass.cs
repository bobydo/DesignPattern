using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public interface IProductService
    {
        void ProcessOrder(string productName, int quantity);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderService _orderService;

        public ProductService(IProductRepository productRepository, IOrderService orderService)
        {
            _productRepository = productRepository;
            _orderService = orderService;
        }

        public void ProcessOrder(string productName, int quantity)
        {
            // Check product availability
            var product = _productRepository.GetProductByName(productName);

            if (product == null)
            {
                throw new InvalidOperationException($"Product '{productName}' not found.");
            }

            if (product.UnitsInStock < quantity)
            {
                throw new InvalidOperationException($"Insufficient stock for product '{productName}'.");
            }

            // Process order
            _orderService.CreateOrder(product, quantity);
            _productRepository.UpdateUnitsInStock(product, quantity);
        }
    }

    public interface IOrderService
    {
        void CreateOrder(Product product, int quantity);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void CreateOrder(Product product, int quantity)
        {
            var order = new Order(product, quantity);
            _orderRepository.SaveOrder(order);
        }
    }

    public interface IProductRepository
    {
        Product GetProductByName(string name);
        void UpdateUnitsInStock(Product product, int quantity);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly Dictionary<string, Product> _products;

        public ProductRepository()
        {
            _products = new Dictionary<string, Product>()
        {
            { "ProductA", new Product("ProductA", 10) },
            { "ProductB", new Product("ProductB", 20) },
            { "ProductC", new Product("ProductC", 30) }
        };
        }

        public Product GetProductByName(string name)
        {
            if (_products.TryGetValue(name, out var product))
            {
                return product;
            }

            return null;
        }

        public void UpdateUnitsInStock(Product product, int quantity)
        {
            product.UnitsInStock -= quantity;
        }
    }

    public interface IOrderRepository
    {
        void SaveOrder(Order order);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }

        public void SaveOrder(Order order)
        {
            _orders.Add(order);
        }
    }

    public class Product
    {
        public string Name { get; }
        public int UnitsInStock { get; set; }

        public Product(string name, int unitsInStock)
        {
            Name = name;
            UnitsInStock = unitsInStock;
        }
    }

    public class Order
    {
        public Product Product { get; }
        public int Quantity { get; }

        public Order(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
