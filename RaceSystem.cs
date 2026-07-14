using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public class RaceSystem
    {

        public static void PursuitRace(Batmobil batmobil, PenguinMaserati pingwin,RaceStatus status)
        {
            Console.WriteLine("\n Pościg rozpoczęty! Batmobil ściga Maserati Pingwina!");

            int distance = 100; // dystans między pojazdami
            int turns = 5;

            for (int i = 1; i <= turns; i++)
            {
                Console.Clear();
                Console.WriteLine($"\n--- Tura {i} ---");
                Console.WriteLine($" Odległość: {distance} metrów");
                batmobil.Fuel -= 10;
                pingwin.Fuel -= 10;
                Console.WriteLine($" Batmobil paliwo: {batmobil.Fuel}, Maserati: {pingwin.Fuel}");

                if (batmobil.Fuel <= 0)
                {
                    Console.WriteLine(" Batmobilowi zabrakło paliwa! Pingwin ucieka!");
                    return;
                }

                if (pingwin.Fuel <= 0)
                {
                    Console.WriteLine(" Maserati Pingwina gaśnie! Batman go dopada!");
                    status.WyscigWygrany = true;
                    return;
                }

                // Pingwin sabotuje?
                if (new Random().Next(0, 3) == 0) // 1/3 szansy
                {
                    Console.WriteLine(" Pingwin wypuszcza plamę oleju!");
                    pingwin.LaunchOilSlick();
                    batmobil.Speed -= 10;
                }

                // Gracz próbuje odpalić Turbo
                batmobil.TurboBoostMiniGame();

                // Obliczamy różnicę prędkości
                int difference = batmobil.Speed - pingwin.Speed;
                distance -= difference;

                // Aktualne info
                Console.WriteLine($" Batmobil prędkość: {batmobil.Speed},  Pingwin prędkość: {pingwin.Speed}");
                Console.WriteLine($" Batmobil zbliżył się o {difference} metrów");

                // Reset prędkości jeśli było Turbo
                if (batmobil.TurboBoostActive)
                {
                    batmobil.Speed -= 50;
                    batmobil.TurboBoostActive = false;
                }

                if (distance <= 0)
                {
                    Console.WriteLine(" Batmobil dogonił Maserati Pingwina! Pingwin zostaje zatrzymany!");
                     status.WyscigWygrany= true;
                    return;
                }

                Thread.Sleep(1500); // chwilowe opóźnienie dla klimatu
            }

            // Po 5 turach
            if (distance > 0)
            {
                Console.WriteLine(" Pingwin ucieka! Batmobil nie zdążył go dogonić!");
            }

        }

    }
    public class RaceStatus
    {
        public bool WyscigWygrany { get; set; } = false;
    }

}
