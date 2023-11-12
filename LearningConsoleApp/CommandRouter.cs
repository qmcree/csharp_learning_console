using LearningConsoleApp.User;
using LearningConsoleApp.User.Model;

namespace LearningConsoleApp;

public class CommandRouter
{
    private static readonly Dictionary<int, (string description, string methodName)> CommandIdsToMethods = new()
    {
        { 1, ("Store new user", "StoreUser") },
        { 2, ("Fetch user by ID", "LoadUserById") },
        { 3, ("Fetch all users", "LoadAllUsers") }
    };

    public void Route()
    {
        var enteredCommandNumber = AskCommand();
        if (!CommandIdsToMethods.TryGetValue(enteredCommandNumber, out var mappedCommand))
            throw new Exception($"Command '{enteredCommandNumber}' is not valid.");

        var methodName = mappedCommand.methodName;
        var method = GetType().GetMethod(methodName);
        if (method is null) throw new Exception($"Method '{methodName}' is not defined.");

        method.Invoke(this, Array.Empty<object>());
    }

    private int AskCommand()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("---[ Commands ]---");
        Console.WriteLine("------------------");
        foreach (var (commandNumber, descriptionMethod) in CommandIdsToMethods)
            Console.WriteLine($"\t{commandNumber}.) {descriptionMethod.description}");

        Console.Write("What do you want to do?");
        return int.Parse(Console.ReadLine() ?? "");
    }

    public void StoreUser()
    {
        var userRepository = new UserFileRepository();
        var user = new UserInterpreter().InterpretUser();
        var outputter = new UserOutputter(user);

        switch (user)
        {
            case Administrator { FirstName: "hello" }:
                Console.WriteLine("first name is hello");
                break;

            case Administrator:
                Console.WriteLine("yippee");
                break;

            default:
                Console.WriteLine("hi");
                break;
        }

        var me = user switch
        {
            Administrator { FirstName: "hello" } bubba => bubba + "adfasd",
            Administrator bubba => bubba + "yuiepe",
            var bubba => "hi"
        };

        if (user is Administrator or Agent)
        {
        }

        userRepository.Store(user);
        outputter.WriteAll();
    }

    public void LoadUserById()
    {
        Console.Write("Enter user ID:");
        var userId = Console.ReadLine();
        if (string.IsNullOrEmpty(userId)) throw new ArgumentException("User ID must be provided.");

        var userRepository = new UserFileRepository();
        var user = userRepository.LoadById(int.Parse(userId));
        var outputter = new UserOutputter(user);

        Console.WriteLine("Fetched user.");
        outputter.WriteAll();
    }

    public void LoadAllUsers()
    {
        var userRepository = new UserFileRepository();
        var users = userRepository.LoadAll();

        Console.WriteLine("Fetched all users.");
        users.ForEach(user =>
        {
            var outputter = new UserOutputter(user);
            outputter.WriteAll();
        });
    }
}