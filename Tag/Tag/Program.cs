using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Program
    {

        static void Main(string[] args)
        {
            Game Game1 = null;
            int step = 0;

            try
            {
                Game1 = new Game(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Некорректные аругменты, остановка игры - {0}", ex.Message);
                Console.ReadLine();
                return;
            }

            while (!Game1.IsEnd())
            {
                Console.Clear();
                Game1.PrintBoard();
                Console.WriteLine("Ведите номер сдвигаемой фишки");
                int value = int.Parse(Console.ReadLine());

                try
                {
                    Game1.Shift(value);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                step++;
            }

            Console.Clear();
            Game1.PrintBoard();

            Console.WriteLine("Игра завершена за {0} шагов", step);
            Console.ReadLine();
           

        }
    }
}
