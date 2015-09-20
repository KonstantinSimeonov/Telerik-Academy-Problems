namespace GenericMemento
{
    using System;

    using GenericMemento.Cloneables;

    class Program
    {
        static void Main(string[] args)
        {
            // custom clone

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Custom cloning: ");
            Console.ForegroundColor = ConsoleColor.White;

            
            var originalGosho = new StormTrooper("gosho");
            originalGosho.AddEquipment("gun");

            var memento = new Saver<StormTrooper>();
            memento.SaveState(originalGosho);

            originalGosho.AddEquipment("rubber duck");
            originalGosho.AddEquipment("stormtrooper helmet");

            Console.WriteLine("The saved gosho has {0} in his equipment list", string.Join(", ", memento.GetState().Equipment));
            Console.WriteLine("The original gosho has {0} in his equipment list", string.Join(", ", originalGosho.Equipment));

            Console.WriteLine("\n\n");

            // .NET cloning

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(".NET cloning:");
            Console.ForegroundColor = ConsoleColor.White;

            var arr = new int[] { 1, 2, 3, 4, 5, 6, -423234324 };
            var intArrMemento = new Saver<int[]>();
            
            intArrMemento.SaveState(arr);

            // introduce a change to the original state
            arr[0] = 149234;

            Console.WriteLine("Saved state of the array: {0}", string.Join(", ", intArrMemento.GetState()));
            Console.WriteLine("Current state of the array: {0}", string.Join(", ", arr));

            Console.WriteLine("\n\n");

            // Serialization cloning
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Serialization cloning:");
            Console.ForegroundColor = ConsoleColor.White;

            var gotShip = new SpaceShip("tarataika", "jeko snejev");
            var shipMemento = new Saver<SpaceShip>();

            shipMemento.SaveState(gotShip);

            // introduce a change to the original state
            gotShip.PilotName = "paolo koelio";

            Console.WriteLine("The saved ship's pilot is: {0}", shipMemento.GetState().PilotName);
            Console.WriteLine("The original ship's pilot is: {0}", gotShip.PilotName);

            Console.WriteLine("\n\n");

            // Reflection cloning
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Reflection cloning:");
            Console.ForegroundColor = ConsoleColor.White;

            var sinDomat = new Patladjan() {
                Price = 3,
                Weight = 2
            };
            var patladjanMemento = new Saver<Patladjan>();

            patladjanMemento.SaveState(sinDomat);

            sinDomat.Price = 0;

            Console.WriteLine("Price of the saved state of the patladjan: {0}", patladjanMemento.GetState().Price);
            Console.WriteLine("Price of the original patladjan: {0}", sinDomat.Price);

            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
