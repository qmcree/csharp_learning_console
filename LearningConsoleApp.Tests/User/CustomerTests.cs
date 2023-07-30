using LearningConsoleApp.User.Model;

namespace LearningConsoleApp.Tests.User;

public class CustomerTests
{
    [Fact]
    public void ToJson()
    {
        var customer = new Customer(
            55,
            "John",
            "Doe",
            new DateTime(1990, 9, 30),
            new[] { "Costa Rica", "San Diego" }
        );

        var expectedJson =
            """{"userId":55,"firstName":"John","lastName":"Doe","favoritePlaces":["Costa Rica","San Diego"],"birthday":"9/30/1990","eligibleBirthdayPresentCount":5,"type":"Customer","typeIsAdmin":false}""";

        Assert.Equal(expectedJson, customer.ToJson());
    }
}