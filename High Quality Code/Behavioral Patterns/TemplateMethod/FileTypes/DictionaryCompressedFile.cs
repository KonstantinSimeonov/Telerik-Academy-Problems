namespace TemplateMethod.FileTypes
{
    using System;
    using System.Collections.Generic;

    public class DictionaryCompressedFile : IFile
    {
        private IDictionary<string, IList<int>> content;
        private int wordCount;

        public DictionaryCompressedFile(IFile file)
        {
            // leave some room for error :)
            var splitContent = file.Content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            this.wordCount = splitContent.Length;
            this.content = FileContentToDictionary(splitContent);
        }

        public string Content
        {
            get
            {
                return DictionaryToFileContent(this.content, this.wordCount);
            }
        }

        private static string DictionaryToFileContent(IDictionary<string, IList<int>> dict, int wordCount)
        {
            var result = new string[wordCount];

            foreach (var item in dict)
            {
                foreach (var position in item.Value)
                {
                    Console.WriteLine(position);
                    result[position] = item.Key;
                }
            }

            return string.Join(" ", result);
        }

        private static IDictionary<string, IList<int>> FileContentToDictionary(string[] splitContent)
        {
            var dict = new Dictionary<string, IList<int>>();


            for (int i = 0, length = splitContent.Length; i < length; i++)
            {
                if (dict.ContainsKey(splitContent[i]))
                {
                    dict[splitContent[i]].Add(i);
                }
                else
                {
                    dict.Add(splitContent[i], new List<int>() { i });
                }
            }

            return dict;
        }
    }
}
