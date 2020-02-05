using Twitter.BL.Objects.Responses.Base;

namespace Twitter.BL.Objects.Responses
{
    public class TweetsResponse : BaseResponse
    {
        public Tweet[] Tweets { get; set; }


        internal static TweetsResponse Success(Tweet[] tweets)
        {
            return new TweetsResponse { IsSucceeded = true, Tweets = tweets };
        }
    }
}
