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
                Game1 = new Game(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15);
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

            Console.WriteLine("В ячейке 3 : 3 фишка {0} ", Game1.Indexer(3, 3));
            int I, J;
            Game1.GetLocation(15, out I, out J);
            Console.WriteLine("Фишка 15 в положении {0} : {1}", I, J);

            Game1.Shift(15);

            Game1.PrintBoard();
            Console.WriteLine("В ячейке 3 : 3 фишка {0} ",Game1.Indexer(3, 3));

            Game1.GetLocation(15, out I, out J);

            Console.WriteLine("Фишка 15 в положении {0} : {1}", I, J);





        }
    }
}
