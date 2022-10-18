using CSharpIntermidiate.class_examples;
using CSharpIntermidiate.inheritance_examples;
using CSharpIntermidiate.polymorphism_examples;
using CSharpIntermidiate.interface_examples;
using AmazonLib; // Need to add as a project reference 
using System.Net.NetworkInformation;

//********************************************************
// ********************   Classes  ***********************
// They should be in a separated file.

// Access Modifiers
public class Person
{
    private string _name;
    private DateTime _birthday;

    public void Introduce(string to)
    {
        Console.WriteLine("Hi {0}, I am {1}", to, _name);
    }

    public void SetBirthday(DateTime birthday)
    {
        _birthday = birthday;
    }

    public DateTime GetBithday()
    {
        return this._birthday;
    }

    public static Person Parse(string str)
    {
        var person = new Person();
        person._name = str;
        return person;
    }
}

// Constructors Overloading
public class Customer
{
    public int Id;
    public string Name;
    public List<string> Orders; 

    public Customer()
    {
        // best practice is to always initialize the List of objects to something
        // if not that field will be null and it is set by default by the compiler to null
        this.Orders = new List<string>();
    }

    public Customer(int id)
        : this() // Use to call default contructor before. Note () is empty, but can be use to call other constructors
    {
        this.Id = id;

    }

    public Customer(int id, string name)
        : this(id) // Use `this` this way is not a best practice b/c you are linking diferent constructors and it is not maintainable 
    {
        this.Name = name;

    }
}

// Methods Overloading
public class Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public void Move(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public void Move(Point newLocation)
    {
        // Defensive Programming
        if (newLocation == null)
            throw new ArgumentException("newLocation");

        // Best practice: to avoid code duplication we should call the other method here
        this.Move(newLocation.X, newLocation.Y); // can be call without this. as well
        //this.X = newLocation.X;
        //this.Y = newLocation.Y;
    }
}

// Params Modifier
public class Calculator
{
    public int Add(params int[] numbers)
    {
        var sum = 0;
        foreach (var num in numbers)
            sum += num;
        return sum;
    }
}


// Fields
public class Customer1
{
    public int Id;
    public string Name;
    public readonly List<string> Orders = new List<string>(); // Initialize in declaration instead of havig a constructor for it.

    public Customer1(int id)
    {
        this.Id = id;

    }

    public Customer1(int id, string name)
        : this(id) // Use `this` this way is not a best practice b/c you are linking diferent constructors and it is not maintainable 
    {
        this.Name = name;

    }
    public void Promote()
    {
        // Below line throws an error b/c it's a readonly filed that cannot be reassinged
        //Orders = new List<string>();
    }
}

// Properties
public class Person1
{
    // Properties must be pplace at the top of the class
    //Auto-implemented Property
    public DateTime Birthdate { private set; get; } // To not have a setter, then need to initialize it in a constructor
    public string Name { get; set; } // Shortcut : prop tab

    public Person1(DateTime birthdate)
    {
        this.Birthdate = birthdate;
    }
    
    // Property
    public int Age
    {
        // Only get b/c it's calculated and dont want to have a setter
        get
        {
            var timeSpan = DateTime.Today - Birthdate;
            var years = timeSpan.Days / 365;
            return years;
        }
    } 
}

// Indexes
public class HttpCookie
{
    private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();
    public DateTime Expire { get; set; }

    // indexer
    public string this[string key]
    {
        get { return _dictionary[key]; }
        set
        {
            _dictionary[key] = value; // Value represents the value at the rigth side of the assigment operator
        }
    }

    public void SetItem(string key, string value)
    {
        _dictionary[key] = value;
    }

    public string GetItem(string key)
    {
        return _dictionary[key];
    }
}

// Inheritance
public class PresentationObject
{
    public int Width { get; set; }
    public int Height { get; set; }

    public void copy()
    {
        Console.WriteLine("Object copied.");
    }

    public void duplicate()
    {
        Console.WriteLine("Object duplicated.");
    }
}

public class Text : PresentationObject
{
    public int FontSize { get; set; }
    public string FontName { get; set; }

    public void AddHyperLink(string url)
    {
        Console.WriteLine("We added a link to " + url);
    }
}

