using Twitter.BL.Objects.Responses;
using Twitter.Dal;

namespace Twitter.BL.Services.Interfaces
{
    public interface ITwitterBlService
    {
        LoginResponse Login(string emaill, string password);

        Users CreateAccount(string firstName, string lastName, string emaill, string password);

        Users EditUser(int userID, string firstName, string lastName, string password);
    }
}
