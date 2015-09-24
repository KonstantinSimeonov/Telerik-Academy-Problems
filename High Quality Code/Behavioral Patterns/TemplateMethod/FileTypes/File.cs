namespace TemplateMethod.FileTypes
{
    using System;

    public class File : IFile
    {
        public string Content { get; private set; }

        public File(string content)
        {
            this.Content = content;
        }
    }
}