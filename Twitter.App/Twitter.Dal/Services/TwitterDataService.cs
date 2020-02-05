using System;
using System.Linq;
using Twitter.Dal.Models;
using Twitter.Dal.Services.Interfaces;

namespace Twitter.Dal.Services
{
    public class TwitterDataService : ITwitterDataService
    {
        public UserModel CreateUser(string firstName, string lastName, string email, string password)
        {
            using (var context = new TwitterContext())
            {
                var user = new Users
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = password,
                    CreatedDate = DateTime.Now
                };

                user = context.Users.Add(user);
                context.SaveChanges();

                return new UserModel(user);
            }
        }

        public UserModel EditUser(int userID, string firstName, string lastName, string password)
        {
            using (var context = new TwitterContext())
            {
                var user = context.Users.SingleOrDefault(x => x.ID == userID);

                if (user == null)
                    return null;

                user.FirstName = firstName ?? user.FirstName;
                user.LastName = lastName ?? user.LastName;
                user.Password = password ?? user.Password;

                context.SaveChanges();
                return new UserModel(user);
            }
        }

        public UserModel GetUser(string email, string password)
        {
            using (var context = new TwitterContext())
            {
                var user = context.Users.SingleOrDefault(x => x.Email == email && x.Password == password);

                return new UserModel(user);
            }
        }

        public void Follow(int userID, int userFollowedID)
        {
            using (var context = new TwitterContext())
            {
                var userFollowed = new UserFollowed
                {
                    UserID = userID,
                    UserFollowedID = userFollowedID,
                };

                context.UserFollowed.Add(userFollowed);
                context.SaveChanges();
            }
        }

        public void UnFollow(int userID, int userUnFollowedID)
        {
            using (var context = new TwitterContext())
            {
                var userFollowed = context.UserFollowed.SingleOrDefault(x => x.UserID == userID && x.UserFollowedID == userUnFollowedID);
                if (userFollowed != null)
                {
                    context.UserFollowed.Remove(userFollowed);
                    context.SaveChanges();
                }
            }
        }

        public Tweets AddTweet(int userID, string content)
        {
            using (var context = new TwitterContext())
            {
                var tweet = new Tweets
                {
                    UserID = userID,
                    Content = content,
                    DateAdded = DateTime.Now
                };

                tweet = context.Tweets.Add(tweet);
                context.SaveChanges();

                return tweet;
            }
        }


        public TweetModel[] GetFollowedUsersTweets(int userID)
        {
            using (var context = new TwitterContext())
            {
                var userFollowed = GetUserFollowed(userID);

                var userFollowedTweets = context.Tweets.Where(x => userFollowed.Contains(x.UserID)).Select(x => new TweetModel
                {
                    ID = x.ID,
                    UserID = x.UserID,
                    UserName = x.Users.FirstName + " " + x.Users.LastName,
                    Content = x.Content,
                    DateAdded = x.DateAdded,

                }).ToArray();

                return userFollowedTweets;

            }
        }

        public TweetModel[] GetOwnTweets(int userID)
        {
            using (var context = new TwitterContext())
            {
                var tweets = context.Tweets
                    .Where(x => x.UserID == userID)
                    .Select(x => new TweetModel
                    {
                        ID = x.ID,
                        UserID = x.UserID,
                        UserName = x.Users.FirstName + " " + x.Users.LastName,
                        Content = x.Content,
                        DateAdded = x.DateAdded,
                       
                    }).ToArray();

                return tweets;
            }
        }

        public UserModel[] GetUsers(int userId, string firstName)
        {
            using (var context = new TwitterContext())
            {
                var userFollowedByMe = GetUserFollowed(userId);

                var users = context.Users.Where(x => string.IsNullOrEmpty(firstName) || x.FirstName == firstName)
                    .Select(x => new UserModel()
                    {
                        ID = x.ID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        Password = x.Password,
                        CreatedDate = x.CreatedDate,
                        IsFollowedByMe = userFollowedByMe.Contains(x.ID)
                    })
                    .ToArray();

                

              

                return users;
            }
        }


        private int[] GetUserFollowed(int userId)
        {
            using (var context = new TwitterContext())
            {
                return context.UserFollowed.Where(x => x.UserID == userId).Select(x => x.UserFollowedID).ToArray();
            }
        }

    }
}
