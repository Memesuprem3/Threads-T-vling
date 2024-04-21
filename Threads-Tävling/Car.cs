using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Threads_Tävling
{
    internal class Car
    {
        public string Name {  get; set; }
        public double Speed { get; set; } = 120; // km/h
        public double distance { get; set; } //km

        public Car(string Name) 
        {
           Name = Name;
        }

        public void Go(int length)
        {
            double time = length / Speed;
            int Timeinmilisec = (int)(time * 3600 * 1000);
            Thread.Sleep(Timeinmilisec);
            distance += length;
        }

    }
}
