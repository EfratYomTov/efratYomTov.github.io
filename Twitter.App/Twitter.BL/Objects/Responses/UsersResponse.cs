using Twitter.BL.Objects.Responses.Base;

namespace Twitter.BL.Objects.Responses
{
    public class UsersResponse : BaseResponse
    {
        public User[] Users { get; set; }

        internal static UsersResponse Success(User[] users)
        {
            return new UsersResponse { IsSucceeded = true, Users = users };
        }
    }
}
