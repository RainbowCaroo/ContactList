using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Tests;

public class UserServices_Tests
{
    [Fact]
    public void AddToListShould_AddOneCusomerToCustomerList_ThenReturnTrue()
    {
        // Arrange
        IUser user = new User { FirstName = "Caroline", LastName = "Lundkvist", PhoneNumber = "0701234567", Adress = "Ringvägen 32", Email = "caroline@domain.com" };
        IUserServices userService = new UserServices();


        //Act
        bool result = userService.AddUserToList(user);  

        //Assert
        Assert.True(result);
    }
}
