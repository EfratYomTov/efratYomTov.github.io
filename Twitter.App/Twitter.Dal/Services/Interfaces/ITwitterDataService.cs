namespace Twitter.Dal.Services.Interfaces
{
    public interface ITwitterDataService
    {
        Users CreateUser(string firstName, string lastName, string emaill, string password);

        Users EditUser(int userID, string firstName, string lastName, string password);

        Users GetUser(string emaill, string password);

        Users[] GetUsers(string firstName);

        void Follow(int userID, int userFollowedID);

        void UnFollow(int userID, int userUnFollowedID);

        Tweets[] GetFollowedUsersTweets(int userID);

        Tweets AddTweet(int userID, string content);

        Tweets[] GetOwnTweets(int userID);
    }
}
