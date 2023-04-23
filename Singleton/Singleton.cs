using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeSingleton
{
    public sealed class Singleton
    {
        private static Singleton instance = null;
        public static int count = 0;
        private static readonly object instanceObj = new object();
        public static Singleton GetInstance()
        {
            //using a lock statement, you can ensure that only one thread can {code}
            if(instance == null)
            lock(instanceObj) { 
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }
            return instance;
        }

        private Singleton()
        {
            count++;
            Console.WriteLine($"No of instance created {count}");
        }

        public void Message(string name)
        {
            Console.WriteLine($"{name} created singleton");
        }
    }
}
