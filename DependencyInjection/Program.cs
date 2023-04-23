using Unity;
namespace DependencyInjection
{
    public class Program
    {
        public static void Main()
        {
            // Create DI container
            var container = new UnityContainer();

            // Register types with container
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IOrderRepository, OrderRepository>();

            // Resolve service from container
            var productService = container.Resolve<IProductService>();

            // Use service to process order
            productService.ProcessOrder("ProductA", 5);
            Console.ReadLine();
        }
    }
}
