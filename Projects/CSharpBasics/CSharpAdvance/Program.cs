
// ********************   Generic  ***********************
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
        get { throw new NotImplementedException(); }
    }
}

// Constrains: To limit the generic param to certain conditions
// Interface + default constructor constraint
public class Utilities
{
    public int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    // Generic version
    public T Max<T>(T a, T b) where T : IComparable // Restric T objecto to implement IComparable interface and 
    {
        return a.CompareTo(b) > 0 ? a : b;
    }

    //Option when the class is generic: public class Utilities<T> where T : IComparable, new() //Default constructor constraint

    //public void DoSomething(Task value)
    //{
    //    var obj = new T(); // Using the default constructor constraint we can instance our T object
    //}

    //public T Max(T a, T b)
    //{
    //    return a.CompareTo(b) > 0 ? a : b;
    //}
}

// Sub-class/child Constraint
public class Product
{
    public string Title { get; set; }
    public float Price { get; set; }
}

public class Book : Product
{
    public string Isbn { get; set; }
}

public class DiscountCalculator<TProduct> where TProduct : Book
{
    public float CalculateDiscaount(TProduct product)
    {
        return product.Price; // Here we have access to Product and Book fields
    }
}

// Value Type constraint
public class Nullable<T> where T : struct // Value types connot be null, with this class give value types the avility to be null
{
    private object _value;

    public Nullable()
    {

    }

    public Nullable(T value)
    {
        _value = value;
    }

    public bool HasValue
    {
        get { return _value != null;  }
    }

    public T GetValueOrDefault()
    {
        if (HasValue)
            return (T)_value;
        return default(T); // Returns the default of the DataType
    }
}

//*****************************************************
// ******************   Delegates  ********************
public class Photo
{
    public static Photo Load(string path)
    {
        return new Photo();
    }

    public void Save()
    {

    }
}

public class PhotProcessor
{
    // An instance of PhotoFilterHandler delegate can hold a pointer to a/group of functions
    // That have same signature (void; in this e.g) and receives a Photo
    // 2.
    //public delegate void PhotoFilterHandler(Photo photo);

    // 1. It's not extensible b/c every time someone wants a new filter. We'd create the filter and recompile
    //public void Process(string path)
    //{
    //    var photo = Photo.Load(path);

    //    var filters = new PhotoFilters();
    //    filters.ApplyBrightness(photo);
    //    filters.ApplyContrast(photo);
    //    filters.Resize(photo);

    //    photo.Save();
    //}

    // 2. Using delegate created
    //public void Process(string path, PhotoFilterHandler filterHandler)
    public void Process(string path, Action<Photo> filterHandler)
    {
        var photo = Photo.Load(path);

        filterHandler(photo);
    }
}

public class PhotoFilters
{
    public void ApplyBrightness(Photo photo)
    {
        Console.WriteLine("Apply Brightness");
    }

    public void ApplyContrast(Photo photo)
    {
        Console.WriteLine("Apply Contrast");
    }

    public void Resize(Photo photo)
    {
        Console.WriteLine("Resize Photo");
    }
}

// Lambda
public class BookRepository
{
    public List<Book> GetBooks()
    {
        return new List<Book>
        {
            new Book() {Title = "Title 1", Price = 5 },
            new Book() {Title = "Title 2", Price = 7 },
            new Book() {Title = "Title 3", Price = 17 }
        };
    }
}

//*****************************************************
// ********************   Events  *********************
public class VideoEventArgs : EventArgs // Custom Args for events
{
    public Video Video { get; set; }
}

