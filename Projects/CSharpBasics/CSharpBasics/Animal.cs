using System;
namespace CSharpBasics
{
    public interface Animal
    {
        public void hablar();
    }

    public class Perro: Animal
    {
        public void hablar()
        {
            Console.WriteLine("Guau Guau!");
        }
    }
    public class Gato : Animal
    {
        public void hablar()
        {
            Console.WriteLine("Miau Miau!");
        }
    }
}

