using System;
using System.Collections.Generic;
using System.Threading;

namespace KidsLearningSystem
{
    class Program
    {
        static List<string> fruits = new List<string>
        {
            "Apple", "Banana", "Orange", "Grapes", "Strawberry", "Mango", "Watermelon", "Pineapple", "Cherry", "Kiwi"
        };

        static List<string> days = new List<string>
        {
            "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
        };

        static List<string> months = new List<string>
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        };

        static Dictionary<string, string> wordsDictionary = new Dictionary<string, string>
        {
            { "Apple", "A fruit with red or green skin and white flesh." },
            { "Banana", "A long curved fruit that is yellow when ripe." },
            { "Orange", "A round fruit with orange skin that you peel to eat." },
            { "Grapes", "Small, round fruit that grows in bunches." },
            { "Mango", "A sweet tropical fruit with a thick skin and orange flesh." }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("---------------------Welcome to Learning------------------");

            Thread daysThread = new Thread(DisplayDays);
            daysThread.Start();
            daysThread.Join(); // Wait for days to finish before proceeding

            Thread.Sleep(5000); // Wait for 5 seconds

            Thread monthsThread = new Thread(DisplayMonths);
            monthsThread.Start();
            monthsThread.Join(); // Wait for months to finish before proceeding

            Thread.Sleep(5000); // Wait for 5 seconds

            Thread fruitsThread = new Thread(DisplayFruits);
            fruitsThread.Start();
            Thread wordsThread = new Thread(DisplayWords);
            wordsThread.Start();

            fruitsThread.Join(); // Wait for fruits to finish before proceeding
            wordsThread.Join(); // Wait for words to finish before ending the program
        }

        static void DisplayDays()
        {
            foreach (var day in days)
            {
                Console.WriteLine("Day: " + day);
                Thread.Sleep(2000); // Wait for 2 seconds
            }
        }

        static void DisplayMonths()
        {
            foreach (var month in months)
            {
                Console.WriteLine("Month: " + month);
                Thread.Sleep(2000); // Wait for 2 seconds
            }
        }

        static void DisplayFruits()
        {
            foreach (var fruit in fruits)
            {
                Console.WriteLine("Fruit: " + fruit);
                Thread.Sleep(1000); // Wait for 1 second (simultaneous display with words)
            }
        }

        static void DisplayWords()
        {
            foreach (var word in wordsDictionary)
            {
                Console.WriteLine("Word: " + word.Key);
                Console.WriteLine("Meaning: " + word.Value);
                Thread.Sleep(1000); // Wait for 1 second (simultaneous display with fruits)
            }
        }
    }
}