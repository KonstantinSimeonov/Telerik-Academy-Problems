namespace TemplateMethod
{
    using System;

    public abstract class FileSender : IFileSender
    {
        protected bool sendIsSuccessful;

        protected FileSender()
        {
        }

        public void Send(IFile file, string domainName)
        {
            // defined the order of operations, i.e. the "template"
            this.OpenConectionTo(domainName);
            var compressedFile = this.CompressFile(file);
            this.SendToDomain(file, domainName);
            this.Report(domainName);
        }

        // define base behaviour

        protected virtual void OpenConectionTo(string domainName)
        {
            if (Internet.Domains.ContainsKey(domainName))
            {
                Console.WriteLine("Connection to {0} opened.", domainName);
                
            }
            else
            {
                SetConsoleColor(false);
                Console.WriteLine("Domain not found!");
                this.sendIsSuccessful = false;
                SetConsoleColorToDefault();
            }
        }

        protected virtual IFile CompressFile(IFile file)
        {
            // scumbag me
            return file;
        }

        protected virtual void SendToDomain(IFile file, string domain)
        {
            try
            {
                Internet.Domains[domain].Files.Add(file);
            }
            catch
            {
                return;
            }

            this.sendIsSuccessful = true;
        }

        protected virtual void Report(string domainName)
        {
            SetConsoleColor(this.sendIsSuccessful);

            Console.WriteLine("File was sent {0}successfully to {1}", this.sendIsSuccessful ? "" : "un", domainName);
            Console.WriteLine();

            SetConsoleColorToDefault();
        }

        protected static void SetConsoleColor(bool state)
        {
            var color = state ? ConsoleColor.Green : ConsoleColor.Red;

            Console.ForegroundColor = color;
        }

        protected static void SetConsoleColorToDefault()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}