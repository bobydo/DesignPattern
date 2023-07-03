using System;

namespace ThreadSafeSingleton // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        //result
        //No of instance created 1
        //user created singleton
        //admin created singleton
        //No of instance created 1
        //UserLazy created singleton
        //AdminLazy created singleton
        //AdminConcurrent created singleton
        //No of instance created 1
        //UserConcurrent created singleton

        /// <summary>
        /// why Lazy<T> is often considered better than using a lock statement for lazy initialization:
        /// Thread safety: Lazy<T> is designed to be thread-safe by default, meaning that you don't have to worry about implementing thread safety yourself. When multiple threads try to access the value of a Lazy<T> instance for the first time, the Lazy<T> class ensures that only one thread initializes the value, while the other threads wait for the initialization to complete.
        /// Performance: The use of a simple lock statement can be expensive in terms of performance because it forces threads to wait for each other even when they don't need to. On the other hand, Lazy<T> uses a technique called double-checked locking to avoid unnecessary waiting, which can significantly improve performance.
        /// Lazy initialization: The Lazy<T> class provides lazy initialization, which means that the value of a Lazy<T> instance is only created when it's needed, and not before. This can be useful for conserving resources and reducing startup time.
        /// The basic idea of double-checked locking is to first check if a resource is already created or initialized. If it is not, then a lock is obtained to ensure that only one thread is allowed to create and initialize the resource. However, if the resource is already created or initialized, then there is no need to obtain a lock, and the thread can continue executing without waiting for the lock.
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            //Parallel.Invoke(
            //    () => User(),
            //    () => Admin()
            //    );

            Parallel.Invoke(
                () => UserLazy(),
                () => AdminLazy()
                );

            //Parallel.Invoke(
            //    () => UserConcurrent(),
            //    () => AdminConcurrent()
            //    );
            Console.ReadLine();
        }
        public static void User()
        {
            var user = Singleton.GetInstance();
            user.Message("user");
        }
        public static void Admin()
        {
            var admin = Singleton.GetInstance();
            admin.Message("admin");
        }

        public static void UserLazy()
        {
            var user = SingletonLazy.Instance;
            user.Message("UserLazy");
        }
        public static void AdminLazy()
        {
            var admin = SingletonLazy.Instance;
            admin.Message("AdminLazy");
        }

        public static void UserConcurrent()
        {
            var user = SingletonNoLock.Instance;
            user.Message("UserConcurrent");
        }
        public static void AdminConcurrent()
        {
            var user = Singleton.GetInstance();
            user.Message("AdminConcurrent");
        }
    }
}

