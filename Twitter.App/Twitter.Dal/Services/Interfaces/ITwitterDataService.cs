using Twitter.Dal.Models;

namespace Twitter.Dal.Services.Interfaces
{
    public interface ITwitterDataService
    {
        UserModel CreateUser(string firstName, string lastName, string email, string password);

        UserModel EditUser(int userID, string firstName, string lastName, string password);

        UserModel GetUser(string email, string password);

        UserModel[] GetUsers(int userId, string firstName);

        void Follow(int userID, int userFollowedID);

        void UnFollow(int userID, int userUnFollowedID);

        TweetModel[] GetFollowedUsersTweets(int userID);

        Tweets AddTweet(int userID, string content);

        TweetModel[] GetOwnTweets(int userID);
    }
}
