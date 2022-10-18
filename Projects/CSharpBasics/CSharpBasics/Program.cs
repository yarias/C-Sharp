/*
 With .NET 6.0+ it is not required to specify the class Program and Main method
b/c The compiler synthesizes a Program class with a Main method and places all
your top level statements in that Main method.

using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
 */

using CSharpBasics.Math;
using CSharpBasics; //Allows to use .cs classes, enums, etc under CsharpBasics folder
using CSharpBasics.examples;
using System;
using System.Text;

// ********************   Classes  *********************

var jonh = new Person();
jonh.firstName = "Jonh";
jonh.LastName = "Smith";
jonh.introduce();

Calculator calculator = new Calculator();
var result = calculator.Add(1, 2);
Console.WriteLine(result);

//******************************************************
// ********************   Enums  ***********************

var method = shippingMethod.Express;
Console.WriteLine(method); // Prints the enum key
Console.WriteLine(method.ToString()); // Same as above. CW calls insternally .ToStrong()
Console.WriteLine((int)method); // Prints the enum value

var methodId = 3;
Console.WriteLine((shippingMethod)methodId); // Cast the integer to the enum key


var methodName = "Express";
var shippingMethodNew = (shippingMethod)Enum.Parse(typeof(shippingMethod), methodName); // Cast string into a Enum
Console.WriteLine((int)shippingMethodNew);

Perro perro = new Perro();

void hablando(Animal animal)
{
    animal.hablar();
}
hablando(perro);

//***************************************************************
// ********************   if/else - loops ***********************


if_statements.check_input_number();
if_statements.print_max();
if_statements.landscape_portrait_check();
if_statements.speed_camera();


iterations_statements.nums_divisible_by_3();
iterations_statements.sum_nums();
iterations_statements.factorial();
iterations_statements.guess_number();
iterations_statements.pick_max();

//*******************************************************
// ********************   Arrays  ***********************

var matrix = new int[3] { 11, 3, 2 };
Console.WriteLine(matrix.Length);

var index = Array.IndexOf(matrix, 3);
Console.WriteLine(index);

Console.WriteLine("Effect of Clear()");
Array.Clear(matrix, 0, 1);
foreach (int num in matrix)
{
    Console.WriteLine(num);
}

Console.WriteLine("Effect of Copy()");
int[] another = new int[3];
Array.Copy(matrix, another, 3);
foreach (int num in another)
{
    Console.WriteLine(num);
}

Console.WriteLine("Effect of sort()");
Array.Sort(another);
foreach (int num in another)
{
    Console.WriteLine(num);
}

Console.WriteLine("Effect of reverse()");
Array.Reverse(another);
foreach (int num in another)
{
    Console.WriteLine(num);
}

//******************************************************
// ********************   Lists  ***********************

var numbers = new List<int>() { 1, 2, 3, 4 };
numbers.Add(11);
numbers.AddRange(new int[4] { 6, 7, 8, 11 });
foreach (var num in numbers)
    Console.WriteLine(num);

Console.WriteLine("Index of 11: {0}", numbers.IndexOf(11));
Console.WriteLine("Last Index of 11: {0}", numbers.LastIndexOf(11));

Console.WriteLine("Number of elemments {0}", numbers.Count);

Console.WriteLine("Effect of remove an element");
numbers.Remove(11);
foreach (var num in numbers)
    Console.WriteLine(num);

numbers.Clear();
Console.WriteLine("Number of elemments {0}", numbers.Count);


arrays_lists.check_facebook_likes();
arrays_lists.reverse_name();
arrays_lists.sort_unique_numbers();
arrays_lists.print_unique_numbers();
arrays_lists.min_number();

//******************************************************
// ********************   Dates  ***********************

var datetime = new DateTime(2019, 10, 10);
var now = DateTime.Now;
var today = DateTime.Today;

Console.WriteLine("Hour: " + now.Hour);
Console.WriteLine("Minute: " + now.Minute);

var tomorrow = now.AddDays(1);
var yesterday = now.AddDays(-1);

Console.WriteLine(now.ToLongDateString());
Console.WriteLine(now.ToShortDateString());
Console.WriteLine(now.ToLongTimeString());
Console.WriteLine(now.ToShortTimeString());
Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm"));

