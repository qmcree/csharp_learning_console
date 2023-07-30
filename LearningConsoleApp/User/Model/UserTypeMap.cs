namespace LearningConsoleApp.User.Model;

public class UserTypeMap
{
    public static Dictionary<UserType, Type> Map = new()
    {
        { UserType.Customer, typeof(Customer) },
        { UserType.Agent, typeof(Agent) },
        { UserType.Administrator, typeof(Administrator) }
    };
}