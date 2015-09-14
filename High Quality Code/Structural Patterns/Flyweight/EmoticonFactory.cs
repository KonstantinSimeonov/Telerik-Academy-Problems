namespace Flyweight
{
    using System;
    using System.Collections.Generic;

    public class EmoticonFactory : IEmoticonFactory
    {
        private Dictionary<string, IFlyweightEmoticon> emoticonsInUse;

        public EmoticonFactory()
        {
            this.emoticonsInUse = new Dictionary<string, IFlyweightEmoticon>();
        }

        public int ObjectsCreated { get; private set; }

        public IFlyweightEmoticon GetEmoticon(string content)
        {
            if(this.emoticonsInUse.ContainsKey(content))
            {
                return this.emoticonsInUse[content];
            }

            var newEmoticon = new Emoticon(content);
            this.emoticonsInUse.Add(content, newEmoticon);

            this.ObjectsCreated++;

            return newEmoticon;
        }
    }
}