using System;
using System.Linq;

namespace Ex_1
{

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { -1, -2, -3, -4, -3 };

            var queryFirst = (from x in numbers
                              where x > 0
                              select x).FirstOrDefault();

            var queryLast = (from y in numbers
                             where y < 0
                             select y).LastOrDefault();

            Console.WriteLine($"First: {queryFirst}, Last: {queryLast}");

            Console.WriteLine(new string('-', 50));

            var c = 'C';
            string[] query = new[] { "Count", "Hi", "Can" };
            string[] query1 = null;
            var res = " ";



            var queryString = query.Where(i => i.StartsWith(c.ToString())).SelectMany(i => i + res);

            Console.WriteLine(new string(queryString.ToArray()));


            Console.WriteLine(new string('-', 50));



            try
            {
                res = query1.FirstOrDefault(i => i.StartsWith(c));
                Console.WriteLine(res);


            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Collection not initialized");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Not results");
            }

            Console.ReadKey();
        }
    }
}
