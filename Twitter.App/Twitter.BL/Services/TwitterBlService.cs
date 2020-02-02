using System;
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
    }
}
