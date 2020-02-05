using Twitter.BL.Objects.Responses.Base;

namespace Twitter.BL.Objects.Responses
{
    public class AccountResponse : BaseResponse
    {
        public User User { get; set; }



        internal static AccountResponse Success(User user)
        {
            return new AccountResponse { IsSucceeded = true, User = user };
        }

    }
}
