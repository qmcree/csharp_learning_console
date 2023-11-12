namespace LearningConsoleApp.User.Model;

public class MyTest
{
    public required IUser User { get; init; }
    private string? _test;

    public string Name
    {
        get => "hi";
        set
        {
            Console.WriteLine("hello");
            _test = value;
        }
    }

    public void Deconstruct(out UserType userType, out string json)
    {
        userType = User.GetUserType();
        json = User.ToJson();
    }
}

// public class UserList
// {
//     private readonly IUser[] _users;
//
//     // Read-only indexer.
//     public IUser this[int index] => _users[index];
//
//     // Read/write indexer.
//     public IUser this[int index]
//     {
//         get => _users[index];
//         set => _users[index] = value;
//     }
//
//     public UserList(IEnumerable<IUser> users)
//     {
//         _users = users.ToArray();
//
//         Index start = 0;
//         Index end = 0;
//         Range range = ..;
//         var start2 = 0;
//         var range2 = start2..;
//     }
// }
//
// // Able to read like a normal array.
// var userList = new UserList(new[] { new Customer() });
// var user = userList[0];