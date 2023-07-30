namespace LearningConsoleApp;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        var router = new CommandRouter();
        router.Route();
    }
}