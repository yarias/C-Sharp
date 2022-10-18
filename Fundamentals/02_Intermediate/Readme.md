# Classes

Anatomy of a class:
* Data (represented by fields)
* Behaviour (represented by methods/funcitons)

## Object

An instance of the class that resides in the memory

## Naming convention

* Pascal Case -> For classes/methods
* camel Case -> For parameters of methods, objects of a class

## Class members

* Instance: accesible from an object
* Static: accessible from the class

### Why use static members?

* To represent consepts that are singleton (we only have one instance of the concept in memory) `ex: DateTimme.Now`


## Constructor

* A methood that is called when an instance of a class is created, it puts an object in an early state (initialize some of the fields in the class)
* It has the exact same name of the class and `do not` have a `return type`.
* To declare the constructor in a class is optional, if you don't declare a default constructor C-Sharp compiler create one for you.
* If not declared all the fields are set to default values: Numbers to 0, bools to false, reference values (string, objects) to null and characters to empty characters.    
* We only use constructors when we really want to initialize that object to early state.
* Best practice: Always when a class has internally a list of objects (List<Objects>) you must initialize it with something or an empty list.

```
public class Customer
{
    public string Name;

    // Parameter less or default constructor
    public Customer()
    {
    }

    // Constructor with params
    public Customer(strigng name)
    {
        this.Name = name;
    }
}
```

### Constructor Overloading

It means having a method with same name but different signatures. A signature is what uniquely identifies a method (its return type, its name, and the types and numbers of its parameters)

## Object Initializer

* It is a syntax for quickly initialising an object without he need to call one of its constructors.
* Usefull to avoid creating multiple constructors
* When creating an object you need to initialize the fields passing them inside {}.

```
var person = new Person
                {
                    FirstName = "Juan",
                    LastName = "Arce"
                };
```

## Methods

### Signature of a method

* Name
* Number and type of parameters

### Oveerloading Methods

* Having a method with the same name but different signatures

### Params Modifier

* Adding the `params` keyword before the data type allows to pass multiple params to the method.

### Ref Modifier (Code Smell)

* Add the `ref` keyword before the data type, it passes a refence (MEM location) of a variable to method then the global variable values is modified within that method.
* To call that method you must pass the `ref` keyword before the variable if not, then if fails. It's hard to remember when you need to pass a ref that's why it's a code smell.

### Out Modifier (Code Smell)

* Add the `out` keyword before the data type to allow a method to return one or more values even if it is a void method.
*  Any parameter declared with the out modifier is expected to receive a value at the end of the method.
* The numbers of return values depends on the number of `out` params.
* To call that method you must pass the `out` keyword before the variable if not, then if fails. It's hard to remember when you need to pass a ref that's why it's a code smell.

```
// Methods with varying number of params

// It is not a best practice b/c If the number of params
// increasse it you need to add more overloadings
public class Calculator
{
    public int Add(int n1, int n2) {...}
    public int Add(int n1, int n2, n3) {...}
    public int Add(int n1, int n2, n3, n4) {...}
}


// Another method is to use arrays
// There's issue, each time you pass params to that method
// you need to create/initialize a new array each time 
public class Calculator
{
    public int Add(int[] numbers) {...}
}
var result = calculator.Add(new int[]{1, 2, 3, 4})

// Params Modifier
public class Calculator
{
    public int Add(params int[] numbers) {...}
}
var result = calculator.Add(new int[]{1, 2, 3, 4}) // Method1
var result = calculator.Add(1, 2, 3, 4) // Method2

// Ref modifier
public class AddTwo
{
    public void Add(ref int number) 
    {
        number += 2;
    }
}
var a = 1;
AddTwo.Add(ref a) // The value of a will be 3

// Out modifier
public class AddTwo
{
    public void Add(out int number) 
    {
        number += 2;
    }
}
var a = 1;
AddTwo.Add(out a) // Retrun the value of a even it is a void.
```

## Fields

* Initialization: You can initialize the fileds using a constructor (when the initial values comes from outside) or directly when declaring the field.
* Read-Only fields: Use the `readonly` modifier to make sure that filed is only assigned once. Used to create safety in the app and improve robustness. If reassigning that field in another place then the compiler will thow an error. 

## Access Modifier

It is a way to control access to a class and/or its members. Used to create safety in our applications

Encapsulation or Information Hiding: Encapsulates the behaviour and hides the details. In practice: Define fileds as private and provide getter/setter methods as public.

Naming convention:
* Class and its methods -> use PascalCase
* Fields -> PascalCase when Public and camelCase with `_` as prefix whrn private
* Parameters of methods -> camelCase

* Public
* Private: Accessible only inside the class
* Protected: Accessible only inside the class and its derived classes. Breaks encapsulation b/c reveals the datails/methods to derived classes.
* Internal: Accessible only fromt he same assembly. Use for classes not its members.
* Protected Internal: Accessible only from the same assembly or any derived classes.

## Proterties

It is a class member that encapsulates a getter/setter for accessing a filed. 

