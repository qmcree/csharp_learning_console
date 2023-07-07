using System.Globalization;
using static System.String;

(string, string) AskName()
{
    Console.WriteLine("Enter first name:");
    var firstName = Console.ReadLine() ?? "";

    Console.WriteLine("Enter last name:");
    var lastName = Console.ReadLine() ?? "";
    if (new[] { firstName, lastName }.Any(IsNullOrWhiteSpace))
    {
        throw new Exception("Both first name and last name must be provided.");
    }

    return (firstName, lastName);
}

void WriteName(string firstName, string lastName, int age)
{
    Console.WriteLine($"Your name is {firstName} {lastName}.");
    Console.WriteLine($"You are {age} years old.");
}

DateTime AskBirthday()
{
    const string format = "mm/dd/yyyy";
    Console.WriteLine($"Enter birthday {format}:");
    var birthday = Console.ReadLine();
    if (IsNullOrWhiteSpace(birthday))
    {
        // TODO: Better exception for this?
        throw new Exception("Birthday must be provided.");
    }

    return DateTime.ParseExact(birthday.Trim(), format, new CultureInfo("en-US"));
}

void WriteBirthday(DateTime birthday)
{
    if (birthday.Year == 1992)
    {
        Console.Beep();
    }

    var birthdayDaysAgo = (DateTime.Now - birthday).Days;
    Console.WriteLine($"Your birthday is {birthday:D}, which was {birthdayDaysAgo:N0} days ago.");
}

void EchoNameAge()
{
    var (firstName, lastName) = AskName();
    WriteName(firstName, lastName, 31);
}

void EchoBirthday()
{
    WriteBirthday(AskBirthday());
}

int AskPath()
{
    Console.WriteLine("Enter path to take (1 or 2):");
    var path = int.Parse(Console.ReadLine() ?? "");
    if (!new[] { 1, 2 }.Contains(path))
    {
        throw new Exception("Path must be 1 or 2.");
    }

    return path;
}

Action decisionFunction = AskPath() == 1 ? EchoNameAge : EchoBirthday;
decisionFunction();