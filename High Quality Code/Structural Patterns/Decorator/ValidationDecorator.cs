namespace Decorator
{
    using System;

    public class ValidationDecorator : UserProfileDecorator
    {

        public ValidationDecorator(IUserProfile profile)
            :base(profile)
        {
        }

        public override string Username
        {
            get
            {
                return base.Username;
            }

            set
            {
                if(!IsValidUsername(value))
                {
                    throw new ArgumentException("Invalid username!");
                }

                base.Username = value;
            }
        }

        public override string Password
        {
            get
            {
                return base.Password;
            }
            
            set
            {
                if(!this.IsValidPassword(value))
                {
                    throw new ArgumentException("Invalid password!");
                }

                base.Password = value;
            }
        }

        private bool IsValidUsername(string username)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                return false;
            }

            if(username.Length < 5 || 15 < username.Length)
            {
                return false;
            }

            return true;
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 5)
            {
                return false;
            };

            return true;
        }
    }
}