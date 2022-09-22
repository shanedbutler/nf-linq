using System;
using System.Collections.Generic;
using System.Linq;

namespace linqd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Restriction/Filtering Operations:\n");

            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            // Find the words in the fruits collection that start with the letter 'L'
            List<string> filteredFruits = FilterByFirstLetter(fruits, "L");
            Console.WriteLine("Filtered by my own method:");
            foreach (string fruit in filteredFruits)
            {
                Console.WriteLine(fruit);
            }

            // Find the words in the fruits collection that start with the letter 'L' (linq query)
            IEnumerable<string> results = from fruit in fruits
                                          where fruit.StartsWith("L")
                                          select fruit;

            Console.WriteLine("\nFiltered with LINQ query:");
            foreach (string result in results)
            {
                Console.WriteLine(result);
            }

            List<int> numbers = new List<int>() {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

            // Display numbers that are multiples of 4 or 6
            IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0);
            Console.WriteLine("\nThe following numbers are multiples of four or six:");
            foreach (int number in fourSixMultiples)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nOrdering Operations:");

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            // Order names in descending order. ASK: What is the explicit type of descendingNames var? (linq method)
            IEnumerable<string> descendingNames = names.OrderByDescending(n => n);
            Console.WriteLine("\nStrings sorted in descending order:");
            foreach (string name in descendingNames)
            {
                Console.WriteLine(name);
            }

            // Build a collection of our numbers list sorted in ascending order (linq query)
            IEnumerable<int> descendingNumbers = from number in numbers
                                    orderby number ascending
                                    select number;
            Console.WriteLine("\nNumbers sorted in ascending order:");
            foreach (int number in descendingNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nAggregate Operations:\n");
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            //Using a method count
            Console.WriteLine($"We've made {purchases.Count} sales");

            // How much money have we made?
            double earnings = Math.Round(purchases.Sum(), 2);
            Console.WriteLine($"Totaling in ${earnings}");

            // Print the highest price sale
            double highestPurchase = Math.Round(purchases.Max(), 2);
            Console.WriteLine($"Our highest priced sale was for ${highestPurchase}");

            Console.WriteLine("\nPartitioning Operations\n");

            List<int> numbers2 = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            IEnumerable<int> perfectSquares = from number in numbers2
                                 where (Math.Sqrt(number) % 1  == 0)
                                 select number;
            Console.WriteLine($"The numbers II list has {perfectSquares.Count()} perfect squares: ");
            foreach (var number in perfectSquares)
            {
            Console.WriteLine(number);
            }
        }
        //Method to filter strings in collection by their first letter
        public static List<string> FilterByFirstLetter(List<string> collection, string letter)
        {
            return collection.FindAll(item => item.StartsWith(letter));
        }
    }
}
