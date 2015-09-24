namespace TemplateMethod
{
    using System;

    using TemplateMethod.FileTypes;

    public class ArrayCompressionSender : FileSender
    {
        public ArrayCompressionSender()
        {

        }

        // redefined chosen methods to achieve desired behaviour
        protected override IFile CompressFile(IFile file)
        {
            var compressedFile = new ArrayCompressedFile(file);
            return compressedFile;
        }

        protected override void SendToDomain(IFile file, string domain)
        {
            // add some extra behaviour to base method:
            // if the file is already present on that domain, don't send it
            if(Internet.Domains[domain].Files.Contains(file))
            {
                return;
            }

            base.SendToDomain(file, domain);
        }
    }
}
