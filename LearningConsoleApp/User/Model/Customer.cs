namespace LearningConsoleApp.User.Model;

public class Customer : User
{
    public Customer(int userId, string firstName, string lastName, DateTime birthday, string[] favoritePlaces) : base(
        userId, firstName, lastName, birthday, favoritePlaces)
    {
    }

    public override UserType GetUserType()
    {
        return UserType.Customer;
    }

    public override int GetEligibleBirthdayPresents()
    {
        return base.GetEligibleBirthdayPresents() * 5;
    }
}