using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Program
    {
        public static void PrintBoard(Game g)
        {
            for (int i = 0; i < g.boardSize; i++)
            {
                for (int j = 0; j < g.boardSize; j++)
                {
                    if (g[i, j] / 10 > 0) Console.Write("{0} ", g[i, j]);
                    else Console.Write("{0}  ", g[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
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
                Console.WriteLine("Остановка игры - {0}", ex.Message);
                Console.ReadLine();
                return;
            }

            while (!Game1.IsEnd())
            {
                Console.Clear();
                PrintBoard(Game1);
                Console.WriteLine("Ведите номер сдвигаемой фишки");
                int value = int.Parse(Console.ReadLine());

                try
                {
                    Game1.Shift(value);
                    step++;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("{0}", ex.Message);
                    Console.ReadLine();
                }

            }

            Console.Clear();
            PrintBoard(Game1);

            Console.WriteLine("Игра завершена за {0} шагов", step);
            Console.ReadLine();

            Console.WriteLine("Координаты фишки 15 I = {0}, J = {1} \n", Game1.GetLocation(15).I, Game1.GetLocation(15).J);


            Game g = Game.ReadCSV(@"L:\ИИТ\ООП\Git\Tag\Tag\file.csv");
            PrintBoard(g);
            Console.ReadLine();
        }
    }
}
