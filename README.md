## What is Asynchronous Programming?
Asynchronous programming is an approach to programming designed to execute the operations of a program sequentially and without waiting. This approach allows to efficiently manage long-running processes or input/output operations without blocking the main thread. Especially in interactive applications such as user interfaces, asynchronous programming allows the application to run more responsively.

## What is Multi Thread?
Multi threading refers to the ability of a program to execute tasks simultaneously using multiple threads. In this way, different tasks or operations can be performed simultaneously. This is especially important nowadays, when processors are multi-core, to achieve performance gains.

## Task (Async-Await)
The Async and Await keywords form the basis of asynchronous programming in C# programming. By using the async keyword in a method, we can make that method asynchronous. This is used to process the method in the background without blocking the method caller. Task is a class that represents the result of this asynchronous operation. If the asynchronous method returns a value, expect a return value of Task<T>.

### `ContinueWith`
The ContinueWith method is used to automatically run another Task when a Task completes. This is useful for Task chaining and for adapting the workflow to more complex scenarios. In particular, it can be used when multiple asynchronous processes need to run sequentially or in parallel.

More generally, asynchronous programming and multithreading have become an essential part of modern software development. With these techniques, it is possible to develop faster, more responsive and more efficient applications. However, using these approaches correctly and safely means that in some scenarios you may encounter difficulties and errors. Therefore, it is important to have a deep understanding of the subject and to design applications carefully.

### WaitAll Method:

`WaitAll` method, similar to the `WhenAll` method, takes a `Task[]`. However, here it waits for the `Task[]` to complete. The key difference is that `WaitAll` blocks tasks; in other words, it won't move on to another task until the current one finishes.

Due to blocking, its usage is not highly recommended. It can be used in scenarios where synchronous behavior is necessary.

Another difference from the `WhenAll` method is that it takes an additional parameter in milliseconds. Its return type is true/false. If no time value is provided, the return type is void.

```csharp
List<Task<Content>> taskList = new List<Task<Content>>();
    urlsList.ToList().ForEach(url =>
    {
        taskList.Add(GetContentAsync(url));
    });
Console.WriteLine("WaitAll metodundan önce");
Task.WaitAll(taskList.ToArray());
bool result = Task.WaitAll(taskList.ToArray(),300);
Console.WriteLine("3 saniyede geldi mi? : "+ result);
Console.WriteLine("WaitAll metodundan sonra");
Console.WriteLine($"{taskList.First().Result.Site}-{taskList.First().Result.Length}");
}
```

### WaitAny Method:

`WaitAny` method waits for any task in the array to complete and returns the index of the completed task. This also blocks the processor and waits for the current executing thread, regardless of where it's called.

An integer value is returned when any of the tasks in the array completes. This integer value represents the index of the completed task.

Its usage requires caution and is generally suitable for specific scenarios.

```csharp
List<Task<Content>> taskList = new List<Task<Content>>();
 urlsList.ToList().ForEach(url =>
        {
            taskList.Add(GetContentAsync(url));
        });

        Console.WriteLine("WaitAll metodundan önce");

        var firstTaskIndex = Task.WaitAny(taskList.ToArray());

        Console.WriteLine($"{taskList[firstTaskIndex].Result.Site}-{taskList[firstTaskIndex].Result.Length}");
    }
```

## Delay() Method:

`Delay` introduces an asynchronous delay. This delay doesn't block the thread and continues after the specified time. This method is particularly useful for creating timed tasks.

```csharp
List<Task<Content>> taskList = new List<Task<Content>>();

urlsList.ToList().ForEach(url =>
{
    taskList.Add(GetContentAsync(url));
});

Console.WriteLine("Before WaitAll");

var contents = await Task.WhenAll(taskList.ToArray());

contents.ToList().ForEach((content) => Console.WriteLine(content.Site));
``` 

## Run() Method:

The `Run` method executes the provided code on a separate thread. It's particularly useful for running intense computations or long-running tasks on a separate thread.

### When Should I Execute Methods on Separate Threads?

It's suitable to run methods that heavily utilize your CPU on separate threads.

For instance, consider a method with numerous mathematical calculations, algorithms, and trigonometry operations. Such a math-intensive method will undoubtedly stress your CPU. In these cases, running your methods on separate threads is advisable.

