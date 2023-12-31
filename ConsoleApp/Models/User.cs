using ConsoleApp.Interfaces;

namespace ConsoleApp.Models;

public class User : IUser
{

    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName => $"{FirstName} {LastName}";
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Adress { get; set; } = null!;

}
