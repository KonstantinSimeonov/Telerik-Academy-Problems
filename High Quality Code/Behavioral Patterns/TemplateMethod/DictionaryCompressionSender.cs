namespace TemplateMethod
{
    using System;

    using TemplateMethod.FileTypes;

    public class DictionaryCompressionSender : FileSender
    {
        private bool hasDictionaryError;

        public DictionaryCompressionSender()
        {
        }

        protected override IFile CompressFile(IFile file)
        {
            IFile result;

            try
            {
                result = new DictionaryCompressedFile(file);
                Console.WriteLine();
            }
            catch
            {
                result = file;
                this.hasDictionaryError = true;
            }

            return result;
        }

        protected override void Report(string domainName)
        {
            // extend base method behaviour
            if(this.hasDictionaryError)
            {
                SetConsoleColor(false);
                Console.WriteLine("Dictionary error occured, file was sent uncompressed.");
                SetConsoleColorToDefault();
            }

            this.hasDictionaryError = false;

            base.Report(domainName);
        }
    }
}
