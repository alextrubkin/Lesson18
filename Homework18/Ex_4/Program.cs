using System;
using System.Collections.Generic;
using System.Linq;
//Concat: объединяет две коллекции, DefaultIfEmpty
//Есть число.Есть два листа чисел.Сделать новый лист из элементов больших чем число (из первой последовательности) и элементов меньших числа(из второй). Если таких элементов нет - подставить некоторую константу.

namespace Ex_4
{
    class Program
    {
        static void Main(string[] args)
        {

            var consts = 1;

            List<int> numbers = new List<int> { -1, 2, 3, 6, -3, -6, 4 };

            List<int> numbers1 = new List<int> { 10, 20, 30, 60, 30, 60, 40 };

            var query = (from x in numbers
                         where x > consts
                         select x).DefaultIfEmpty();

            var query1 = (from x in numbers1
                          where x < consts
                          select x).DefaultIfEmpty(500);

            var plus = query.Concat(query1);
            foreach (var second in plus)
            {
                Console.WriteLine(second);
            }

            Console.ReadKey();

        }
    }
}
