using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public class Batmobil : Vehicle
    {
            public bool TurboBoostActive { get;  set; }

            public Batmobil()
                : base("Batmobil", speed: 165,  fuel: 100)
            {
                TurboBoostActive = false;
            }

            public void TurboBoostMiniGame()
            {
                Console.WriteLine(" Aby aktywować Turbo Boost, naciśnij klawisz 'X' w ciągu 2 sekund!");
                Console.Write("Gotów? Naciśnij Enter...");
                Console.ReadLine();

                Console.WriteLine("...START!");

                Stopwatch timer = Stopwatch.StartNew();
                while (timer.ElapsedMilliseconds < 2000)
                {
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.X)
                    {
                        Speed += 50;
                        Fuel -= 20;
                        TurboBoostActive = true;
                        Console.WriteLine(" Turbo Boost aktywowany! Prędkość zwiększona!");
                        return;
                    }
                }

                Console.WriteLine(" Za późno! Nie udało się aktywować Turbo.");
            }

            
        }
    }

