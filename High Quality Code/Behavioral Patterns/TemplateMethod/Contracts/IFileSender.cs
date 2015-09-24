namespace TemplateMethod
{
    public interface IFileSender
    {
        void Send(IFile file, string domainName);
    }
}