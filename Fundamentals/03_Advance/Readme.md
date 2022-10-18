# Generics

Issue example: 

When creating a list you need to specify the dataType such as int, string, Book class, etc, so when you need a list for diferent dataType you will end up creating different lists for each dataType.

One solution is to create a List<Object>, since object is the parent class of all dataTypes in .NET framework, but there's a performance problem b/c each time you add a valueType (int, float, struct) it will be `boxed`/converted into an object and when read will be `unboxed` into a value type again.

`Generics` haave been created to solve it. We create a class once and reuse multiple times without the performance penalty.

```
public class GenericDictionary<TKey, TValue>
{
    public void Add(TKey key, TValue value)
    {

    }
}

public class GenericList<T>
{
    public void Add(T value) 
    {

    }
    public T this[int index]
    {
        get{ throw new NotImplementedException(); }
    }
}

var numbers = new GenericList<int>();
number.Add(10);

var books = new GenericList<Book>();
books.Add(new Book());

var dictionary = new GenericDictionary<string, Book>();
dictionary.Add("1234", new Book());
```

### Generic Contraints

Restric the `T` object to certain dataTypes.

Types:
* Interface: where T : IComparable
* Sub-class: where T : Product
* Value Type: where T : struct
* Reference value: where T : class
* Object with default constructor: where T : new()

# Delegates

* An object that knos how to call a methos (or a group of methods)
* A reference/pointer to a funciton

Why do we need delegates?

* For designing extensible and flexible applications (e.g Frameworks)

### System built-in Delegates

* System.Action<>: Delegates functions that returns `void`, up to 16 parameters
* System.Func<>: Delegates methods that returns a `value`, up to 16 parameters.

### When to use Interface or Delegates?

Use delegate when:

* An eventing design patter is used.
* The caller doesn't need to accesss other properties or methods on the object implementing the method.

# Lambda Expression (=> lamba operator)

An anonymous method:

* No access modifier
* No name
* No return statement

```
// Syntax: args => expresion
// The compiler infers the dataType automatically most cases, if not we can specify it by Delegates.
number => number * number; 

// Dalegate <dataType argument, dataType return>
Func<int, int> square = number => number * number; 

// No args: () => ...
// One arg: x => ...
// Many args: (x, y, z) => ...

```

`Predicate` is a function that takes an argument(s) and returns `true` or `false` depending on a condition evaluate result.

# Events & Delegates

Events

* A mechanism for comunication between objects
* Used in building **Loosely Coupled Applications**
* Helps extending applications

Use Publish/Subscriber 

### Delegate

* Agreement/Contract between Publisher and sUBSCRIBER
* Determines the signature of the event handler method in Subscriber

Steps to publlish an event:

 1. Define a delegate or use `EventHandler` built-in delegate 
 2. Define an event based on that delegate
 3. Raise/send the event

# Extension Methods

Allow us to add methods to an existing class without

* changin its source code, or
* creating a new class that inherits from it

To create an extension class you need:

1. create a `static` class. Naming convention is to start with class you are trying to extend + Extensions
2. Add methods with this special param `this ClassToExtend variableName` which represents the instance where we are applying this extended method on.

we can define the extension class in `System` namespace so we dont ned to add more imports/using at the top of our `Program` class

```
// Extending String class
public static class StrignExtensions
{
    public static Shorten(this String str, int, numberOfWords)
    {

    }
}
```

There are built-in extension methods as well that will have priority over custom extensions, then the suggestion is to use Extension methods only whe you have to. 

* If you have the class source code, then try changing it, or
* Create a derived class and override the method, or
* Use an Extension method

# LINQ (Language Integrated Query)

Gives you the capability to query objects:

* Objects in mempry, eg collections (LINQ to Objects)
* Databases (LINQ to Entities)
* XLM (LINQ to XML)
* ADO.NET Data Sets (LINQ to Data Sets)

```
// Filters
.Where();
.Single();
.SingleOrDefault();

.First();
.FirstOrDefault();
.Last();
.LastOrDefault();

.Min();
.Max();
.Sum();
.Average();
```

# Nullable Types

In C# Value Types cannot be `null`, but there are some cases where you need null values. e.g Database table.

We can solve it using `Nulabble` generic structure in System namespace. 

```
// Syntax
Nulable<DataTime> date = null;
DataTime? date = null;
```

### Null Coalescing Operator (??)

It is like a ternary operator.

```
DateTime date = date ?? DateTime.Today;
```

# Dynamic

Statically-types languages: C#, Java
Dynamically-typed languages: Python, JavaScript, Ruby

Difference: Type resolution

Satic languages: at compile time
Synamic languages: at run time

Benefits:
Static languages: early feedback (compile time)
Dynamic languages: easier and faster to code

There is a `DLR` (Dynamic Language Runtime) on top of CLR that provides C# with Dynamic Typed capabilities.

```
dynamic name = "Juan";
name = 10; // it works
```

# Asynchronous Programming

### Synchronous Program execution

* Program is executed line bt line, one at a time
* When a functoin is called, program execution has to wait until the function returns

### Asynchronous Program Execution

* When a function is called, program eecution continues to the next line, without waiting for the function to complete

### Difference

* Asynchronous programminf imporoves responsiveness of the application.

### When to use asynchorinous?

* Accessinf the Web
* Working with files and databases
* Working with images

Use `async` keyword for the functions, and inside it use `await` and `methods with sufix Async` to let the compiler knows it should not wait for the methos to complete. Once it completes the runtime `callback` is executed at the line right after the async clall was executed.

```
// We need to used a Task object for return
// A Task is an object that encapsulates the state of asynchronous operation.
//  Task for void finctions
//  Task<T> for return functions
public async Task<string> DownloadHTMLAsync(string url)
{
    // Logic using Async and await 
    var webClient = new WebClient();
    // Here we return control to main program
    // Once the funciton is completed the runtime continues with the rest of thi function

    var html = await webClient.DownloadStringTaskAsync(url);  // Option 1
    var getHtmlTask = webClient.DownloadStringTaskAsync(url);  // Option 2
    // Do something that do not depend of the async operation
    
    var html = await getHtmlTask;

    using (var streamWriter = new StreamWriter("paht.html"))
    {
        streamWriter.Write(html);
    }
}
```

