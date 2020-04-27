using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_18
{
    public class Program
    {
        public class Provider
        {
            public string Name;
            public double Amount;


            public Provider(string name, double amount, DateTime date)
            {
                Name = name;
                Amount = amount;
                Date = date;
            }


            public DateTime Date { get; set; }
        }

        static void Main(string[] args)
        {
            List<int> numbersList = new List<int> { 3, 12, -5, 65, 12, 212, -45, 6, 8 };
            Console.Write("Num collection: ");
            numbersList.ForEach(i => Console.Write($"<{i}> "));
            Console.WriteLine();
            Console.WriteLine("First positive number:");
            Console.WriteLine(numbersList.First(i => i > 0));
            Console.WriteLine("Last negative number:");
            Console.WriteLine(numbersList.Last(i => i < 0));
            Console.WriteLine(new string('-', 20));


            Console.Write("Num collection: ");
            List<int> numbersList2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            numbersList2.ForEach(i => Console.Write($"<{i}> "));
            Console.WriteLine();
            Console.WriteLine("Null or negative number:");
            Console.Write(numbersList2.FirstOrDefault(i => i < 0).Equals(null) ? "null (?), no number" : $"{numbersList2.FirstOrDefault(i => i < 0)}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));


            Console.Write("String collection: ");
            var stringList = new List<string> { "citrus", "apple", "lime", "cinnamon" };
            var searchChar = 't';
            stringList.ForEach(i => Console.Write($"<{i}> "));
            Console.WriteLine();
            Console.WriteLine($"Searched first symbol: {searchChar}");
            Console.WriteLine("Result: " + string.Join(" ", stringList.Where(i => i.First().Equals(searchChar)).ToArray()));
            Console.WriteLine(new string('-', 20));


            Console.Write("Num collection: ");
            List<int> numbersList3 = new List<int> { 1, 2, 3, 4, 4, 6, 6, 8, 9 };
            numbersList3.ForEach(i => Console.Write($"<{i}> "));
            Console.WriteLine();
            Console.WriteLine("All even, non distinct numbers: {0}", string.Join(" ", numbersList3.Where(i => i % 2 == 0).Distinct().ToArray()));
            Console.WriteLine(new string('-', 20));


            Console.Write("Num collection: ");
            List<int> numbersList4 = new List<int> { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            var specInt = 1;
            numbersList4.ForEach(i => Console.Write($"<{i}> "));
            Console.WriteLine();
            Console.WriteLine("First positive even: {0}", numbersList4.First(i => i > specInt && i % 2 == 0));
            Console.WriteLine("Reversed positive even array: {0}", string.Join(" ", numbersList4.Where(i => i > 0 && i % 2 == 0).Reverse().ToArray()));
            Console.WriteLine(new string('-', 20));


            Console.Write("Num collection #1: ");
            List<int> numbersList5 = new List<int> { 20, 30, 40, 50 };
            numbersList5.ForEach(i => Console.Write($"<{i}> "));

            Console.Write("\nNum collection #2: ");
            List<int> numbersList6 = new List<int> { 11, 22, 33, 44 };
            numbersList6.ForEach(i => Console.Write($"<{i}> "));

            int specNumber = 10;
            int defaultConst = 777;
            Console.WriteLine($"\nCentral number: {specNumber}");

            List<int> resultList = numbersList5.Where(i => i > specNumber).DefaultIfEmpty(defaultConst).Concat(numbersList6.Where(i => i < specNumber).DefaultIfEmpty(defaultConst)).ToList();
            Console.Write("Concatinated lists:");
            resultList.ForEach(i => Console.Write($"<{i}> "));
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));


            Console.WriteLine("\nTask with provider's list:");
            var deliveries = new List<Provider>
            {
                new Provider ("Ivan",10,DateTime.Parse("30/10/89")),
                new Provider ("Ivan",10,DateTime.Parse("04/11/88")),
                new Provider ("Ivan",15,DateTime.Parse("16/09/66")),
                new Provider ("Adam",12,DateTime.Parse("21/03/92")),
                new Provider ("Boris",0,DateTime.Parse("17/05/95"))
            };

            var query = from Provider in deliveries
                        where Provider.Amount > 0
                        group Provider by Provider.Name
                        into providerList
                        select new
                        {
                            name = providerList.Key,
                            balance = providerList.Sum(i => i.Amount),
                            firstDate = providerList.Min(i => i.Date),
                            lastDate = providerList.Max(i => i.Date)
                        };

            foreach (var provider in query)
            {
                Console.WriteLine($"Provider {provider.name}: \n" +
                                  $"Amount: {provider.balance}, " +
                                  $"first delivery: {DataFormating(provider.firstDate) }, " +
                                  $"last delivery: {DataFormating(provider.lastDate)}.");
            }

            Console.ReadKey();
        }


        public static string DataFormating(DateTime date)
        {
            return date.GetDateTimeFormats()[0];
        }
    }
}
