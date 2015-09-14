using System;

namespace Decorator
{
    public class UserProfile : IUserProfile
    {
        public virtual string Username { get; set; }

        public virtual string Password { get; set; }

        public UserProfile(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public UserProfile()
        {
        }
    }
}