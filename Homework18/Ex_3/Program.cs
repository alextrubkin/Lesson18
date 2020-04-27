using System;
using System.Linq;
//Reverse: располагает элементы в обратном порядке
//Есть число D и лист целых чисел.Найти первый элемент, больший чем D.
//Вернуть все четные и положительные числа, поменяв их порядок следования
namespace Ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var D = 2;
            int[] numbers = { -1, 2, 3, 6, -3, -6, 4 };


            var query = (from x in numbers
                         where x > D
                         select x).First();

            Console.WriteLine(query);
            Console.WriteLine(new string('-', 50));

            var query1 = (from x in numbers
                          where x % 2 == 0 && x > 0
                          select x).Reverse();

            foreach (var all in query1)
            {
                Console.WriteLine(all);
            }

            Console.ReadKey();
        }
    }
}
