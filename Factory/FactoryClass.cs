using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    using System;

    // Define a common interface for all products
    interface IProduct
    {
        void DoSomething();
    }

    // Define concrete implementations of the product interface
    public class ConcreteProductA : IProduct
    {
        public void DoSomething()
        {
            Console.WriteLine("Doing something in ConcreteProductA");
        }
    }

    public class ConcreteProductB : IProduct
    {
        public void DoSomething()
        {
            Console.WriteLine("Doing something in ConcreteProductB");
        }
    }

    // Define the factory class
    class Factory<T> where T : IProduct, new()
    {
        // The factory method that creates and returns an instance of the concrete product
        public T CreateProduct()
        {
            return new T();
        }
    }
}
