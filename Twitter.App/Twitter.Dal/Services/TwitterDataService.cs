using System;
using System.Linq;
using Twitter.Dal.Services.Interfaces;

namespace Twitter.Dal.Services
{
    public class TwitterDataService: ITwitterDataService
    {
        public Users CreateUser(string firstName, string lastName, string emaill, string password)
        {
            using (var context = new TwitterContext())
            {
                var user = new Users
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = emaill,
                    Password = password
                };

                user = context.Users.Add(user);
                context.SaveChanges();

                return user;
            }
        }

        public Users EditUser(int userID, string firstName, string lastName, string password)
        {
            using (var context = new TwitterContext())
            {
                var user = context.Users.SingleOrDefault(x => x.ID == userID);

                if (user == null)
                    return null;

                user.FirstName = firstName;
                user.LastName = lastName;
                user.Password = password;

                context.SaveChanges();
                return user;
            }
        }

        public Users GetUser(string emaill, string password)
        {
            using (var context = new TwitterContext())
            {
                var user = context.Users.SingleOrDefault(x=> x.Email == emaill && x.Password == password);

                return user;
            }
        }

        public void Follow(int userID, int userFollowedID)
        {
            using (var context = new TwitterContext())
            {
                var userFollowed = new UserFollowed
                {
                    UserID = userID,
                    UserFollowedID = userFollowedID
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
                    Content = content
                };

                tweet = context.Tweets.Add(tweet);
                context.SaveChanges();

                return tweet;
            }
        }


        public Tweets[] GetFollowedUsersTweets(int userID)
        {
            using (var context = new TwitterContext())
            {
                var userFollowed = context.UserFollowed.Where(x => x.UserID == userID).Select(x => x.UserFollowedID);

                var userFollowedTweets = context.Tweets.Where(x => userFollowed.Contains(x.UserID)).ToArray();

                return userFollowedTweets;

            }
        }

        public Tweets[] GetOwnTweets(int userID)
        {
            using (var context = new TwitterContext())
            {
                var tweets = context.Tweets.Where(x => x.UserID == userID).ToArray();

                return tweets;
            }
        }

        public Users[] GetUsers(string firstName)
        {
            using (var context = new TwitterContext())
            {
                var users = context.Users.Where(x => x.FirstName == firstName).ToArray();

                return users;
            }
        }

    
    }
}
