using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Threads_Tävling
{
    public class Car
    {
        public string Name { get; set; }
        public double Speed { get; private set; } = 120; // km/h
        public double Distance { get; private set; } = 0; // km

        public Car(string name)
        {
            Name = name;
        }

        public void Drive(double distance)
        {
            Distance += distance;
            
            Console.WriteLine($"{Name} has driven {Distance:0.00} km. Current speed: {Speed} km/h");
            Console.WriteLine("--------------------------------------------------------------------");
           
        }

        public void ReduceSpeed(double amount)
        {
            Speed = Math.Max(0, Speed - amount);
        }
    }
}
