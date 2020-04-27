using System;
using System.Linq;

namespace Homework18
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { -1, -2, -3, -4, -3 };

            // Построить запрос.
            var queryFirst = (from x in numbers
                        where x>0
                        select x).FirstOrDefault();

            var queryLast = (from y in numbers
                         where y < 0
                         select y).LastOrDefault();

            Console.WriteLine($"First: {queryFirst}, Last: {queryLast}");
            Console.WriteLine(new string('-',50));

            //var c = "C";
            //string[] query ={"Count cross perimeter", "Hi people", "Can i help you?" };

            //string queryString = from x in query
            //                     where x.TakeWhile(x.Contains(c, x))
            //                      orderby x
            //                  select x;
            //foreach(var q in query)
            //{
            //    Console.WriteLine(q);
            //}

            // Delay.
            Console.ReadKey();
        }
    }
}
