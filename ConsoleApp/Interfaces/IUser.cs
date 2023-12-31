namespace ConsoleApp.Interfaces;

public interface IUser
{
    string FirstName { get; set; } 
    string LastName { get; set; } 
    string FullName => $"{FirstName} {LastName}";
    string PhoneNumber { get; set; } 
    string Email { get; set; } 
    string Adress { get; set; }
}
