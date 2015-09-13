namespace ObjectPool
{
    using System;
    using System.Collections.Generic;

    public class CarRenter
    {
        private readonly List<Car> carsInStock = new List<Car>();
        private readonly List<Car> carsInUse = new List<Car>();

        public CarRenter()
        {
        }

        public void Store(Car car)
        {
            Console.WriteLine("Car stored.");
            car.Dispose();
            this.carsInStock.Add(car);
        }

        public bool HasCarsInStock
        {
            get
            {
                return this.carsInStock.Count > 0;
            }
        }

        public Car RentACar(string driver)
        {
            Console.WriteLine("Car rented by " + driver);
            var rented = this.carsInStock[this.carsInStock.Count - 1];

            this.carsInStock.RemoveAt(this.carsInStock.Count - 1);
            this.carsInUse.Add(rented);

            rented.Driver = driver;

            return rented;
        }

        public void ReturnCar(Car car)
        {
            Console.WriteLine("Car returned by " + car.Driver);
            car.Dispose();
            this.carsInStock.Add(car);
            this.carsInUse.Remove(car);
        }

    }
}