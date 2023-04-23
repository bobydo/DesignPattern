namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use the factory to create instances of the products
            var factoryA = new Factory<ConcreteProductA>();
            var productA = factoryA.CreateProduct();
            productA.DoSomething();

            var factoryB = new Factory<ConcreteProductB>();
            var productB = factoryB.CreateProduct();
            productB.DoSomething();

            Console.ReadLine();
        }
    }
}
