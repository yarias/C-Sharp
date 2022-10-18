using System;
namespace CSharpBasics.examples
{
    public class iterations_statements
    {
        public static void nums_divisible_by_3()
        {
            int count = 0;
            for (var i = 1; i <= 100; i++)
            {
                if (i%3 == 0)
                {
                    count++;
                }
            }
            Console.WriteLine("Numbers divisible by 3 between 1 and 100: {0}", count);
        }

        public static void sum_nums()
        {
            int result = 0;

            while (true)
            {
                Console.WriteLine("Enter a number or OK to exit: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "ok")
                {
                    break;
                }
                else
                {
                    result += Convert.ToInt32(input);
                }
            }
            Console.WriteLine("The sum for previous numbers is: {0}", result);
        }

        public static void factorial()
        {
            Console.WriteLine("Enter a number to calculate the factorial: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int result = num;

            if (num == 0)
            {
                Console.WriteLine("The factolrial of {0} is: ", 1);
            }
            else
            {
                for (var i = num; i > 1; --i)
                {
                    result *= (i - 1);
                    Console.WriteLine("Operations result {0}", result);
                }
                Console.WriteLine("The factorial of {0} is {1}", num, result);
            }
        }

        public static void guess_number()
        {
            Random num = new Random();
            int secret = num.Next(1, 10);
            Console.WriteLine("Secret: {0}", secret);
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter your guess number: ");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == secret)
                {
                    Console.WriteLine("You Won");
                    break;
                }
                continue;
            }
        }

        public static void pick_max()
        {
            Console.WriteLine("Enter a list of numbers separated by comma (,): ");
            string list = Console.ReadLine();
            string[] new_list = list.Split(",");

            int max = Convert.ToInt32(new_list[0]);

            foreach (var number in new_list)
            {
                int num = Convert.ToInt32(number);
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine("The max number from the list is {0}", max);
        }
    }
}

