using System.Globalization;
using System.Text;

namespace LearningConsoleApp;

internal class Program
{
    public static void Main(string[] args)
    {
        var myString = "Hello this is a test.";
        for (var i = 0; i < myString.Length; i++)
            Console.WriteLine(myString[i]);

        var pallets = new[] { "B14", "A54", "C23" };
        Array.Resize(ref pallets, 5);
        Array.Resize(ref pallets, 2);
        Array.Clear(pallets);
        var c = new string(new[] { 'A', 'B' });
        Console.WriteLine(c);
        foreach (var pallet in pallets)
            Console.WriteLine($"Value={pallet} IsNull={(pallet == null ? "Yes" : "No")}");

        Console.WriteLine(
            ReverseEachWord("The quick brown fox jumps over the lazy dog")
        );

        var price = 4.7m;
        Console.WriteLine($"The price is {price:C} (en-US)");

        var europeanCulture = CultureInfo.GetCultureInfo("fr-FR");
        Console.WriteLine(
            string.Create(europeanCulture, $"The price is {price:C} (fr-FR)")
        );

        Console.WriteLine(
            string.Create(CultureInfo.GetCultureInfo("en-CA"), $"The number is {2500:N0} (en-CA)")
        );

        foreach (var a in "hi".Reverse())
            Console.WriteLine(a);

        Console.WriteLine(
            string.Join(Environment.NewLine, FindInsideBoundaries(
                "Hello you (I am well in { my test } case you wanted to know)? Well hello (yes haiti). Do you [like] bread?",
                new Dictionary<char, char> { { '(', ')' }, { '{', '}' }, { '[', ']' } }
            ))
        );

        var test = new[,] { { "Hi", "Hello" }, { "Foo", "Bar " } };
        Console.WriteLine(test[0, 1]);

        try
        {
            var zero = 0;
            Console.WriteLine(1 / zero);
        }
        catch (DivideByZeroException de)
        {
            throw new DivideByZeroException("test", de);
        }

        // var router = new CommandRouter();
        // router.Route();
    }

    private static string ReverseEachWord(string sentence)
    {
        var words = sentence.Split(' ')
            .Select(word => string.Join(null, word.Reverse()));
        return string.Join(' ', words);
    }

    private static IEnumerable<string> FindInsideBoundaries(string sentence,
        Dictionary<char, char>? openingToClosing = null)
    {
        openingToClosing ??= new Dictionary<char, char> { { '(', ')' } };
        char? closingSymbol = null;
        var wordsInside = new List<StringBuilder>();
        foreach (var character in sentence)
            if (closingSymbol != null)
            {
                if (character == closingSymbol)
                {
                    closingSymbol = null;
                    continue;
                }

                wordsInside[^1].Append(character);
            }
            else if (openingToClosing.TryGetValue(character, out var nextClosingSymbol))
            {
                closingSymbol = nextClosingSymbol;
                wordsInside.Add(new StringBuilder());
            }

        return wordsInside.Select(str => str.ToString());
    }
}