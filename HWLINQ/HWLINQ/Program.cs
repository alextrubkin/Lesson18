using System;
using System.Collections.Generic;
using System.Linq;


namespace HWLINQ
{
    class Program
    {
        public class Provider
        {
            public string Name { get; set; }
            public double Amount { get; set; }
            public DateTime Date { get; set; }

            public Provider()
            {

            }

            public Provider(string name, double amount, DateTime date)
            {
                Name = name;
                Amount = amount;
                Date = date;
            }

        }
        static void Main(string[] args)
        {
            //First, FirstOrDefault, last, LastOrDefault, Single
            // Набор целых чисел(List).Показать первый положительный и последний отрицательный
            // Расширим предыдущую задачу. Вернуть null в случае отсутствия одного из искомых элементов.
            //Есть некоторый символ и есть набор строк.Если в наборе есть один элемент начинающийся с С, то показать его.
            //Пустая строка -если таких элементов нет.Если таких строк несколько, то вернуть строку из них.
            //Усложняем задание
            //обработать ситуацию с ошибкой в предыдущем примере(когда она будет и почему)
            //Реестр символа должен быть не важен.

            List<int> intBox = new List<int>()
            {
                100,2,56,4,47,18,1,39,-96,-3,-10894
            };
           
            int firstPozitive = intBox.FirstOrDefault(x => x > 0);
            int lastNegative = intBox.LastOrDefault(x => x < 0);
            Console.WriteLine($"first pozitive element in list is {firstPozitive}\nlast negative element is {lastNegative}");
            Console.WriteLine(new string('=',75));

            List<int> intBox1 = new List<int>()
            {
                100,2,56,4,47,18,1,39
            };

            int firstPozitive1 = intBox1.FirstOrDefault(x => x > 0);
            int lastNegative1 = intBox1.LastOrDefault(x => x < 0);

            Console.WriteLine(firstPozitive1==0 ? "NULL" : firstPozitive1.ToString());
            Console.WriteLine(lastNegative1==0?"NULL":lastNegative1.ToString());
            Console.WriteLine(new string('=', 75));

            //Есть некоторый символ и есть набор строк.Если в наборе есть один элемент начинающийся с С, то показать его.
            //Пустая строка -если таких элементов нет.Если таких строк несколько, то вернуть строку из них.
            char someChar ='h';
            List<string> strBox = new List<string>()
            {
                "soup","fork","hand","plate","water", "human"
            };
            string findString = strBox.FirstOrDefault(x => x.StartsWith(someChar.ToString()));
            //Console.WriteLine(string.IsNullOrEmpty(findString)?" ":findString);
            var query = from x in strBox
                        where x.StartsWith(someChar.ToString())
                        select x;
             foreach(var item in query)
                Console.Write(item+" ");
            Console.WriteLine("\n"+new string('=', 75));
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //обработать ситуацию с ошибкой в предыдущем примере(когда она будет и почему)
            //Реестр символа должен быть не важен.
            bool b = default;
            Func<string, bool> retF = delegate (string a) { b = a.StartsWith(someChar.ToString()); return b; };
            //!!!!!как обработать, что b возвращает фолс не знаю. может нужно расширять метод First?
            //Func<string, string> retF1 = delegate (string a) { b = a.StartsWith(someChar.ToString());return b==true?"True":"flase"; };
            List<string> strBox1 = new List<string>()
            {
                // "soup","fork","hand"
            };
            string findString1 = default;
            if (strBox1.Count > 0)
            {
                if (strBox1.First(retF)==null)
                {
                    Console.WriteLine("aaa");
                }

                findString1 = strBox1.First(x => x.StartsWith(someChar.ToString()));

            }
            else
                Console.WriteLine("collection has no items!");
           
            Console.WriteLine("\n" + new string('=', 75));
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //Where, Distinct
            //Есть набор чисел.Вернем все четные, удалим повторы
            List<int> intBox2 = new List<int>()
            {
                100,4,2,56,4,47,18,4,1,39,4
            };
            
            var query2 = from x in intBox2
                         where x % 2 == 0
                         select x;
           
            foreach (var item in query2.Distinct())
                Console.WriteLine(item);
            Console.WriteLine("\n" + new string('=', 75));
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //Reverse
            //Есть число D и лист целых чисел.Найти первый элемент, больший чем D.Вернуть все четные и положительные числа, поменяв их порядок следования
            int D = 5;
            List<int> intBox3 = new List<int>()
            {
                14,5,26,3,38,9,42,1,56,7
            };

            int biggerD = intBox3.FirstOrDefault(x => x > D);
            Console.WriteLine(biggerD);
            var query3 = from x in intBox3
                         where x > 0 && x % 2 == 0
                         select x;
            foreach(var item in query3.Reverse())
                Console.Write(item+" ");
            Console.WriteLine("\n" + new string('=', 75));
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //Concat, DefaultIfEmpty
            //Есть число.Есть два листа чисел. Сделать новый лист из элементов больших чем число(из первой последовательности)
            //и элементов меньших числа(из второй). Если таких элементов нет -подставить некоторую константу.

            int number = 4;
            List<int>firstList = new List<int>()
            {
                1,2,3,4,-8,-7,6
            };

            List<int> secondList = new List<int>()
            {
                100,56,47,18,1,39
            };

            var query4 = from x in firstList
                         where x > number
                         select x;
            var query5 = from x in secondList
                         where x < number
                         select x;
            foreach( var item in query4.Concat(query5))
                Console.Write(item+" ");
            Console.WriteLine("\n" + new string('=', 75));
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //GroupBy, ToDictionary
            //Есть поставщики, и есть сумма за их поставки. Каждая поставка имеет дату.
            //{ string Name, double Amount, DateTime Date}
            //            сделать группированную коллекцию типа
            //Name(key)
            //value
            //Общая сумма поставок
            //Дата первой поставки
            //Дата последней поставки
            //Не показывать "пустых" поставщиков
            //Не показывать "пустых" поставщиков на этапе работе с исходной коллекцией
            Dictionary<string, double> allSum = new Dictionary<string, double>();
            Dictionary<string, DateTime> lastDeliveryDctnry = new Dictionary<string, DateTime>();
            Dictionary<string, DateTime> FirstDeliveryDctnry = new Dictionary<string, DateTime>();
            var providers = new List<Provider>
            {
                new Provider {Name = "Andreev", Amount= 567.00d, Date = DateTime.Parse("1/4/1992")},
                new Provider ("Andreev", 1567.00d,  DateTime.Parse("16/01/2020")),
                new Provider ("Andreev", 2567.00d, DateTime.Parse("21/11/2019")),
                new Provider("Ivanov", 987.56d, DateTime.Parse("1/4/1992")),
                new Provider("Petrov", 1987.00d, DateTime.Parse("1/4/2020")),
                new Provider("Ivanov", 2987.6d, DateTime.Parse("15/09/2019")),
                new Provider("Ivanov", 3000d, DateTime.Parse("04/04/2020")),
                new Provider("Sidorov", 2900.4d, DateTime.Parse("1/8/2019")),
                new Provider("",0d,DateTime.Parse("1/8/2019")),
                new Provider("Kozlov",0d,DateTime.Parse("10/8/2018"))                
            };

            var query6 = from x in providers
                         where (!string.IsNullOrEmpty(x.Name) && x.Amount > 0 )
                         group x by (x.Name);

            foreach (var group in query6)
            {
               
                Console.WriteLine($"\nKluch=={group.Key}");                
                double sum = 0;
                List<DateTime> dates = new List<DateTime>();
                DateTime lastDelivery = default;
                DateTime firstDalivery = default;
                foreach (var item in group)
                {
                    sum += item.Amount;
                    dates.Add(item.Date);                    
                }                          
                dates.Sort();
                firstDalivery = dates.First();
                lastDelivery = dates.Last();
                
                allSum[group.Key] = sum;
                lastDeliveryDctnry[group.Key] = lastDelivery;
                FirstDeliveryDctnry[group.Key] = firstDalivery;
                Console.WriteLine($"Last date:{lastDelivery.ToShortDateString()}, \nfirst date {firstDalivery.ToShortDateString()}");
                Console.WriteLine($"Total amount: {sum.ToString()}");
            }
            Console.WriteLine("============================End I varient========================");
             foreach(var i in allSum)
                Console.WriteLine(i+" ");

            Console.WriteLine("=======================II varient================================================");
            
            double sumAmount = 0;
            
            var query7 = from x in providers
                         where (!string.IsNullOrEmpty(x.Name) && x.Amount > 0)
                         group x by x.Name into box

                         select new { Kluch = box.Key, Group = box };
            foreach (var x in query7)
            {
                Console.WriteLine($"\n{x.Kluch}");
                var last=x.Group.OrderBy(u => u.Date).Last();
                var first = x.Group.OrderBy(u => u.Date).First();
                foreach (var item in x.Group)
                {
                    sumAmount += item.Amount;
                }
                Console.WriteLine($"SumAmount={sumAmount}");
                Console.WriteLine($"Last date {last.Date.ToShortDateString()}\nFirst date {first.Date.ToShortDateString()}");
            }
            Console.WriteLine("=====================================III varient====================================");
            var myDictionary = providers.GroupBy(x => x.Name).ToDictionary(x => x.Key, x => x.ToList());
            double amountSum = 0;
            foreach(var item in myDictionary)
            {
                if (!string.IsNullOrEmpty(item.Key) )
                {
                    Console.WriteLine("\n"+ item.Key);
                    var sortedList = myDictionary[item.Key].OrderBy(x => x.Date);
                    foreach (var i in sortedList)
                    {
                        amountSum += i.Amount;
                    }
                    Console.WriteLine($"Total sum: {amountSum}\nFirst date: {sortedList.First().Date.ToShortDateString()}\n" +
                        $"Last date: {sortedList.Last().Date.ToShortDateString()}");
                }
            }


            var query8 = (from xr in providers
                          where (!string.IsNullOrEmpty(xr.Name) && xr.Amount > 0)
                          group xr by xr.Name).ToDictionary(a => a.Key, a=>a.ToList()) ; 
                         





        }
    }

}
