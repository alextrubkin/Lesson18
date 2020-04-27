using System;
using System.Collections.Generic;
using System.Linq;
//GroupBy, ToDictionary
//Есть поставщики, и есть сумма за их поставки.Каждая поставка имеет дату.
//{string Name, double Amount, DateTime Date }
//сделать группированную коллекцию типа
//Name(key)
//value
//Общая сумма поставок
//Дата первой поставки
//Дата последней поставки
//Не показывать "пустых" поставщиков
//Не показывать "пустых" поставщиков на этапе работе с исходной коллекцией


namespace Ex_5
{
    public class Group
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var groups = new List<Group>
            {
                new Group
                {
                    Name = "Ivan",
                    Amount = 9400,
                    Date = DateTime.Parse("1/4/1992")
                },
                new Group
                {
                    Name = "Petr",
                    Amount = 1200,
                    Date = DateTime.Parse("12/3/1985")
                },
                new Group
                {
                    Name = "",
                    Amount = 0,
                    Date = DateTime.Parse("12/3/1985")
                }
            };

            var query = groups.Where(i => !string.IsNullOrWhiteSpace(i.Name)).GroupBy(i => i.Name);

            var res = from x in query
                      let total = new
                      {
                          Name = x.Key,
                          Amount = x.Sum(i => i.Amount),
                          First = x.Max(i => i.Date),
                          Last = x.Min(i => i.Date)
                      }
                      select total;
            var dictionary = res.ToDictionary(i => i.Name);

            foreach (var i in res)
            {
                Console.WriteLine($"Name: {i.Name}, Amount: {i.Amount}, First: {i.First}, Last: {i.Last}");

            }

            Console.ReadKey();

        }
    }
}
