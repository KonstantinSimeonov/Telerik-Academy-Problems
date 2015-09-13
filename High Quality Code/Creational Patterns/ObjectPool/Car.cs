namespace ObjectPool
{
    using System;

    public class Car : IDisposable
    {
        public string Driver { get; set; }

        public Car()
        {
        }

        public void StartEngine()
        {
            Console.WriteLine(this.Driver + " brym-brym");
        }

        public void Dispose()
        {
            this.Driver = null;
        }
    }
}