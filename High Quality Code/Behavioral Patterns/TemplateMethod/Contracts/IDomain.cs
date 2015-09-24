namespace TemplateMethod
{
    using System.Collections.Generic;

    public interface IDomain
    {
        IList<IFile> Files { get; }
    }
}
