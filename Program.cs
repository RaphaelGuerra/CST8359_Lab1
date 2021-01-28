using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        public static int input;
        public static IList<string> words = new List<string>();
        static void Main(string[] args)
        {
            bool loop = true;
            do
            {
                Console.WriteLine("Hello World!!! My First C# App");
                Console.WriteLine("Options\n----------");
                Console.WriteLine("1 - Import Words From File" +
                    "\n2 - Bubble Sort words" +
                    "\n3 - LINQ/Lambda sort words" +
                    "\n4 - Count the Distinct Words" +
                    "\n5 - Take the first 10 words" +
                    "\n6 - Get the number of words that start with 'j' and display the count" +
                    "\n7 - Get and display of words that end with 'd' and display the count" +
                    "\n8 - Get and display of words that are greater than 4 characters long, and display the count" +
                    "\n9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count" +
                    "\nx – Exit\n");
                Console.WriteLine("Make a selection: ");
                string userIn = Console.ReadLine();
                Console.Clear();
                switch (userIn)
                {
                    case "1": GetFile(words); break;
                    case "2": BubbleSort(words); break;
                    case "3": LinqSort(); break;
                    case "4": CountDistinctWords(); break;
                    case "5": TakeFirst10Words(); break;
                    case "6": GetJWords(); break;
                    case "7": GetDisplayDWords(); break;
                    case "8": GetDisplayMoreThan4CharWords(); break;
                    case "9": GetDisplayLessThan3CharWords(); break;
                    case "x": loop = false; break;
                    default: Console.WriteLine("Invalid input"); break;
                }
                Console.WriteLine();
            } while (loop);
        }
        public static void GetFile(IList<string> words)
        {
            string line;
            input = 0;
            Console.WriteLine("Reading Words");
            try
            {
                using (StreamReader readFile = new StreamReader("Words.txt"))
                {
                    while ((line = readFile.ReadLine()) != null)
                    {
                        words.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid file");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Reading Words complete");
            Console.WriteLine("Number of words found: " + words.Count() + "\n");
        }
        public static IList<string> BubbleSort(IList<string> words)
        {
            var tempListA = words.ToList();
            int x = tempListA.Count();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            var swapped = true;
            try
            {
                while (swapped)
                {
                    swapped = false;
                    for (var i = 0; i < x - 1; i++)
                    {
                        var l = tempListA[i];
                        var r = tempListA[i + 1];
                        if (l.CompareTo(r) > 0)
                        {
                            var ListB = tempListA[i];
                            tempListA[i] = tempListA[i + 1];
                            tempListA[i + 1] = ListB;
                            swapped = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Not able to sort");
                Console.WriteLine(e.Message);
            }
            timer.Stop();
            TimeSpan sec = timer.Elapsed;
            Console.Write("Time elasped: " + sec.Milliseconds + " ms" + "\n\n");
            return tempListA;
        }
        public static void LinqSort()
        {
            Stopwatch sec = new Stopwatch();
            sec.Start();
            var s = from element in words orderby element.ToString() select element;
            foreach (var i in s)
            sec.Stop();
            TimeSpan time = sec.Elapsed;
            Console.Write("Time elapsed: " + time.Milliseconds + " ms" + "\n\n");

        }
        public static void CountDistinctWords()
        {
            var t = words.Count();
            t = 0;
            var s = words.Distinct();
            foreach (var i in s)
            {
                t++;
            }
            Console.Write("The number of distinct words is: " + t + "\n\n");
        }
        public static void TakeFirst10Words()
        {
            var s = words.Take(10);
            foreach (var i in s)
            {
                Console.WriteLine(i);
            }
        }
        public static void GetJWords()
        {
            var t = words.Count();
            t = 0;
            var s = from words in words where words.StartsWith("j") select words;
            foreach (var i in s)
            {
                t++;
                Console.WriteLine(i);
            }
            Console.Write("Number of words that start with 'j': " + t + "\n\n");
        }
        public static void GetDisplayDWords()
        {
            var t = words.Count();
            t = 0;
            var s = from words in words where words.EndsWith("d") select words;
            foreach (var i in s)
            {
                t++;
                Console.WriteLine(i);
            }
            Console.Write("Number of words that end with 'd': " + t + "\n\n");
        }
        public static void GetDisplayMoreThan4CharWords()
        {
            var t = words.Count();
            t = 0;
            var s = from words in words where words.Length > 4 select words;
            foreach (var i in s)
            {
                t++;
                Console.WriteLine(i);
            }
            Console.Write("Number of words longer than 4 characters:" + t + "\n\n");
        }
        public static void GetDisplayLessThan3CharWords()
        {
            var t = words.Count();
            t = 0;
            var s = from words in words where words.StartsWith("a") && words.Length < 3 select words;
            foreach (var i in s)
            {
                t++;
                Console.WriteLine(i);
            }
            Console.Write("Number of words longer less than 3 characters and start with 'a': " + t + "\n\n");
        }
    }
}