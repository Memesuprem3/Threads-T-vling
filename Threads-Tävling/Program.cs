namespace Threads_Tävling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Race race = new Race();
            race.AddCar(new Car("Saab 900"));
            race.AddCar(new Car("Volvo 240"));
           

            race.Start();
        }
    }
}
