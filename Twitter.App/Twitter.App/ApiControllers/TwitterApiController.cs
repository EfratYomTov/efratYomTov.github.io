using Newtonsoft.Json;
using System.Web.Http;
using Twitter.App.Models;
using Twitter.BL.Services;
using Twitter.BL.Services.Interfaces;

namespace Twitter.App.ApiControllers
{
    public class TwitterApiController : ApiController
    {
        private ITwitterBlService twitterBlService;

        public TwitterApiController()
        {
            twitterBlService = new TwitterBlService();
        }

        [Route("api/twitter/login")]
        [HttpPost]
        public string Login([FromBody]LoginModel request)
        {
            var accountResponse = twitterBlService.Login(request.Email, request.Password);

            return ToJson(accountResponse);
        }

        [HttpPost]
        [Route("api/twitter/createAccount")]
        public string CreateAccount([FromBody]CreateAccountModel request)
        {
            var accountResponse = twitterBlService.CreateAccount(request.FirstName, request.LastName, request.Email, request.Password);

            return ToJson(accountResponse);
        }

        [HttpPost]
        [Route("api/twitter/editAccount")]
        public string EditAccount([FromBody]EditAccountModel request)
        {
            var accountResponse = twitterBlService.EditAccount(request.Id, request.FirstName, request.LastName, request.Password);

            return ToJson(accountResponse);
        }

        [HttpGet]
        [Route("api/twitter/getUsers")]
        public string GetUsers(string firstName = null)
        {
            var users = twitterBlService.GetUsers(firstName);

            return ToJson(users);
        }

        [HttpPost]
        [Route("api/twitter/follow")]
        public string Follow([FromBody]FollowModel request)
        {
            var response = twitterBlService.Follow(request.UserID, request.UserFollowedID);

            return ToJson(response);
        }

        [HttpPost]
        [Route("api/twitter/unFollow")]
        public string UnFollow([FromBody]UnFollowModel request)
        {
            var response = twitterBlService.UnFollow(request.UserID, request.UserUnFollowedID);

            return ToJson(response);
        }

        [HttpPost]
        [Route("api/twitter/addTweet")]
        public string AddTweet([FromBody]TweetModel request)
        {
            var tweet = twitterBlService.AddTweet(request.UserID, request.Content);
            return ToJson(tweet);
        }

        [HttpGet]
        [Route("api/twitter/getFollowedUsersTweets")]
        public string GetFollowedUsersTweets(int userID)
        {
            var tweets = twitterBlService.GetFollowedUsersTweets(userID);
            return ToJson(tweets);
        }

        [HttpGet]
        [Route("api/twitter/getOwnTweets")]
        public string GetOwnTweets(int userID)
        {
            var tweets = twitterBlService.GetOwnTweets(userID);
            return ToJson(tweets);
        }

        #region Private

        private string ToJson(object value)
        {

            return JsonConvert.SerializeObject(value);
        }

        #endregion Private


    }
}