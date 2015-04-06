namespace FurnitureManufacturer
{
    using Engine;
    using System.Globalization;
    using System.Threading;
    public class FurnitureProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            FurnitureManufacturerEngine.Instance.Start();
        }
    }
}
