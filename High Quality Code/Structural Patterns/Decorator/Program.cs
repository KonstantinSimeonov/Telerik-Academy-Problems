namespace Decorator
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var userProfile = new UserProfile();

            var validationDecorator = new ValidationDecorator(userProfile);

            // with invalid input

            try
            {
                validationDecorator.Username = "ivan";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                validationDecorator.Password = "1234563";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            // with valid input

            validationDecorator.Username = "bay_ivan";
            validationDecorator.Password = "spartaa_18";

            Console.WriteLine("Username: " + userProfile.Username);
            Console.WriteLine("Password: " + userProfile.Password);

            // we can also do a composition of decorators
            var encryptionDecorator = new EncryptionDecorator(validationDecorator);

            // here we can still use the validation from the validation decorator
            // but we also have the functionality of the encryption decorator
            try
            {
                encryptionDecorator.Username = "ivan";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                encryptionDecorator.Password = "1234563";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            encryptionDecorator.Username = "bay_ivan";
            encryptionDecorator.Password = "spartaa_18";

            Console.WriteLine("Username: " + userProfile.Username);
            Console.WriteLine("Encrypted password: " + userProfile.Password);
        }
    }
}