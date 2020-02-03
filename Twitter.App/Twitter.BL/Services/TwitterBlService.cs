using System;
using Twitter.BL.Objects.Responses;
using Twitter.BL.Services.Interfaces;
using Twitter.Dal;
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

        public Users CreateAccount(string firstName, string lastName, string emaill, string password)
        {
            return twitterDataService.CreateUser(firstName, lastName, emaill, password);
        }

        public Users EditUser(int userID, string firstName, string lastName, string password)
        {
            return twitterDataService.EditUser(userID, firstName, lastName, password);
        }

        public LoginResponse Login(string emaill, string password)
        {
            var user = twitterDataService.GetUser(emaill, password);
            if (user == null)
                return LoginResponse.Error();

            return LoginResponse.Success();
        }
    }
}