// Composition
public class Logger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class DbMigrator
{
    private readonly Logger _logger;

    public DbMigrator(Logger logger)
    {
        _logger = logger;
    }

    public void Migrate()
    {
        _logger.Log("We are migrating ...");
    }
}

public class Installer
{
    private readonly Logger _logger;

    public Installer(Logger logger)
    {
        _logger = logger;
    }

    public void Install()
    {
        _logger.Log("We are installing the application");
    }
}

// Inheritance and Constructors
public class Vehicle
{
    private readonly string registrationNumber;

    public Vehicle()
    {
        Console.WriteLine("Vehicle initialized!");
    }

    public Vehicle(string registrationNumber)
    {
        this.registrationNumber = registrationNumber;
        Console.WriteLine("Vehicle initialized {0}!", registrationNumber);
    }

}

public class Car : Vehicle
{
    public Car(string registrationNumber) // Vehicle constructor is executed first
        : base(registrationNumber)
    {
        Console.WriteLine("Car initialized! {0}", registrationNumber);
    }
}

// Polimorphism and Abstract classes
public abstract class Shape
{
    public int Width { get; set; }
    public int Height { get; set; }
    public Position Position { get; set; }

    //public virtual void Draw() // IF derived class do not implement it, then there's an issue.
    //{

    //}
    public abstract void Draw(); // Abstract force child classes to implement this method.

    public void Copy()
    {
        Console.WriteLine("Copy shape into clipboard!");
    }
}

public class Position
{

}

public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Draw a Circle!");
    }
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Draw a Rectangle!");
    }
}

public class Canvas
{
    public void DrawShapes(List<Shape> shapes)
    {
        foreach ( var shape in shapes)
        {
            shape.Draw();
        }
    }
}

// Interfaces: Extensibility
public interface ILogger
{
    void LogError(string message);
    void LogInfo(string message);
}

public class ConsoleLogger : ILogger
{
    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
    }

    public void LogInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
    }
}

public class FileLogger : ILogger
{
    private readonly string _path;

    public FileLogger(string path)
    {
        _path = path;
    }

    public void LogError(string message)
    {
        Log("ERROR", message); //Better option is to use Enum
    }

    public void LogInfo(string message)
    {
        Log("INFO", message);
    }

    private void Log(string messageType, string message)
    {
        // Using is a context manages that will dispose the file if there's errors 
        using (var streamWriter = new StreamWriter(_path, true))
        {
            streamWriter.WriteLine(messageType + ": " + message);
        }
    }
}

public class DbMigrator1
{
    private readonly ILogger _logger;

    public DbMigrator1(ILogger logger) // Dependency injections: Pass the dependencies in the constructor
    {
        _logger = logger;
    }

    public void Migrate()
    {
        _logger.LogInfo("Migration started at {0}" + DateTime.Now);
        //Implementation
        _logger.LogInfo("Migration finished at {0}" + DateTime.Now);
    }
}



//*****************************************************
// ********************   Main  ***********************

