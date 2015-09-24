namespace TemplateMethod.FileTypes
{
    using System;

    public class ArrayCompressedFile : IFile
    {
        private readonly string[] content;

        public ArrayCompressedFile(IFile file)
        {
            this.content = FileContentToArray(file.Content);
        }

        public string Content
        {
            get
            {
                return string.Join(" ", this.content);
            }
        }

        private static string[] FileContentToArray(string content)
        {
            return content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
