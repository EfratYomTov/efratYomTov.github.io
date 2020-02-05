using System.Collections.Generic;
using Twitter.BL.Objects;
using Twitter.Dal;
using Twitter.Dal.Models;

namespace Twitter.BL.Helpers
{
    internal static class ConversionHelper
    {
        /// <summary>
        /// Convert user from type Twitter.Dal.Users to Twitter.BL.Objects.User
        /// </summary>
        internal static User ConvertUser(Users user)
        {
            return new User
            {
                Id = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                CreatedDate = user.CreatedDate
            };
        }

        /// <summary>
        /// Convert users array from type Twitter.Dal.Users to Twitter.BL.Objects.User
        /// </summary>
        internal static User[] ConvertUsers(Users[] users)
        {
            var convertedUsers = new List<User>();

            foreach (var user in users)
            {
                convertedUsers.Add(ConvertUser(user));
            }

            return convertedUsers.ToArray();
        }

        /// <summary>
        /// Convert tweet from type Twitter.Dal.Tweets to Twitter.BL.Objects.TweetModel
        /// </summary>
        internal static Tweet ConvertTweet(TweetModel tweet)
        {
            return new Tweet
            {
                ID = tweet.ID,
                UserID = tweet.UserID,
                UserName = tweet.UserName,
                Content = tweet.Content,
                DateAdded = tweet.DateAdded,
                ShortDateString = tweet.DateAdded.ToShortDateString()
            };
        }

        /// <summary>
        /// Convert tweets from type Twitter.Dal.Tweets to Twitter.BL.Objects.TweetModel
        /// </summary>
        internal static Tweet[] ConvertTweets(TweetModel[] tweets)
        {
            var convertedTweets = new List<Tweet>();

            foreach (var tweet in tweets)
            {
                convertedTweets.Add(ConvertTweet(tweet));
            }

            return convertedTweets.ToArray();
        }
    }
}
