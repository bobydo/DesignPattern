using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeSingleton
{
    public sealed class SingletonNoLock
    {
        private static readonly ConcurrentDictionary<Type, SingletonNoLock> instances = new ConcurrentDictionary<Type, SingletonNoLock>();
        private static int count=0;
        public static SingletonNoLock Instance
        {
            get { return instances.GetOrAdd(typeof(SingletonNoLock), t => new SingletonNoLock()); }
        }

        private SingletonNoLock() {
            count++;
            Console.WriteLine($"No of instance created {count}");
        }
        public void Message(string name)
        {
            Console.WriteLine($"{name} created singleton");
        }
    }
}
