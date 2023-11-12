using System.Diagnostics.CodeAnalysis;
using LearningConsoleApp.User.Model;

namespace LearningConsoleApp.User;

public class TestValidator
{
    public static bool Validate(
        [NotNullWhen(true)] IUser? user
    )
    {
        return true;
    }
}