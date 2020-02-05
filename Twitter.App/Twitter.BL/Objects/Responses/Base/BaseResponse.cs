using Twitter.BL.Interfaces;

namespace Twitter.BL.Objects.Responses.Base
{
    public class BaseResponse : IResponse
    {
        public bool IsSucceeded { get; set; }


        internal static IResponse Error()
        {
            return new BaseResponse { IsSucceeded = false };
        }

        internal static IResponse Success()
        {
            return new BaseResponse { IsSucceeded = true};
        }


    }
}
