using Twitter.BL.Interfaces;

namespace Twitter.BL.Services.Interfaces
{
    public interface ITwitterBlService
    {
        IResponse Login(string email, string password);

        IResponse CreateAccount(string firstName, string lastName, string email, string password);

        IResponse EditAccount(int userID, string firstName, string lastName, string password);

        IResponse GetUsers(int userID, string firstName);

        IResponse Follow(int userID, int userFollowedID);

        IResponse UnFollow(int userID, int userUnFollowedID);

        IResponse GetFollowedUsersTweets(int userID);

        IResponse AddTweet(int userID, string content);

        IResponse GetOwnTweets(int userID);
    }
}
