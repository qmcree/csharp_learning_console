using System.Globalization;
using LearningConsoleApp.User.Model;

namespace LearningConsoleApp.User;

public class UserInterpreter
{
    public Model.User InterpretUser()
    {
        var userId = AskUserId();
        var (firstName, lastName) = AskName();
        var birthday = AskBirthday();
        var favoritePlaces = AskFavoritePlaces();
        var userClass = AskUserType();
        var instance = Activator.CreateInstance(userClass, userId, firstName, lastName, birthday, favoritePlaces);
        if (instance == null) throw new InvalidOperationException($"Failed to instantiate user class '{userClass}'.");

        return (Model.User)instance;
    }

    private int AskUserId()
    {
        Console.WriteLine("Enter user ID:");
        var userId = Console.ReadLine();
        if (userId == null) throw new InvalidDataException("User ID cannot be null.");

        return int.Parse(userId);
    }

    private (string, string) AskName()
    {
        Console.WriteLine("Enter first name:");
        var firstName = Console.ReadLine() ?? "";

        Console.WriteLine("Enter last name:");
        var lastName = Console.ReadLine() ?? "";
        if (new[] { firstName, lastName }.Any(string.IsNullOrWhiteSpace))
            throw new Exception("Both first name and last name must be provided.");

        return (firstName, lastName);
    }

    private DateTime AskBirthday()
    {
        const string format = "MM/dd/yyyy";
        Console.WriteLine($"Enter birthday {format.ToLower()}:");
        var birthday = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(birthday)) throw new Exception("Birthday must be provided.");

        return DateTime.ParseExact(birthday.Trim(), format, new CultureInfo("en-US"));
    }

    private string[] AskFavoritePlaces()
    {
        Console.WriteLine("What are your favorite places? (separate by comma):");
        var csv = Console.ReadLine() ?? "";

        // TODO: Should be empty if none provided.
        var places = csv.Split(',')
            // .Aggregate<string, List<string>>((acc, place) =>
            // {
            //     var trimmed = place.Trim();
            //     if (!trimmed.IsEmpty)
            //     {
            //         acc.Add(trimmed);
            //     }
            //
            //     return acc;
            // }, new List<string>())
            .Select(place => place.Trim())
            .ToArray();

        Array.Sort(places);
        return places;
    }

    private Type AskUserType()
    {
        Console.WriteLine("---[ User Types ]---");
        foreach (var (userType, classType) in UserTypeMap.Map)
            Console.WriteLine($"\t{userType.GetHashCode()}.) {userType}");

        Console.Write("Enter user type: ");
        Enum.TryParse(Console.ReadLine(), out UserType enteredUserType);
        if (!UserTypeMap.Map.TryGetValue(enteredUserType, out var userClass))
            throw new ArgumentException($"The user type '{enteredUserType}' is not valid.");

        return userClass;
    }
}