namespace Twitter.Dal.Models
{
    public class UserModel : Users
    {
        public bool? IsFollowedByMe { get; set; }

        public UserModel()
        {

        }


        public UserModel(Users user)
        {
            ID = user.ID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Password = user.Password;
            CreatedDate = user.CreatedDate;
            IsFollowedByMe = null;
        }

    }
}
