namespace LearningConsoleApp.User.Model;

public class Agent : User
{
    public Agent(int userId, string firstName, string lastName, DateTime birthday, string[] favoritePlaces) : base(
        userId, firstName, lastName, birthday, favoritePlaces)
    {
    }

    public override UserType GetUserType()
    {
        return UserType.Agent;
    }
}