// See https://aka.ms/new-console-template for more information
using CodingExercises;

while (true)
{
    Console.WriteLine("Enter the excercise no you want to execute: (Enter 'Q' to exit)");

    string? input = Console.ReadLine();
    int number;

    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Invalid input, try again!");
        continue;
    }
    else if (input.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
        break;
    else if (int.TryParse(input, out number))
    {
        Execute(number);
    }
    else {
        Console.WriteLine("Invalid input, try again!");
        continue;
    }
}

static void Execute(int number)
{
    switch (number)
    {
        case 1: 
            {
                string input = "hello world from c#";
                string output = _01_ReverseWordInSentence.ReverseWords(input);
                Console.WriteLine(output);
            }
        _: return;
    }
}