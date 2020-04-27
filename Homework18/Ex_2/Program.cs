using System;
using System.Linq;
//Where, Distinct
//Есть набор чисел.Вернем все четные, удалим повторы

namespace Ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { -1, 2, 3, 6, -3, 6, 4 };

            var query = (from x in numbers
                         where x % 2 == 0
                         select x).Distinct();
            foreach (var number in query)
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }
    }
}
