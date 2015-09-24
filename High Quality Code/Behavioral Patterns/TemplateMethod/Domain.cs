namespace TemplateMethod
{
    using System.Collections.Generic;

    public class Domain : IDomain
    {
        public IList<IFile> Files { get; private set; }

        public Domain()
        {
            this.Files = new List<IFile>();
        }
    }
}
