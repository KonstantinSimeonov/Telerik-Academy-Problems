using Cosmetics.Engine;
namespace Cosmetics
{
    using System.Threading;
    using System.Globalization;
    public class CosmeticsProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            CosmeticsEngine.Instance.Start();
        }
    }
}