However, tasks like file reading/writing, database operations, making HTTP requests to web pages, and similar scenarios don't warrant separate thread usage. In fact, these situations might be better suited for async methods instead of threads.

### StartNew() Method:

The `StartNew` method serves the same purpose as the `Run` method. The difference is that while the `Run` method doesn't allow passing an object when creating a task, the `StartNew()` method allows passing an object.

```csharp

public class Status
{
    public int threadId { get; set; }
    public DateTime date { get; set; }
}

public class Program
{
    private async static Task Main(string[] args)
    {
        var myTask = Task.Factory.StartNew((Obj) =>
        {
            Console.WriteLine("myTask executed");
            var status = Obj as Status;
            status.threadId = Thread.CurrentThread.ManagedThreadId;

        }, new Status() { date = DateTime.Now });

        await myTask;
        Status status = myTask.AsyncState as Status;
        Console.WriteLine(status.date);
        Console.WriteLine(status.threadId);
    }
}

``` 

### FromResult() Method:

`FromResult` is used to return a Task containing an existing result. It's particularly useful for managing precomputed or cached results.
````csharp
public class Program
{
    public static string? CacheData { get; set; }

    private async static Task Main(string[] args)
    {
        CacheData = await GetDataAsync();
        Console.WriteLine(CacheData);
    }

    public static Task<string> GetDataAsync()
    {
        if (String.IsNullOrEmpty(CacheData))
        {
            return File.ReadAllTextAsync("file.txt");
        }
        else
        {
            return Task.FromResult<string>(CacheData);
        }
    }
````

## Cancellation Token

For an async method to be able to accept a token, there must be an overloaded constructor. Not all async methods necessarily have a token parameter.

Cancellation Token is a construct used in C# programming, particularly in asynchronous operations, to cancel or stop an asynchronous operation.

### Task Instance

Property: Result =>

If an asynchronous operation, such as `new HttpClient().GetStreamAsync("https://www.google.com");`, takes 5 seconds, when it reaches `Result`, the current thread at that moment gets blocked. Once the thread is blocked, responsiveness is lost.

Below is an example written with .NET 3.1:

```csharp
namespace TaskInstanceConsoleApp
{
    internal class Program
    {
        private async static Task Main(string[] args)
        {
            Console.WriteLine(GetData());
        }

        public static string GetData()
        {
            var task = new HttpClient().GetStringAsync("https://www.google.com");
            return task.Result; ;
        }
    }
}
```

If you wish to write the above code with .NET 7, you can do it like this:

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;

var result = await GetDataAsync();
Console.WriteLine(result);

static async Task<string> GetDataAsync()
{
    using var httpClient = new HttpClient();
    string result = await httpClient.GetStringAsync("https://www.google.com");
    return result;
}
```
### Properties
When you run this code with breakpoints, you enter the "Raw View" section. Here, properties are listed:
-   **IsCanceled**: Returns `true` if canceled, and `false` otherwise.
-   **IsCompleted**: Returns `false` if the task hasn't completed yet, and `true` if it has completed. This indicates whether the task has completed; whether or not an exception was thrown.
-   **IsCompletedSuccessfully**: Returns `true` if the task completed successfully without throwing any exception, otherwise `false`.
-   **IsFaulted**: Returns `true` if the task throws an exception while executing, otherwise `false`.

```csharp
Task myTask = Task.Run(() =>
{
    Console.WriteLine("My Task has been worked");
});

await myTask;

Console.WriteLine("Process is done");
````


### Value Task

`ValueTask` is a struct. What's the difference?

In C#, there are two broad types: reference types (e.g., string) and value types. Value types include int, double, and structs. These two types are stored in different places in memory. Value types are stored on the stack, while reference types are stored in the heap region of memory. The data stored in the heap requires a garbage collector to clean up, at intervals, objects that are no longer being referenced.

Data stored in the stack, on the other hand, is automatically discarded from memory when it goes out of scope.

When returning data from a relatively lightweight async method, instead of returning a new task, the data is returned as a `ValueTask` type. This is more memory-efficient and performs better.

```csharp
internal class Program
{
    public static int CachedData { get; set; } = 150;

    private static async Task Main(string[] args)
    {
        await GetDataAsync();
    }

    public static ValueTask<int> GetDataAsync()
    {
        return new ValueTask<int>(CachedData);
    }
}
```



