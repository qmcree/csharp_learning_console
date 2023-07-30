namespace LearningConsoleApp.User;

internal class UserOutputter
{
    private readonly Model.User _user;

    public UserOutputter(Model.User user)
    {
        _user = user;
    }

    public void WriteAll()
    {
        WriteName();
        WriteBirthday();
        WriteAge();
        WriteJson();
    }

    private void WriteBirthday()
    {
        var birthday = _user.Birthday;
        if (birthday.Year == 1992) Console.Beep();

        var birthdayDaysAgo = (DateTime.Now - birthday).Days;
        Console.WriteLine($"Your birthday is {birthday:D}, which was {birthdayDaysAgo:N0} days ago.");
    }

    private void WriteName()
    {
        Console.WriteLine($"Your name is {_user.FirstName} {_user.LastName}");
    }

    private void WriteAge()
    {
        var age = DateTime.Today.Year - _user.Birthday.Year;
        Console.WriteLine($"You are {age} years old.");
    }

    private void WriteJson()
    {
        Console.WriteLine(_user.ToJson());
    }
}