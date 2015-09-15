namespace Facade
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var businessman = new Businessman("Pesho");

            var pesho = new BusinessmanFacade(businessman);

            // the result is the same, but the use is really simplified

            // facade

            pesho.GetReadyForWork();
            pesho.GetToWorkplace();
            pesho.Work();
            pesho.DoStuffAfterWork();

            // we can also make a facade for those 4 methods and use it like that:
            // pesho.WorkDay();
            // or
            // pesho.Holiday();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n");

            // no facade
            businessman.WakeUp();
            businessman.BrushTeeth();
            businessman.GetCarKeys();
            businessman.GetInCar();
            businessman.StartEngine();
            businessman.DriveToWork();
            businessman.GreetEveryone();
            businessman.StartWorking();
            businessman.HaveLunchBreak();
            businessman.GoBackToWork();
            businessman.LeaveWork();
            businessman.GetInCar();
            businessman.StartEngine();
            businessman.DriveHome();
            businessman.HaveDinner();
            businessman.BrushTeeth();
            businessman.GoToSleep();

        }


    }
}