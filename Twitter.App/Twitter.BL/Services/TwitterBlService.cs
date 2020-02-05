using System;
using System.Linq;
using Twitter.BL.Helpers;
using Twitter.BL.Interfaces;
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

        public IResponse Login(string email, string password)
        {
            try
            {
                var user = twitterDataService.GetUser(email, password);
                if (user == null)
                    return BaseResponse.Error();

                var convertedUser = ConversionHelper.ConvertUser(user);
                return AccountResponse.Success(convertedUser);
            }
            catch (Exception)
            {
                return BaseResponse.Error();
            }
        }

        public IResponse CreateAccount(string firstName, string lastName, string email, string password)
        {
            try
            {
                var user = twitterDataService.CreateUser(firstName, lastName, email, password);
                if (user == null)
                    return BaseResponse.Error();

                var convertedUser = ConversionHelper.ConvertUser(user);
                return AccountResponse.Success(convertedUser);
            }
            catch (Exception)
            {
                return BaseResponse.Error();
            }
        }

        public IResponse EditAccount(int userID, string firstName, string lastName, string password)
        {
            try
            {
                var user = twitterDataService.EditUser(userID, firstName, lastName, password);
                if (user == null)
                    return BaseResponse.Error();

                var convertedUser = ConversionHelper.ConvertUser(user);
                return AccountResponse.Success(convertedUser);
            }
            catch (Exception)
            {
                return BaseResponse.Error();
            }
        }

        public IResponse GetUsers(int userID, string firstName)
        {
            try
            {
                var users = twitterDataService.GetUsers(userID, firstName);

                var convertedUsers = ConversionHelper.ConvertUsers(users);

                return UsersResponse.Success(convertedUsers);
            }
            catch (Exception)
            {
                return BaseResponse.Error();
            }

        }

        public IResponse Follow(int userID, int userFollowedID)
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

        public IResponse UnFollow(int userID, int userUnFollowedID)
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

        public IResponse GetFollowedUsersTweets(int userID)
        {
            try
            {
                var tweets = twitterDataService.GetFollowedUsersTweets(userID);

                var convertedTweets = ConversionHelper.ConvertTweets(tweets).OrderByDescending(x => x.DateAdded).ToArray();

                return TweetsResponse.Success(convertedTweets);
            }
            catch (Exception)
            {
                return BaseResponse.Error();
            }
        }

        public IResponse AddTweet(int userID, string content)
        {
            try
            {
                var tweet = twitterDataService.AddTweet(userID, content);

                return BaseResponse.Success();
            }
            catch (Exception)
            {
                return BaseResponse.Error();
            }
        }

        public IResponse GetOwnTweets(int userID)
        {
            try
            {
                var tweets = twitterDataService.GetOwnTweets(userID);

                var convertedTweets = ConversionHelper.ConvertTweets(tweets).OrderByDescending(x=>x.DateAdded).ToArray();

                return TweetsResponse.Success(convertedTweets);
            }
            catch (Exception)
            {
                return BaseResponse.Error();
            }
        }
    }
}
