using Twitter.BL.Objects;
using Twitter.BL.Objects.Responses;
using Twitter.BL.Objects.Responses.Base;

namespace Twitter.BL.Services.Interfaces
{
    public interface ITwitterBlService
    {
        AccountResponse Login(string email, string password);

        AccountResponse CreateAccount(string firstName, string lastName, string email, string password);

        AccountResponse EditAccount(int userID, string firstName, string lastName, string password);

        User[] GetUsers(string firstName);

        BaseResponse Follow(int userID, int userFollowedID);

        BaseResponse UnFollow(int userID, int userUnFollowedID);

        Tweet[] GetFollowedUsersTweets(int userID);

        Tweet AddTweet(int userID, string content);

        Tweet[] GetOwnTweets(int userID);
    }
}
