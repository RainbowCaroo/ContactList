using ConsoleApp.Models;

namespace ConsoleApp.Services;

public class MenuService
{
    

    private readonly UserServices _userServices = new UserServices();

    //Detta är olika typer av metoder för att visa menyer

    public void ShowMainMenu()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("----- MENU -----");
            Console.WriteLine();
            Console.WriteLine("1. Lägg till en användare");
            Console.WriteLine("2. Visa alla användare");
            Console.WriteLine("3. Visa mer info om alla användare");
            Console.WriteLine("4. Ta bort en användare");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddMenu();
                    break;

                case "2":
                    ShowMenu();
                    break;

                case "3":
                    ShowAllMenu();
                    break;

                case "4":
                    DeleteUser();
                    break;
            }

            Console.ReadKey();
        }
    }


    //method för att lägga till en användare
    private void AddMenu()
    {
        var user = new User();



        Console.Clear();
        Console.Write("Ange förnamn: ");
        user.FirstName = Console.ReadLine()!;

        Console.Write("Ange efternamn: ");
        user.LastName = Console.ReadLine()!;

        Console.Write("Ange ditt telefonnummer: ");
        user.PhoneNumber = Console.ReadLine()!;

        Console.Write("Ange email: ");
        user.Email = Console.ReadLine()!;

        Console.Write("Ange din adress: ");
        user.Adress = Console.ReadLine()!;

        _userServices.AddUserToList(user);
    }


    //method för att se enkel info om alla användare
    private void ShowMenu()
    {
        var users = _userServices.GetUsersFromList();

        Console.Clear();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FullName}");
            Console.WriteLine("--------------------------------");
        }
    }

    //method för att se all info om alla användare
    private void ShowAllMenu()
    {      
        var users = _userServices.GetUsersFromList();

        Console.Clear();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FullName}, {user.PhoneNumber}");
            Console.WriteLine($"{user.Adress}");
            Console.WriteLine($"<{user.Email}>");
            Console.WriteLine("--------------------------------");
        }
    }

    //method för att ta bort en användare med hjälp av email
    private void DeleteUser()
    {
        var users = _userServices.DeleteUsersByEmail();

        Console.Clear();
        Console.Write("Skriv email på användaren du vill ta bort: ");
        string emailToDelete = Console.ReadLine()!;

        bool userDeleted = _userServices.DeleteUserByEmail(emailToDelete);

        if (userDeleted)
        {
            Console.WriteLine($"Användaren med email {emailToDelete} har tagits bort.");
        }
        else
        {
            Console.WriteLine($"Användaren med email {emailToDelete} kunde inte hittas.");
        }

    }
}
