using System;
using System.Text;

namespace CSharpBasics.examples
{
    public class text_examples
    {
        public static void check_consecutive_nums()
        {
            Console.WriteLine("Please enter a list of numbers separated by '-': ");
            var input = Console.ReadLine().Split('-');
            var nums = new List<int>();
            bool is_desc;
            bool not_consecutive = false;
            string order = "";

            foreach (var n in input)
            {
                nums.Add(Convert.ToInt32(n));
            }
            is_desc = nums[0] > nums[1];

            for (var i = 0; i < nums.Count - 1; i++)
            {
                if ((nums[i] - 1) == nums[i + 1] && is_desc)
                {
                    order = "Desc";
                }
                else if ((nums[i] + 1) == nums[i + 1] && !is_desc)
                {
                    order = "Asc";
                }
                else
                {
                    Console.WriteLine("Not Consecutive!");
                    not_consecutive = true;
                    break;
                }
            }
            var result = not_consecutive ? "" : String.Format("Consecutive ({0})", order);
            Console.WriteLine(result);
        }

        public static void check_duplicates()
        {
            Console.WriteLine("Please enter a list of numbers separated by '-': ");
            var input = Console.ReadLine();
            var nums = new List<int>();
            bool is_duplicate = false;

            if (!String.IsNullOrEmpty(input))
            {
                var list_str = input.Split('-');
                foreach (var n in list_str)
                {
                    var num = Convert.ToInt32(n);
                    if (nums.Count > 0 && nums.Contains(num))
                    {
                        is_duplicate = true;
                        break;
                    }
                    nums.Add(num);
                }
                var result = is_duplicate ? "Duplicate!" : "No Duplicates!";
                Console.WriteLine(result);
            }
        }

        public static void check_24_format()
        {
            Console.WriteLine("Please enter a time value in 24-hour format: ");
            var input = Console.ReadLine();

            if (!String.IsNullOrEmpty(input))
            {
                var hour = Convert.ToInt32(input.Split(":")[0]);
                var minutes = Convert.ToInt32(input.Split(":")[1]);

                if ( 00 < hour  && hour < 23 && 00 < minutes && minutes < 59)
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("Invalid!");
                }
            }
            else
            {
                Console.WriteLine("Invalid!");
            }
        }

        public static void pascal_case_converter()
        {
            Console.WriteLine("Please enter few word separated by commas (,): ");
            var input = Console.ReadLine().ToUpper().Split(" ");
            var result = "";
            var builder = new StringBuilder();

            foreach (var word in input)
                result += word[0] + word.Substring(1).ToLower();
            Console.WriteLine(result);
        }

        public static void vowel_count()
        {
            Console.WriteLine("Please enter a word): ");
            var input = Console.ReadLine();
            char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
            int count = 0;

            foreach (char letter in input.ToLower())
            {
                if (vowels.Contains(letter))
                    count++;
            }
            Console.WriteLine("Number of vowels in word {0} is: {1}", input, count);
        }
    }
}

