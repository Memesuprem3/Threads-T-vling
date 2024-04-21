using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Threads_Tävling
{
    public class Race
    {
        private List<Car> cars = new List<Car>();
        private int raceDistance = 10;
        private bool raceInProgress = true;
        private static bool firstFinished = false;
        private static string firstCarName = "";

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void Start()
        {
            Console.WriteLine("The race is starting now!");
            List<Thread> threads = new List<Thread>();
            foreach (var car in cars)
            {
                Thread thread = new Thread(() => RunCar(car));
                threads.Add(thread);
                thread.Start();
            }

            Thread controlThread = new Thread(CheckStatus);
            controlThread.Start();

            foreach (var thread in threads)
            {
                thread.Join();
            }

            raceInProgress = false;
            controlThread.Join();
            Console.WriteLine($"{firstCarName} wins the race!");
        }

        private void RunCar(Car car)
        {
            DateTime lastEventTime = DateTime.Now;

            while (car.Distance < raceDistance)
            {
                car.Drive(0.1);
                Thread.Sleep(1000); 

                if ((DateTime.Now - lastEventTime).TotalSeconds >= 30) 
                {
                    ForceEvent(car);
                    lastEventTime = DateTime.Now; 
                }
                else
                {
                    HandleEvent(car);
                }
            }

            Console.WriteLine($"{car.Name} has finished the race!");
            if (!firstFinished)
            {
                firstFinished = true;
                firstCarName = car.Name;
            }
        }

        private void ForceEvent(Car car)
        {
            
            Random rng = new Random();
            int eventRoll = rng.Next(0, 5); 

            if (eventRoll == 1)
            {
                Console.WriteLine($"{car.Name} ran out of gas and is refueling.");
                Thread.Sleep(30000);
            }
            else if (eventRoll <= 2)
            {
                Console.WriteLine($"{car.Name} had a flat tire and is changing it.");
                Thread.Sleep(20000);
            }
            else if (eventRoll <= 3)
            {
                Console.WriteLine($"{car.Name} is washing the windshield after hitting a bird.");
                Thread.Sleep(10000);
            }
            else if (eventRoll <= 4)
            {
                car.ReduceSpeed(1);
                Console.WriteLine($"{car.Name}'s speed has been reduced due to engine trouble.");
            }
            else
            {
               
                Console.WriteLine($"{car.Name} experienced a minor issue but quickly recovered.");
            }
        }

        private void HandleEvent(Car car)
        {
            
            Random rng = new Random();
            int eventChance = rng.Next(50);
            if (eventChance == 0) 
            {
                Console.WriteLine($"{car.Name} ran out of gas and is refueling.");
                Thread.Sleep(30000);
            }
            else if (eventChance >= 1 && eventChance <= 2) 
            {
                Console.WriteLine($"{car.Name} had a flat tire and is changing it.");
                Thread.Sleep(20000);
            }
            else if (eventChance >= 3 && eventChance <= 7) 
            {
                Console.WriteLine($"{car.Name} is washing the windshield after hitting a bird.");
                Thread.Sleep(10000);
            }
            else if (eventChance >= 8 && eventChance <= 17) 
            {
                car.ReduceSpeed(1);
                Console.WriteLine($"{car.Name}'s speed has been reduced due to engine trouble.");
            }
        }

        private void CheckStatus()
        {
            Console.WriteLine("Type 'status' for an update. Press Enter to exit.");
            while (raceInProgress)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "status")
                {
                    foreach (var car in cars)
                    {
                        Console.WriteLine($"{car.Name}: {car.Distance} km, Speed: {car.Speed} km/h");
                    }
                }
                else if (input == "")
                {
                    raceInProgress = false;
                }
            }
        }
    }
}
