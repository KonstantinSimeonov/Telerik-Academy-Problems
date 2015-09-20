namespace GenericMemento
{
    using System;
    using System.Collections.Generic;

    using GenericMemento.Cloneables;

    public class Program
    {
        public static void Main()
        {
            var memento = new Saver<StormTrooper>();

            var originalGosho = new StormTrooper("gosho");

            originalGosho.AddEquipment("gun");

            memento.SaveState(originalGosho);

            originalGosho.AddEquipment("rubber duck");
            originalGosho.AddEquipment("stormtrooper helmet");

            Console.WriteLine("The saved gosho has {0} in his equipment list", string.Join(", ", memento.GetState().Equipment));
            Console.WriteLine("The original gosho has {0} in his equipment list", string.Join(", ", originalGosho.Equipment));

            Console.WriteLine("\n\n");

            var arr = new int[] { 1, 2, 3, 4, 5, 6, -423234324 };

            var intArrMemento = new Saver<int[]>();
            intArrMemento.SaveState(arr);

            arr[0] = 149234;

            Console.WriteLine("Saved state of the array: {0}", string.Join(", ", intArrMemento.GetState()));
            Console.WriteLine("Current state of the array: {0}", string.Join(", ", arr));

            Console.WriteLine("\n\n");

            var gotShip = new SpaceShip("tarataika", "jeko snejev");

            var shipMemento = new Saver<SpaceShip>();

            shipMemento.SaveState(gotShip);

            gotShip.PilotName = "paolo koelio";
            shipMemento.SaveState(gotShip);

            gotShip.PilotName = "djordjano";
            shipMemento.SaveState(gotShip);

            gotShip.PilotName = "pesho";

            var pilots = new List<string>();

            while (shipMemento.HasStates)
            {
                pilots.Add(shipMemento.GetState().PilotName);
            }

            Console.WriteLine("The ship has been piloted by: {0}", string.Join(", ", pilots));
            Console.WriteLine("The current ship's pilot is: {0}", gotShip.PilotName);
        }
    }
}
