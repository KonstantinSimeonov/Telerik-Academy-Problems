namespace Facade
{
    using System;

    public class Businessman
    {
        public string Name { get; private set; }

        public Businessman(string name)
        {
            this.Name = name;
        }

        public void WakeUp()
        {
            Console.WriteLine(this.Name + ": yawn");
        }

        public void BrushTeeth()
        {
            Console.WriteLine(this.Name + ": sdlgsdkgjs");
        }

        public void SuitUp()
        {
            Console.WriteLine(this.Name + " puts on his suit");
        }

        public void GetCarKeys()
        {
            Console.WriteLine("getting keys");
        }

        public void GetInCar()
        {
            Console.WriteLine("getting in the car");
        }

        public void StartEngine()
        {
            Console.WriteLine("brym-brym");
        }

        public void DriveToWork()
        {
            Console.WriteLine(this.Name + " drives to work: bryyyyyyyym");
        }

        public void GreetEveryone()
        {
            Console.WriteLine("morning");
        }

        public void StartWorking()
        {
            Console.WriteLine(this.Name + " is working");
        }

        public void AttendBusinessMeeting()
        {
            Console.WriteLine(this.Name + " is attending a business meeting");
        }

        public void HaveLunchBreak()
        {
            Console.WriteLine("Lunch break");
        }

        public void GoBackToWork()
        {
            Console.WriteLine(this.Name + " is working again");
        }

        public void LeaveWork()
        {
            Console.WriteLine(this.Name + " is outta here");
        }

        public void HaveDinner()
        {
            Console.WriteLine("omnomnom");
        }

        public void DriveHome()
        {
            Console.WriteLine("brym-brym do vkushti");
        }

        public void GoToSleep()
        {
            Console.WriteLine("*snore*");
        }

        public void HaveBreakfast()
        {
            Console.WriteLine("omnomnom breakfast");
        }

        public void Chill()
        {
            Console.WriteLine(this.Name + " is chilling");
        }

        public void DrinkBeer()
        {
            Console.WriteLine("gulp");
        }

        public void WriteCSharpCode()
        {
            Console.WriteLine("code written");
        }
    }
}