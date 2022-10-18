using System;
namespace CSharpBasics.examples
{
    public class if_statements
    {
        public static void check_input_number()
        {
            Console.WriteLine("Please enter a number between 1 and 10: ");
            int input = Convert.ToInt32(Console.ReadLine());

            if (input < 1 || input > 10)
            {
                Console.WriteLine("Invalid!");
            }
            else
            {
                Console.WriteLine("Valid!");
            }

        }

        public static void print_max()
        {
            Console.WriteLine("Please enter a number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter another number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" The max value is: {0}", num1 > num2 ? num1 : num2);
        }

        public static void landscape_portrait_check()
        {
            Console.WriteLine("Please enter the image width: ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the image height: ");
            int height = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" The image is: {0}", width > height ? "landscape" : "portrait");
        }

        public static void speed_camera()
        {
            Console.WriteLine("Please enter the speed limit: ");
            int cam_speed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the speed of the car: ");
            int car_speed = Convert.ToInt32(Console.ReadLine());

            if (cam_speed > car_speed)
            {
                Console.WriteLine("OK");
            }
            else
            {
                int point = demerit_points(cam_speed, car_speed);
                if (point > 12)
                {
                    Console.WriteLine("Lincense Suspended. Demerit points {0}", point);
                }
                else
                {
                    Console.WriteLine("Demerit points: {0}", point);
                }
            }
        }

        private static int demerit_points(int speed_limit, int speed_car)
        {
            int points = 0;
            points = (int)(speed_car - speed_limit) / 5;
            return points;
        }
    }
}

