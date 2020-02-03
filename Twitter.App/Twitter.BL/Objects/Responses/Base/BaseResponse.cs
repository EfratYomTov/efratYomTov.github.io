namespace Twitter.BL.Objects.Responses.Base
{
    public class BaseResponse
    {
        public bool IsSucceeded { get; set; }


        internal static AccountResponse Error()
        {
            return new AccountResponse { IsSucceeded = false };
        }

        internal static AccountResponse Success()
        {
            return new AccountResponse { IsSucceeded = true};
        }


    }
}
