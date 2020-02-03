using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Twitter.App.ApiControllers
{
    [RoutePrefix("api/Twitter")]
    public class TwitterApiController : ApiController
    {
        private ITwitterBlService twitterBlService;

        public TwitterApiController()
        {
            twitterBlService = new TwitterBlService();
        }


        // POST api/Twitter/Login
        [Route("Login")]
        public IHttpActionResult Login()
        {
            //Do somesing
            return Ok();
        }

        // POST api/Twitter/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            //Do somesing
            return Ok();
        }



        // POST api/Twitter/CreateAccount
        // [AllowAnonymous]
        [Route("CreateAccount")]
        public async Task<IHttpActionResult> CreateAccount(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await twitterBlService.CreateAccount(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();

        }

        // POST api/Twitter/EditAccount
        [Route("EditAccount")]
        public async Task<IHttpActionResult> EditAccount()
        {
            
            return Ok();
        }

        // GET api/Twitter/GetUsers
        [Route("GetUsers")]
        public Users[] GetUsers(string firstName)
        {

            return Ok();
        }

        // POST api/Twitter/Follow
        [Route("Follow")]
        public IHttpActionResult Follow(int userID, int userFollowedID);

        // POST api/Twitter/UnFollow
        [Route("UnFollow")]
        public IHttpActionResult UnFollow(int userID, int userUnFollowedID);

        // POST api/Twitter/AddTweet
        [Route("AddTweet")]
        public IHttpActionResult AddTweet(int userID, string content);

        // GET api/Twitter/GetFollowedUsersTweets
        [Route("GetFollowedUsersTweets")]
        public Tweets[] GetFollowedUsersTweets(int userID)
        {

            return Ok();
        }

        // GET api/Twitter/GetOwnTweets
        [Route("GetOwnTweets")]
        public Tweets[] GetOwnTweets(int userID)
        {

            return Ok();
        }

        #region Private

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        #endregion Private


    }
}