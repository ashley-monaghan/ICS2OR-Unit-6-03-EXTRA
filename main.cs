// Created by: Ashley Monaghan
// Created on: Nov 2022
//
//This program creats a file and updates the number presented

using System;
using System.Threading.Tasks;
using System.IO;

class Program
{
    public static async Task Main()
    {

        string userAnswer;
        int counter = 0;

        Console.WriteLine("Hello user! Would you like to quit?");
        Console.WriteLine("");

        Console.WriteLine("Enter either yes or no ");
        Console.WriteLine("");
        userAnswer = (Console.ReadLine());

        while (userAnswer == "no")
        {
            counter++;
            string text = "Total: " + counter;

            await File.WriteAllTextAsync("WriteText.txt", text);
            Console.WriteLine("File Updated...");
            Console.WriteLine("");

            var someText = await File.ReadAllTextAsync(@"WriteText.txt");
            Console.WriteLine(someText);
            Console.WriteLine("");

            Console.WriteLine("How about now? Enter either yes or no: ");
            userAnswer = (Console.ReadLine());
            Console.WriteLine("");
        };

        Console.WriteLine("Good bye!");
        Console.WriteLine("\nDone.");
    }
}