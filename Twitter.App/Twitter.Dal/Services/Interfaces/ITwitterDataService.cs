using Twitter.Dal.Models;

namespace Twitter.Dal.Services.Interfaces
{
    public interface ITwitterDataService
    {
        Users CreateUser(string firstName, string lastName, string email, string password);

        Users EditUser(int userID, string firstName, string lastName, string password);

        Users GetUser(string email, string password);

        Users[] GetUsers(string firstName);

        void Follow(int userID, int userFollowedID);

        void UnFollow(int userID, int userUnFollowedID);

        TweetModel[] GetFollowedUsersTweets(int userID);

        Tweets AddTweet(int userID, string content);

        TweetModel[] GetOwnTweets(int userID);
    }
}
