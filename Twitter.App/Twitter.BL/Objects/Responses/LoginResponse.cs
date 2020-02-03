using System;
using Twitter.Dal;

namespace Twitter.BL.Objects.Responses
{
    public class LoginResponse
    {
        public bool IsValidLogin { get; set; }

        public Users User { get; set; }



        internal static LoginResponse Error()
        {
            throw new NotImplementedException();
        }

        internal static LoginResponse Success()
        {
            throw new NotImplementedException();
        }
    }
}
