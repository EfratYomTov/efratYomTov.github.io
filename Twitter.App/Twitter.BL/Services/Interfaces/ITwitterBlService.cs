using Twitter.Dal;

namespace Twitter.BL.Services.Interfaces
{
    public interface ITwitterBlService
    {
        Users CreateAccount(string firstName, string lastName, string emaill, string password);
    }
}
