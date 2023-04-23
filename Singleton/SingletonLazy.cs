using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeSingleton
{
    public sealed class SingletonLazy
    {
        private static int count = 0;
        private static readonly Lazy<SingletonLazy> lazy = new Lazy<SingletonLazy>(() => new SingletonLazy());

        public static SingletonLazy Instance { get { return lazy.Value; } }

        private SingletonLazy() {
            count++;
            Console.WriteLine($"No of instance created {count}");
        }
        public void Message(string name)
        {
            Console.WriteLine($"{name} created singleton");
        }
    }
}
