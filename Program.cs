using System;
using System.Collections.Generic;
using System.Linq;

namespace linqd
{
    class Program
    {
        static void Main(string[] args)
        {
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


        }
        //Method to filter strings in collection by their first letter
        public static List<string> FilterByFirstLetter(List<string> collection, string letter)
        {
            return collection.FindAll(item => item.StartsWith(letter));
        }
    }
}