namespace CSharpIntermidiate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Class with private access modifiers
            var person = Person.Parse("Jonh");
            person.Introduce("Juan");
            person.SetBirthday(new DateTime(1998, 06, 09));
            Console.WriteLine("Birthday: {0}", person.GetBithday());

            // Constructor Overloading
            var customer = new Customer(1, "Miguel");
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);

            //Method overloading
            UsePoints();

            //Param Modifier
            var calculator = new Calculator();
            Console.WriteLine(calculator.Add(11, 11));
            Console.WriteLine(calculator.Add(11, 11, 10, 1, 2, 3));
            Console.WriteLine(calculator.Add(new int[] {1, 2 ,3, 4, 5}));

            //Out Modifier
            int number;
            var result = int.TryParse("abc", out number);
            if (result)
                Console.WriteLine(number);
            else
                Console.WriteLine("Convertion Failed!");

            // Fileds
            var customer1 = new Customer1(11);
            customer1.Orders.Add("ASA092D");
            customer1.Orders.Add("KAS12KS");

            Console.WriteLine(customer1.Orders.Count);

            // Properties
            var person1 = new Person1(new DateTime(1982, 1, 1));
            //person1.Birthdate = new DateTime(1982, 1, 1); // Dont work b/c set is private
            Console.WriteLine("Age: {0}", person1.Age);

            // Indexers
            var cookie = new HttpCookie();
            cookie["name"] = "Juan";
            cookie.SetItem("lastName", "Arce");
            Console.WriteLine(cookie["name"]);
            Console.WriteLine(cookie.GetItem("lastName"));

            // Class examples
            var stopwatch = new StopWatch();
            stopwatch.start();
            Thread.Sleep(2000);
            Console.WriteLine(stopwatch.stop());
            stopwatch.start();
            Thread.Sleep(1000);
            Console.WriteLine(stopwatch.stop());

            var post = new Post("This is the title", "Example of C3 post class");
            Console.WriteLine(post.Title);
            Console.WriteLine(post.Description);
            Console.WriteLine(post.Datetime);
            Console.WriteLine(post._vote);

            post.IncreaseVote();
            post.DecreaseVote();
            post.IncreaseVote();
            post.IncreaseVote();

            // Use setters to update title and description
            post.Title = "THIS IS THE NEW TITLE";
            post.Description = "Updating the description";

            Console.WriteLine(post.Title);
            Console.WriteLine(post.Description);
            Console.WriteLine(post.Datetime);
            Console.WriteLine(post._vote);

            // Inheritance
            var text = new Text();
            text.copy();

            // Composition
            var migration = new DbMigrator(new Logger());

            var logger = new Logger();
            var installer = new Installer(logger);

            migration.Migrate();
            installer.Install();

            // Internal Access Modifier
            var internalCustomer = new CustmerDiffAsembly();
            //AmazonLib.RateCalculator(); // Does not work because it is internal for AmazonLib only use

            // Inheritance and Constructors
            var car = new Car("XAS231");

            // Inheritance examples
            var stack = new Stack();

            stack.Push(1);
            stack.Push("Hello World!");
            stack.Push(new int[] { 11, 23, 4});

            stack.Clear();

            stack.Push("Hello World!");
            stack.Push(new int[] { 11, 23, 4 });
            stack.Push(11);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());

            // Polymorphism
            var shapes = new List<Shape>();
            shapes.Add(new Circle());
            shapes.Add(new Rectangle());

            var canvas = new Canvas();
            canvas.DrawShapes(shapes);

            // Polymorphism examples
            var sql_connection = new SqlConnection("//sqlServer:connection");
            sql_connection.Open();
            sql_connection.Close();

            var oracle_conn = new OravleConnection("//oracle:connection");
            oracle_conn.Open();
            oracle_conn.Close();

            var sql_command = new DbCommand(sql_connection, "SELECT * FROM SQL_table1");
            sql_command.Execute();

            var oracle_command = new DbCommand(oracle_conn, "SELECT * FROM Oracle_table1");
            oracle_command.Execute();

            // Interfaces testability
            var orderProcessor = new OrderProcessor(new ShippingCalculator());
            var order = new Order { DatePlaced = DateTime.Now, TotalPrice = 100f };
            orderProcessor.Process(order);

            // Interfaces extensibility
            var dbMigrator1 = new DbMigrator1(new ConsoleLogger());
            dbMigrator1.Migrate();

            var dbMigrator2 = new DbMigrator1(new FileLogger("c_log.txt"));
            dbMigrator2.Migrate();

            // Interface examples
            var workflow = new Workflow(new List<IActivity> { new UploadVideoToCloud(), new CallWebServiceEncode() } );
            workflow.Add(new SendEmailNotification());
            workflow.Add(new ChangeVideoStatusInDB());

            var engine = new WorkflowEngine(workflow);
            engine.Run();
        }

        public static void UsePoints()
        {
            //Method overloading
            var point = new Point(15, 30);
            point.Move(60, 90);
            Console.WriteLine("New location ({0}, {1})", point.X, point.Y);
            point.Move(new Point(100, 120));
            Console.WriteLine("New location ({0}, {1})", point.X, point.Y);
            try
            {
                point.Move(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exceptions has occured: {0}", ex);
            }
        }
    }
}