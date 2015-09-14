namespace Decorator
{
    using System.Text;

    public class EncryptionDecorator : UserProfileDecorator
    {
        private const string EncryptionKey = "gosho_123";

        public EncryptionDecorator(IUserProfile profile)
            :base(profile)
        {
        }

        public override string Password
        {
            get
            {
                return this.Decrypt(base.Password);
            }
            
            set
            {
                base.Password = this.Encrypt(value);
            }
        }

        private string Encrypt(string pass)
        {
            var result = new StringBuilder();

            for (int i = 0, length = pass.Length; i < length; i++)
            {
                var nextChar = (char)(pass[i] ^ EncryptionKey[i % EncryptionKey.Length]);
                result.Append(nextChar);
            }

            return result.ToString();
        }

        private string Decrypt(string encrypted)
        {
            return this.Encrypt(encrypted);
        }
    }
}