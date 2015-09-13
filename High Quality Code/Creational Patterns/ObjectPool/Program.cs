namespace ObjectPool
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var carRenter = new CarRenter();

            // add some cars to the center

            for (int i = 0; i < 15; i++)
            {
                carRenter.Store(new Car());
            }

            var driver1 = "Penka";
            var driver2 = "Zornica";
            var driver3 = "Stilqn";

            var penkasCar = carRenter.RentACar(driver1);
            var zornicasCar = carRenter.RentACar(driver2);
            var stilqnsCar = carRenter.RentACar(driver3);

            // should print driver names
            Console.WriteLine(penkasCar.Driver);
            Console.WriteLine(stilqnsCar.Driver);

            carRenter.ReturnCar(penkasCar);
            carRenter.ReturnCar(stilqnsCar);

            // should print empty lines, because the cars have been returned to the pool
            // but the car object still exist
            Console.WriteLine(penkasCar.Driver);
            Console.WriteLine(stilqnsCar.Driver);
        }
    }
}