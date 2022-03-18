//SOLID

//1. S - single responsibility

//Модель данных

DataManager manager = new DataManager();
manager.SetUsers(new AccessUserRep());


var users = manager.Users;

for (int i = 0; i < users.Users.Length; i++)
{
    Console.WriteLine($"Name = {users.Users[i]?.Name} ({users.Users[i]?.Id})");
}


public class User
{
    public int Id { get; init; }
    public string Name { get; set; } = null!;
}

//Репозиторий
public interface IUserRepository //CRUD - операции
{
    User?[] Users { get; }
    User? GetById(int id);

    void Delete(int id);
    void Update(User user);
}

//Простой тест
class Test : IUserRepository
{
    public Test()
    {
        Users = new User?[3]
        {
            new User{Id = 1, Name = "Petja"},
            new() {Id = 2, Name = "Masha"},
            new() {Id = 3, Name = "Kolja"}
        };
    }

    public User?[] Users { get; set; }
    public User? GetById(int id)
    {
        for (var i = 0; i < Users.Length; i++)
        {
            if (Users[i]?.Id == id) return Users[i];
        }

        return null;
    }

    public void Delete(int id)
    {
        for (var i = 0; i < Users.Length; i++)
        {
            if (Users[i]?.Id != id) continue;
            Users[i] = null;
            return;
        }
    }

    public void Update(User user)
    {
        for (var i = 0; i < Users.Length; i++)
        {
            if (Users[i]?.Id != user.Id) continue;
            Users[i] = user;
            return;
        }

        var buffer = new User?[Users.Length + 1];
        for (var i = 0; i < Users.Length; i++)
        {
            buffer[i] = Users[i];
        }
        buffer[^1] = user;
        Users = buffer;
    }
}

public class AccessUserRep : IUserRepository
{
    public User?[] Users { get; }

    public User GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }
}

public class DataManager
{
    public IUserRepository Users { get; private  set; }

    public void SetUsers(IUserRepository rep) => Users = rep;
}

