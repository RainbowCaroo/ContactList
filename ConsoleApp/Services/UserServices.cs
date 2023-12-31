using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ConsoleApp.Services;


public class UserServices : IUserServices
{
    //Jag skrev filepath till där jag har den
    private readonly FileService _usersFile = new FileService(@"e:\School\CSharp\ContactList\users.json");
    private List<IUser> _users = [];
    
    // Detta används för att lägga till en användare i listan
    //SET
    public bool AddUserToList(IUser user)
    {   
        try
        {
            if (!_users.Any(x => x.Email == user.Email))
            {
                _users.Add(user);
                _usersFile.SaveContentToFile(JsonConvert.SerializeObject(_users));
            }

            return true;
        } 
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    //Detta gör så vi kan se alla användare i listan
    //GET
    public User GetUserFromList(string Email)
    {
        var user = _users.FirstOrDefault(x => x.Email == Email);
        return (User)(user ??= null!);
    }

    public IEnumerable<IUser> GetUsersFromList() 
    { 
        //får den inte att hämta upp filerna och vet inte riktigt varför
        try
        {
            var content = _usersFile.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _users = JsonConvert.DeserializeObject<List<IUser>>(content)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return _users; 
    }

    //Detta används för att ta bort en användare med hjälp av email
    public bool DeleteUserByEmail(string Email)
    {
        var userToDelete = _users.FirstOrDefault(x => x.Email == Email);

        if (userToDelete != null)
        {
            _users.Remove(userToDelete);
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<IUser> DeleteUsersByEmail()
    {
        return _users;
    }

}

