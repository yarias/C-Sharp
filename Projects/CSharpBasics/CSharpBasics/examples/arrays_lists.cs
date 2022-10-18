using System;
using System.Collections.Generic;

namespace CSharpBasics.examples
{
    public class arrays_lists
    {
        public static void check_facebook_likes()
        {
            int count = 0;
            List<string> names = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter a Friend's name: ");
                String name = Console.ReadLine();

                if (!String.IsNullOrEmpty(name))
                {
                    names.Add(name);
                    count++;
                }
                else
                {
                    break;
                }

                if (count > 2)
                {
                    Console.WriteLine("{0}, {1} and {2} others like your post", names[0], names[1], (count - 2));
                }
                else if (count == 2)
                {
                    Console.WriteLine("{0} and {1} like your post", names[0], names[1]);
                }
                else if (count == 1)
                {
                    Console.WriteLine("{0} likes your post", names[0]);
                }
            }
        }

        public static void reverse_name()
        {
            Console.WriteLine("Enter a your name: ");
            String name = Console.ReadLine();

            char[] arr = new char[name.Length];
            for (int i =0; i < name.Length; i++ )
            {
                arr[i] = name[i];
            }
            Array.Reverse(arr);
            string rev_name = String.Join("", arr);
            Console.WriteLine(rev_name);
        }

        public static void sort_unique_numbers()
        {
            var list = new List<int>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter a number from 1 to 1000: ");
                int num = Convert.ToInt32(Console.ReadLine());

                if ( list.Contains(num) )
                {
                    Console.WriteLine("That number already exists. Please retry: ");
                    continue;
                }
                else
                {
                    list.Add(num);

                }

                if (list.Count == 5)
                {
                    flag = false;
                    list.Sort();
                    Console.WriteLine("The sort list of number is: ");
                    foreach (var num1 in list)
                        Console.Write(num1 + ", ");
                }
            }
        }

        public static void print_unique_numbers()
        {
            var list = new List<int>();
            while (true)
            {
                Console.WriteLine("Enter a number or Quit to exit: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("Unique numbers entered: ");
                    list = remove_duplicates(list);
                    foreach (var num in list)
                    {
                        Console.WriteLine(num);
                    }
                    break;
                }
                else
                {
                    list.Add(Convert.ToInt32(input));

                }
            }
        }

        private static List<int> remove_duplicates(List<int> list)
        {
            var new_list = new List<int>();
            foreach (var num in list)
            {
                if (!new_list.Contains(num))
                {
                    new_list.Add(num);
                }
            }
            return new_list;
        }

        public static void min_number()
        {
            while (true)
            {
                Console.WriteLine("Enter a list of 5 numbers separated by comma: ");
                var input = Console.ReadLine();

                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid List!");
                    Console.WriteLine("Please retry");
                }

                var arr = input.Split(",");
                if (arr.Length < 5)
                {
                    Console.WriteLine("Invalid List!");
                    Console.WriteLine("Please retry");
                }
                else
                {
                    int[] numbers = new int[arr.Length];
                    for (var i = 0; i < arr.Length; i++)
                    {
                        numbers[i] = Convert.ToInt32(arr[i]);

                    }
                    Array.Sort(numbers);
                    Console.WriteLine("The 3 smallest numbers are: {0}, {1}, {2}: ", numbers[0], numbers[1], numbers[2]);
                    break;
                }

            }
        }
    }
}

