namespace Facade
{
    using System;

    public class BusinessmanFacade
    {
        private Businessman businessman;

        public BusinessmanFacade(Businessman businessman)
        {
            this.businessman = businessman;
        }

        public void GetReadyForWork()
        {
            Console.WriteLine("How " + this.businessman.Name + " is getting ready for work: ");
            this.businessman.WakeUp();
            this.businessman.BrushTeeth();
        }

        public void GetToWorkplace()
        {
            Console.WriteLine(this.businessman.Name + " goes to work by:");
            this.businessman.GetCarKeys();
            this.businessman.GetInCar();
            this.businessman.StartEngine();
            this.businessman.DriveToWork();
        }

        public void Work()
        {
            Console.WriteLine("\n\nWhat " + this.businessman.Name + " is doing at work:");
            this.businessman.GreetEveryone();
            this.businessman.StartWorking();
            this.businessman.HaveLunchBreak();
            this.businessman.GoBackToWork();
        }

        public void DoStuffAfterWork()
        {
            Console.WriteLine("\n\nWhat " + this.businessman.Name + " is doing after work");
            this.businessman.LeaveWork();
            this.businessman.GetInCar();
            this.businessman.StartEngine();
            this.businessman.DriveHome();
            this.businessman.HaveDinner();
            this.businessman.BrushTeeth();
            this.businessman.GoToSleep();
        }

        public void WorkDay()
        {
            this.GetReadyForWork();
            this.GetToWorkplace();
            this.DoStuffAfterWork();
        }

        public void Holiday()
        {
            this.businessman.WakeUp();
            this.businessman.HaveBreakfast();
            this.businessman.DrinkBeer();
            this.businessman.Chill();
            this.businessman.WriteCSharpCode();
            this.businessman.DrinkBeer();
            this.businessman.WriteCSharpCode();
            this.businessman.Chill();
            this.DoStuffAfterWork();
        }
    }
}