public class VideoEncoder // Publisher
{
    // Steps to follow to publlish an event
    // 1. Define a delegate
    //   .NET Framework has delegates created
    //   EventHandler
    //   EventHandler<TEventArgs>
    //public delegate void videoEncodedEventHandler(object source, EventArgs args); // By convention use object and EventArgs datatypes => Empty EventArgs
    public delegate void videoEncodedEventHandler(object source, VideoEventArgs args);
    // 2. Define an event based on that delegate
    // public event EventHandler<VideoEventArgs> VideoEncoded; // Using built-in delegates
    // public event EventHandler VideoEncoded; // Using built-in delegates without args
    public event videoEncodedEventHandler VideoEncoded; // It's a list of pointers to functions/subscribers
    // 3. Raise/send the event (Method convention: must be protected, virtual and void. naming convention prefix: On + Name of the event)
    protected virtual void OnVideoEncoded(Video video)
    {
        if (VideoEncoded != null) // Subscribers must be part of th event delegate
        {
            //VideoEncoded(this, EventArgs.Empty); // EventArgs.Empty to specify no args to send
            VideoEncoded(this, new VideoEventArgs() { Video = video }); // Send event arguments from custom class
        }
    }

    public void Encode(Video video)
    {
        Console.WriteLine("Encoding Video...");
        Thread.Sleep(3000);
        OnVideoEncoded(video); // Notifice the subscribers
    }
}

public class Video
{
    public string Title { get; set; }
}

public class MailService // Subscriber
{
    public void OnVideoEncoded(object source, VideoEventArgs e) // EventArgs was unsed when no custom args were used
    {
        Console.WriteLine("MailService: Sending an email..." + e.Video.Title);
    }
}

public class TextService // Subscriber
{
    public void OnVideoEncoded(object source, EventArgs e)
    {
        Console.WriteLine("TextService: Sending text...");
    }
}

//*****************************************************
// ***********   Extension Methods  *******************

public static class StringExtensions
{
    public static string Shorten(this String str, int numberOdWords)
    {
        if (numberOdWords < 0)
            throw new ArgumentOutOfRangeException("numberOfWords must be greater or equal to 0");
        if (numberOdWords == 0)
            return " ";

        var words = str.Split(" ");

        if (words.Length <= numberOdWords)
            return str;

        return String.Join(" ", words.Take(numberOdWords));
    
    }
}

//*****************************************************
// ********************   LINQ  ***********************
public class BookRepository1
{
    public IEnumerable<Book> GetBooks()
    {
        return new List<Book>
        {
            new Book() { Title = "Title 1", Price = 10 },
            new Book() { Title = "Title 2", Price = 9.59f },
            new Book() { Title = "Title 3", Price = 23 },
            new Book() { Title = "Title 3", Price = 2 },
            new Book() { Title = "Title 4", Price = 12.34f }
        };
    }
}

//*****************************************************
// **************  Error Hanlers  *********************

// custom exceptions
public class YouTubeException : Exception
{
    public YouTubeException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}

public class YouTubeAPI
{
    public List<Video> GetVideos(string user)
    {
    try
    {
        // Access YouTube web services
        // Read the data
        // Create a list of video objects
        throw new Exception("OOps some low level exception");
    }
    catch (Exception ex)
    {
        // log
        throw new YouTubeException("Could not fetch the Video", ex); // We pass inner Exception ex for troubleshooting
    }
    return new List<Video>();
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
            // Generic
            var list = new GenericList<int>();
            list.Add(10);

            var dict = new GenericDictionary<string, int[]>();
            dict.Add("1234", new int[] { 1, 2, 3, 4, 5 });

            // Generic Value Type constraint
            var number = new Nullable<int>(5);
            Console.WriteLine("Has Value? " + number.HasValue);
            Console.WriteLine("Vallue: " + number.GetValueOrDefault());

            var number1 = new Nullable<int>();
            Console.WriteLine("Has Value? " + number1.HasValue);
            Console.WriteLine("Vallue: " + number1.GetValueOrDefault());

            // Delegates
            var process = new PhotProcessor();
            var filter = new PhotoFilters();

            //PhotProcessor.PhotoFilterHandler filterHandler = filter.ApplyBrightness; // Note we pass a pointer to the function
            Action<Photo> filterHandler = filter.ApplyBrightness;
            filterHandler += filter.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;

            process.Process("photo.jpg", filterHandler);

            // Lambda
            const int factor = 5;
            Func<int, int> multipler = n => n * factor;
            var result = multipler(10);
            Console.WriteLine(result);

            var books = new BookRepository().GetBooks();
            //var cheapBooks = books.FindAll(PredicateIsCheaperThan10Dollars);
            var cheapBooks = books.FindAll(book => book.Price < 10);
            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }

