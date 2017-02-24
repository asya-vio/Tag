using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Program
    {

        static void Main()
        {
            Game Game1 = null;

            try
            {
                Game1 = new Game(0, 1, 2, 3, 4, 5, 6, -7, 8);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Incorrect arguments");
                Console.ReadLine();
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Incorrect value of arguments");
                Console.ReadLine();
                return;
            }


            Game1.PrintBoard();

            Game1.Shift(4);

            Game1.PrintBoard();    
        }
    }
}
