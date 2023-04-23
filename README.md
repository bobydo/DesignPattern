# DesignPattern Using VS 2022 => lots of intellisense
will implement common design patterns deeply and weekly
## Singleton from chatgpt explanation
Why Lazy<T> is often considered better than using a lock statement for lazy initialization:
Thread safety: Lazy<T> is designed to be thread-safe by default, meaning that you don't have to worry about implementing thread safety yourself. When multiple threads try to access the value of a Lazy<T> instance for the first time, the Lazy<T> class ensures that only one thread initializes the value, while the other threads wait for the initialization to complete.
Performance: The use of a simple lock statement can be expensive in terms of performance because it forces threads to wait for each other even when they don't need to. On the other hand, Lazy<T> uses a technique called double-checked locking to avoid unnecessary waiting, which can significantly improve performance.
Lazy initialization: The Lazy<T> class provides lazy initialization, which means that the value of a Lazy<T> instance is only created when it's needed, and not before. This can be useful for conserving resources and reducing startup time.
The basic idea of double-checked locking is to first check if a resource is already created or initialized. If it is not, then a lock is obtained to ensure that only one thread is allowed to create and initialize the resource. However, if the resource is already created or initialized, then there is no need to obtain a lock, and the thread can continue executing without waiting for the lock.
