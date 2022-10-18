using System;
namespace CSharpBasics
{
    public class Person
    {
        
        public string firstName = "";
        public string LastName = "";

        public void introduce()
        {
            Console.WriteLine("Hi! My name is " + firstName + " " + LastName);
        }
    }
}

