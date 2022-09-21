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
            var descendingNames = names.OrderByDescending(n => n);
            Console.WriteLine("\nStrings sorted in descending order:");
            foreach (var name in descendingNames)
            {
                Console.WriteLine(name);
            }

            // Build a collection of these numbers sorted in ascending order (linq query)
            List<int> numbers2 = new List<int>() {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};
            var descendingNumbers = from number in numbers
                                     orderby number ascending
                                     select number; 
            Console.WriteLine("\nNumbers sorted in ascending order:");
            foreach (var number in descendingNumbers)
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
