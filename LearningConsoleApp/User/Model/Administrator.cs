namespace LearningConsoleApp.User.Model;

public class Administrator : User
{
    public Administrator(int userId, string firstName, string lastName, DateTime birthday, string[] favoritePlaces) :
        base(userId, firstName, lastName, birthday, favoritePlaces)
    {
    }

    public override UserType GetUserType()
    {
        return UserType.Administrator;
    }
}