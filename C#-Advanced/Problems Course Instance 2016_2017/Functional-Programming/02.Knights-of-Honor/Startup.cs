using System;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


        Action<string> print = message => Console.WriteLine($"Sir {message}");

        foreach (var name in input)
        {
            print(name);
        }
    }
}