using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public class Vehicle
    {
        public string Name { get; protected set; }
        public int Speed { get; set; }
        
        public int Fuel { get;  set; }
        public Vehicle(string name,int speed,  int fuel) 
        {
            Name = name;
            Speed = speed;
            Fuel = fuel;
        }
        public virtual void Race(Vehicle opponent)
        {
            Console.WriteLine($"\n Wyścig: {Name} vs {opponent.Name}!");

            if (Fuel <= 0)
            {
                Console.WriteLine($"{Name} nie ma paliwa i nie może wystartować!");
                return;
            }

            if (opponent.Fuel <= 0)
            {
                Console.WriteLine($"{opponent.Name} nie ma paliwa i nie może wystartować!");
                return;
            }

            int result = Speed.CompareTo(opponent.Speed);
            Fuel -= 10;
            opponent.Fuel -= 10;

            if (result > 0)
            {
                Console.WriteLine($"{Name} wygrywa wyścig dzięki większej prędkości!");
            }
            else if (result < 0)
            {
                Console.WriteLine($"{opponent.Name} wygrywa wyścig dzięki większej prędkości!");
            }
            else
            {
                Console.WriteLine("Remis! Oba pojazdy miały tę samą prędkość.");
            }

            Console.WriteLine($"{Name} - pozostałe paliwo: {Fuel}");
            Console.WriteLine($"{opponent.Name} - pozostałe paliwo: {opponent.Fuel}");
        }
    }








}
