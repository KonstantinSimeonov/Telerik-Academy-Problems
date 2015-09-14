namespace Decorator
{
    public class UserProfileDecorator : UserProfile
    {
        private IUserProfile baseProfile;

        protected UserProfileDecorator(IUserProfile profile)
        {
            this.baseProfile = profile;
        }

        public override string Username
        {
            get
            {
                return this.baseProfile.Username;
            }

            set
            {
                this.baseProfile.Username = value;
            }
        }

        public override string Password
        {
            get
            {
                return this.baseProfile.Password;
            }

            set
            {
                this.baseProfile.Password = value;
            }
        }
    }
}