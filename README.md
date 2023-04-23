# DesignPattern Using VS 2022 => lots of intellisense
will implement common design patterns deeply and weekly

Dependency injection if interface is initialized, throw exception
public static class MyClassFactory
{
    public static MyClass CreateInstance(IProduct product)
    {
        if(product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        return new MyClass(product);
    }
}

public MyClass(IProduct product)
{
    if(product == null)
        throw new ArgumentNullException(nameof(product));
    
    _product = product;
}

IProduct product = new Product();
MyClass myClass = MyClassFactory.CreateInstance(product);

## Singleton from chatgpt explanation
Why Lazy<T> is often considered better than using a lock statement for lazy initialization:
Thread safety: Lazy<T> is designed to be thread-safe by default, meaning that you don't have to worry about implementing thread safety yourself. When multiple threads try to access the value of a Lazy<T> instance for the first time, the Lazy<T> class ensures that only one thread initializes the value, while the other threads wait for the initialization to complete.
Performance: The use of a simple lock statement can be expensive in terms of performance because it forces threads to wait for each other even when they don't need to. On the other hand, Lazy<T> uses a technique called double-checked locking to avoid unnecessary waiting, which can significantly improve performance.
Lazy initialization: The Lazy<T> class provides lazy initialization, which means that the value of a Lazy<T> instance is only created when it's needed, and not before. This can be useful for conserving resources and reducing startup time.
The basic idea of double-checked locking is to first check if a resource is already created or initialized. If it is not, then a lock is obtained to ensure that only one thread is allowed to create and initialize the resource. However, if the resource is already created or initialized, then there is no need to obtain a lock, and the thread can continue executing without waiting for the lock.

## Favtory from chatgpt explanation (may apply thread safety to factory pattern as singlton does)
There are several reasons why implementing the Factory Pattern in code is beneficial:
1. Encapsulation: By using a factory method, the process of creating objects can be hidden behind an interface, which improves encapsulation. The client does not need to know how objects are created and initialized; instead, it just needs to know the interface to communicate with the newly created object.
2. Flexibility: The factory pattern allows you to change the type of objects being created without changing the client code. If a new class is added to the system, it can be easily integrated into the system by adding a new concrete factory class, instead of modifying the client code.
3. Code maintainability: Factory patterns make the code more modular and easier to maintain. By separating the creation of objects from the rest of the code, it becomes easier to maintain and modify the code, since changes in object creation will not affect other parts of the code.
4. Testability: Implementing a factory pattern in code allows for more testable designs. By decoupling the code, it becomes easier to write unit tests and ensure the correct behavior of each object in isolation.