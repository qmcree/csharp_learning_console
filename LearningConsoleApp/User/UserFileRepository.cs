using System.Text.Json;

namespace LearningConsoleApp.User;

public class UserFileRepository
{
    private static readonly string DirectoryPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        "csharp_learning_files"
    );

    private static readonly string FilePath = Path.Combine(DirectoryPath, "users.json");

    /// <summary>
    ///     Stores a new user as JSON in the file containing all other users.
    /// </summary>
    /// <param name="user"></param>
    public void Store(Model.User user)
    {
        using var file = CreateOrLoadFile();
        var deserializedUsers = (file.Length > 0 ? JsonSerializer.Deserialize<List<object>>(file) : null) ??
                                new List<object>();
        deserializedUsers.Add(user.ToDict());

        file.SetLength(0); // Overwrite file.
        JsonSerializer.Serialize(file, deserializedUsers);
        Console.WriteLine($"Stored user to path '{file.Name}'.");
    }

    public List<Model.User> LoadAll()
    {
        throw new NotImplementedException();
    }

    public Model.User LoadById(int userId)
    {
        throw new NotImplementedException();
    }

    private FileStream CreateOrLoadFile()
    {
        if (!Directory.Exists(DirectoryPath))
        {
            Directory.CreateDirectory(DirectoryPath);
            Console.WriteLine($"Created directory '{DirectoryPath}'.");
        }

        return File.Open(FilePath, FileMode.OpenOrCreate);
    }
}