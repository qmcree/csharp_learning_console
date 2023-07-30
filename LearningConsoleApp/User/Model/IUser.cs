namespace LearningConsoleApp.User.Model;

public interface IUser
{
    UserType GetUserType();
    string ToJson();
}