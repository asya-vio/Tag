using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Program
    {
        static int Main()
        {
            int counter = 0;
            Console.WriteLine("Input size of the game");

            try
            {
                counter = int.Parse(Console.ReadLine());
                if (counter < 0) throw new ArgumentException();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("It's not a positive number\n");
                return Main();
            }
            catch (FormatException)
            {
                Console.WriteLine("It's not a number\n");
                return Main();
            }



            return 0;      
        }
    }
}
