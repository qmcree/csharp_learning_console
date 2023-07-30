using System.Text.Json;

namespace LearningConsoleApp.User.Model;

public abstract class User : IUser
{
    private readonly int _userId;
    private readonly DateTime _birthday;

    protected User(int userId, string firstName, string lastName, DateTime birthday, string[] favoritePlaces)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        FavoritePlaces = favoritePlaces;
    }

    public int UserId
    {
        get => _userId;
        private init
        {
            if (value <= 0) throw new InvalidDataException("User ID must be greater than 0.");

            _userId = value;
        }
    }

    public DateTime Birthday
    {
        get => _birthday;
        private init
        {
            if (value > DateTime.Today) throw new InvalidDataException("Birthday cannot be before today.");

            _birthday = value;
        }
    }

    public string FirstName { get; }

    public string LastName { get; }

    public string[] FavoritePlaces { get; }

    public abstract UserType GetUserType();

    public virtual int GetEligibleBirthdayPresents()
    {
        return 1;
    }

    public Dictionary<string, object> ToDict()
    {
        return new Dictionary<string, object>
        {
            ["userId"] = UserId,
            ["firstName"] = FirstName,
            ["lastName"] = LastName,
            ["favoritePlaces"] = FavoritePlaces,
            ["birthday"] = $"{Birthday:d}",
            ["eligibleBirthdayPresentCount"] = GetEligibleBirthdayPresents(),
            ["type"] = GetUserType().ToString(),
            ["typeIsAdmin"] = GetUserType() == UserType.Administrator
        };
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(ToDict());
    }
}