Used to create a getter/setter with less code.

### Auto-implemented Property

Used for very simple methods. You do not need to declere the private method b/c the compiler creates it private when compiling.

```
public class Person
{
    private DateTime _birthday;

    // Dont require ()
    publlic Datetime BirthDay
    {
        // Logic is very simple
        get { return _birthday; } // More logic can be impleted here

        // We use value keyword for the params passed to the setter
        set { _birthday = value; }
    }
}

// auto-implemented property
public class Person
{
    // No need to declere the private field
    public DataTime Birthdate { get; set; }
}
```

## Indexes

A way to access elements in a class that represents a list of values. It is a property.

It uses a `dictionary` data type which uses a has table to store data and has a quick mechanism to look for values by its key.

```
public class HttpCookie
{
    public string this[string key]
    {
        get {...}
        set {...}
    }
}
```

## Association between classes

### Coupling

A measure of how interconnected classes and subsystems are.

### Types of relatioships

* Inheritance:

A kind of relationship between two classes that allos one to inherit code from the other. A class can have only one Parent.

Benefits: Code re-use, Polymotphic behaviour.

Problesm: Large hierarchies, Fragility, tightly coupling

```
// Inheritance syntax

public class Child : Parent
{
    ...
}
```

* Composition:

A kind of relationship between two classes that allows one to contain the other. One of the classes is a private filed contained inside teh other.

Any inheritance relationship can be translated to Composition.

Benefits: Code re-use, Flexibility and loose-coupling

# Inheritance

## Constructor Inheritance

* Base class constructors are always executed first
* Base class constructors are not inherited
* Use `base` keyword to initialize the base class constructor, it's not required when base contructor is params less

```
public class Vehicle
{
    private int _registrationNumber;
    public Vihicle(string registrationNumber)
    {
        _registrationNumber = registrationNumber
    }
}

public class Car : Vehicle
{
    public Car(string registrationNumber)
        : base(registrationNumber)
    {
        // Initialise fiels specific to the Car class
    }
}
```

## Upcasting and Downcasting

There are situations where we need to convert an objects to the base or derived reference class.

* Convertions (implicit) from a derived class to a base class (upcasting)
* Convertions (explicit) from a base class to a derived class (downcasting)
* `as` keyword used when casting objects, if it cannot be casted to that object it'll not throw an exception but will return `null`
* `is` keyword used to check the type of an object. Ex: int is float

```
public class Shape { .. }
public class Circle : Shape { ... }

// Upcasting
Circle circle = new Circle();
Shape shape = circle;

// Downcasting
Circle antoherCircle = (Circle) shape;
```

## Boxing and Unboxing

* Boxing: The process of converting a value type instance to an object reference. The object is stored in the heap memory
* Unboxing: Process of converting a reference object to a value type. The value type is stored in stack memory.
* Both boxing and unboxing have a performance penalty b/c of the extra object creation.

```
// Boxing
int number = 10;
object obj = number;

var list = new ArrayList(); // Accepts any object
list.Add(1); // Boxing performed with performance penalty
list.Add(DateTime.Now);

// Unboxing
object number = 10;
int number = (int)obj;
```

# Polymorphism

Poly (many) morphism (forms) means that a method can have many forms (overriding)

## Method overriding

Modifying the implementation of an inherited method

* Virtual: Added as method keyword in the base class to allow child classes to override the method.
* Override: Add as mehtod keyword in child class to override the mehtod.

```
public class Shape
{
    public virtual void Draw()
    {
        // Default implementation
    }
}
public class Circle : Shape
{
    public orverride void Draw()
    {
        // New implementation
    }
}
```

## Abstract Classes and Modifiers

Abstract modifier: Indicates that a class or a member is missing implementation.

If a method is declared as Abstract, then the class must be declered as abstract as well. 

```
public abstract class Shape
{
    public abstract void Draw(); // Note that we dont need {}
}
public class Circle
{
    public override void Draw()
    {
        // implementations
    }
}
```

Abstract rules:

* A method cannot include implementation
* If a member is declered as abstract, the containing class needs to be declared as abstract too
* Derived Classes must implement all abstract members in the base abstract class.
* Abstract classes cannot be instantiated

Why to use Abstract?

When you want to provide some common behaviour, wjile forcing other developers to **follow you design**

## Sealed classes and Members

Sealed Modifier: Prevents derivation of classes or overriding of methods.

```
public sealed class Circle : Shape // Class connot be derived
{
    public sealed override void Draw() // method cannot be override in child classes (when class can be derived)
    {
        Console.WriteLine("...");
    }
}
```

Why?
Sealed classes are slightly faster because of some run-time optimizations.

# Interfacec

It is a language construct that is similar to a class (in terms of syntax) but is dfundamentally different.

Interfaces do not have implementations.
They are used to build loosely-coupled applications.

```
// By convention interfaces atarts with I
public interface ITaxCalculator
{
    int Calculate(); // does not have {} and access modifiers
}
```