            // Events
            var video = new Video() { Title = "Video 1"};
            var encoder = new VideoEncoder(); // Publisher
            var mailService = new MailService(); // Subscriber
            var textService = new TextService(); // Subscriber

            encoder.VideoEncoded += mailService.OnVideoEncoded; // Add the subscriber
            encoder.VideoEncoded += textService.OnVideoEncoded; // Add the subscriber
            encoder.Encode(video);

            // Extension mehtods
            string post = "This is a very very very very very very looooooooooooong text...";
            var shortenPost = post.Shorten(5);
            Console.WriteLine(shortenPost);

            // LINQ
            var books2 = new BookRepository1().GetBooks();

            // LINQ Query Operators: Always start with from and ends with select
            var cheapbooks1 =
                from b in books2
                where b.Price < 10
                orderby b.Title
                select b.Title;

            // LINQ Extension mehotds
            //.select() is used for transformations/projections. eg transform to another data type 
            var cheapbooks2 = books2
                .Where(b => b.Price < 10)
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            foreach (var b in cheapBooks)
            {
                Console.WriteLine(b);
            }

            var singleBook = books2.Single(b => b.Title == "Title 2"); // SingleOrDefault() used to avoid exeptions when no single findings
            Console.WriteLine(singleBook.Title);

            var firstBook = books2.FirstOrDefault(b => b.Title == "Title 3");
            var lastBook = books2.LastOrDefault(b => b.Title == "Title 3");
            Console.WriteLine(firstBook.Title + " " + firstBook.Price);
            Console.WriteLine(lastBook.Title + " " + lastBook.Price);

            var pageeBooks = books2.Skip(2).Take(2);
            foreach (var b in pageeBooks)
            {
                Console.WriteLine("ofset books: " + b.Title);
            }

            var maxPrice = books2.Max(b => b.Price);
            Console.WriteLine(maxPrice);

            var totalPrice = books2.Sum(b => b.Price);
            Console.WriteLine(totalPrice);

            // Nullable Types
            DateTime? date = null; // Alternatice syntax Nulable<DataTime> date = null;

            Console.WriteLine("GetValueOrDefault(): " + date.GetValueOrDefault());
            Console.WriteLine("hasValue(): " + date.HasValue);

            DateTime date2 = date.GetValueOrDefault(); // Method must be used because nulable variable cannot be assigned to a non-nulable one

            // Null Coalescing Operator
            //if (date != null)
            //    date2 = date.GetValueOrDefault();
            //else
            //    date2 = DateTime.Today;

            date2 = date ?? DateTime.Today;

            // Dynamic typing
            dynamic name = "Juan";
            name = 10;
            Console.WriteLine("dynamic name: " + name);

            dynamic x = 10;
            dynamic y = 5;
            var z = x + y; // c will be dynamic type

            // Exception Handler
            //StreamReader streamer = null; // With using keyword this line is not required
            try
            {
                using ( var streamer = new StreamReader("/file.zip"))
                {
                    var content = streamer.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, unexpected error occoured");
            }
            //finally   // With using keyword this dispose block is not required
            //{
            //    if (streamer != null)
            //        streamer.Dispose();
            //}

            try
            {
                var api = new YouTubeAPI();
                var videos = api.GetVideos("C#");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // Delegate section
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveRedEye");
        }

        // Lambda section
        static bool PredicateIsCheaperThan10Dollars(Book book)
        {
            return book.Price < 10;
        }
    }
}
