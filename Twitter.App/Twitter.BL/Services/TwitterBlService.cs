using System;
using Twitter.BL.Helpers;
using Twitter.BL.Objects;
using Twitter.BL.Objects.Responses;
using Twitter.BL.Objects.Responses.Base;
using Twitter.BL.Services.Interfaces;
using Twitter.Dal.Services;
using Twitter.Dal.Services.Interfaces;

namespace Twitter.BL.Services
{
    public class TwitterBlService : ITwitterBlService
    {
        private ITwitterDataService twitterDataService;

        public TwitterBlService()
        {
            twitterDataService = new TwitterDataService();
        }

        public AccountResponse Login(string email, string password)
        {
            var user = twitterDataService.GetUser(email, password);
            if (user == null)
                return AccountResponse.Error();

            var convertedUser = ConversionHelper.ConvertUser(user);
            return AccountResponse.Success(convertedUser);
        }

        public AccountResponse CreateAccount(string firstName, string lastName, string email, string password)
        {
            var user = twitterDataService.CreateUser(firstName, lastName, email, password);
            if (user == null)
                return AccountResponse.Error();

            var convertedUser = ConversionHelper.ConvertUser(user);
            return AccountResponse.Success(convertedUser);
        }

        public AccountResponse EditAccount(int userID, string firstName, string lastName, string password)
        {
            var user = twitterDataService.EditUser(userID, firstName, lastName, password);
            if (user == null)
                return AccountResponse.Error();

            var convertedUser = ConversionHelper.ConvertUser(user);
            return AccountResponse.Success(convertedUser);
        }

        public User[] GetUsers(string firstName)
        {
            var users = twitterDataService.GetUsers(firstName);

            return ConversionHelper.ConvertUsers(users);
        }

        public BaseResponse Follow(int userID, int userFollowedID)
        {
            try
            {
                twitterDataService.Follow(userID, userFollowedID);

                return BaseResponse.Success();
            }
            catch (Exception)
            {
                return BaseResponse.Error();
            }

        }

        public BaseResponse UnFollow(int userID, int userUnFollowedID)
        {
            try
            {
                twitterDataService.UnFollow(userID, userUnFollowedID);

                return BaseResponse.Success();
            }
            catch (Exception)
            {
                return BaseResponse.Error();
            }
        }

        public Tweet[] GetFollowedUsersTweets(int userID)
        {
            var tweets = twitterDataService.GetFollowedUsersTweets(userID);

            return ConversionHelper.ConvertTweets(tweets);
        }

        public Tweet AddTweet(int userID, string content)
        {
            var tweet = twitterDataService.AddTweet(userID, content);

            return ConversionHelper.ConvertTweet(tweet);
        }

        public Tweet[] GetOwnTweets(int userID)
        {
            var tweets = twitterDataService.GetOwnTweets(userID);

            return ConversionHelper.ConvertTweets(tweets);
        }
    }
}
