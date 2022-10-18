using System;
namespace CSharpBasics.examples
{
    public class files
    {
        public static void count_words()
        {
            string path = "/Users/yermi/Downloads/c_sharp.txt";
            var content = File.ReadAllLines(path);
            int count = 0;

            foreach (var line in content)
            {
                Console.WriteLine(line);
                count += line.Split(" ").Length;
            }
            Console.WriteLine(count);
        }

        public static void find_largest_word()
        {
            string path = "/Users/yermi/Downloads/c_sharp.txt";
            var content = File.ReadAllLines(path);
            string largest = "";

            foreach (var line in content)
            {
                foreach (var word in line.Split(" "))
                {
                    if (largest.Length < word.Length)
                    {
                        largest = word;
                    }
                }
            }
            Console.WriteLine(largest);
        }
    }
}