// TimeSpan -> time intervals
var time_span = new TimeSpan(1, 2, 60);

var time_span1 = new TimeSpan(1, 0, 0);
var time_span2 = TimeSpan.FromHours(1);

var start = DateTime.Now;
var end = DateTime.Now.AddMinutes(2);
var duration = end - start;
Console.WriteLine("Duratino: " + duration);

// Properties
Console.WriteLine("Minutes: " + time_span.Minutes);
Console.WriteLine("Total Minutes: " + time_span.TotalMinutes);

Console.WriteLine("Add example: " + time_span.Add(TimeSpan.FromMinutes(8)));
Console.WriteLine("Subtract example: " + time_span.Subtract(TimeSpan.FromMinutes(2)));

// ToString
Console.WriteLine("ToString: " + time_span.ToString());

// Parse
Console.WriteLine("Parse: " + TimeSpan.Parse("01:03:59"));

//******************************************************
// *******************  Strings  ***********************

var fullName = "Juan Arce ";
Console.WriteLine("Trim: '{0}'", fullName.Trim());
Console.WriteLine("ToUpper: " + fullName.Trim().ToUpper());

Console.WriteLine("First Name: {0}", fullName.Substring(0, fullName.IndexOf(" ")));
Console.WriteLine("Last Name: {0}", fullName.Substring(fullName.IndexOf(" ") + 1));

var names = fullName.Split();
Console.WriteLine("First Name: {0}", names[0]);
Console.WriteLine("Last Name: {0}", names[1]);

Console.WriteLine(fullName.Replace("Juan", "Miguel"));

float price = 29.95f;
Console.WriteLine("The price is: {0}", price.ToString("C")); // C0: No decimal points. C1: 1 decimal point

var text = "This is going to be a really really really really really really really really really really long text.";

const int maxLength = 19;
if (text.Length < maxLength)
{
    Console.WriteLine(text);
}
else
{
    var words = text.Split(" ");
    var totalChars = 0;
    var summaryWords = new List<string>();

    foreach (var word in words)
    {
        totalChars += word.Length + 1;

        if (totalChars > maxLength)
        {
            break;
        }
        summaryWords.Add(word);
    }
    Console.WriteLine(String.Join(" ", summaryWords) + "...");
}

var builder = new StringBuilder();

//builder.Append('-', 10);
//builder.AppendLine();
//builder.Append("Header");
//builder.AppendLine();
//builder.Append('-', 10);

//builder.Replace('-', '+');
//builder.Remove(0, 8);
//builder.Insert(0, new string('-', 8));

// Alternative as stringBuilder methods returns values
builder
    .Append('-', 10)
    .AppendLine()
    .Append("Header")
    .AppendLine()
    .Append('-', 10)
    .Replace('-', '+')
    .Remove(0, 8)
    .Insert(0, new string('-', 8));
Console.WriteLine(builder);

text_examples.check_consecutive_nums();
text_examples.check_duplicates();
text_examples.check_24_format();
text_examples.pascal_case_converter();
text_examples.vowel_count();

//****************************************************
// *******************  Files  ***********************

var path = "/Users/yermi/Downloads/Dummy-1_APPROVAL_POLICIES_PAGE_09232022184459.png";

File.Copy(path, "/Users/yermi/Downloads/copy_from_c_sharp.png", true);
Console.WriteLine(File.Exists("/Users/yermi/Downloads/copy_from_c_sharp.png"));
File.Delete("/Users/yermi/Downloads/copy_from_c_sharp.png");

var file = new FileInfo(path);
file.CopyTo("/Users/yermi/Downloads/copy_from_c_sharp.png", true);
Console.WriteLine(file.Exists);

Directory.CreateDirectory("/Users/yermi/Downloads/c_sharp_test");
var files = Directory.GetFiles("/Users/yermi/Downloads/", "*.png", SearchOption.AllDirectories);
Console.WriteLine(files.Length);
foreach (var f in files)
    Console.WriteLine(f);

Console.WriteLine("Extension: " + Path.GetExtension(path));
Console.WriteLine("File name: " + Path.GetFileName(path));
Console.WriteLine("Directory name: " + Path.GetDirectoryName(path));

files.count_words();
files.find_largest_word();