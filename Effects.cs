using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    
        public static class Effects
        {
            public static void JokerLaugh()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
          HA
        HA   HA
      HA  HA  HA     HAHAHAHAHA!
    HA  HA  HA  HA   HEHEHEHEHE!
    HAHAHAHAHAHAHA   HIHIHIHIHI!");
                Console.ResetColor();
                Thread.Sleep(800);
            }

            public static void JokerShockEffect()
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.BackgroundColor = i % 2 == 0 ? ConsoleColor.DarkRed : ConsoleColor.DarkMagenta;
                    Console.Clear();
                    Console.WriteLine("*** JOKER ATAKUJE! ***");
                    Thread.Sleep(150);
                }
                Console.ResetColor();
                Console.Clear();
            }

            public static void BossExplosion()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@"
        █████ BOOM █████
        █▒▒▒▒▒▒▒▒▒▒▒▒▒▒█
        █▒💥💥  KABOOM  💥💥▒█
        █▒▒▒▒▒▒▒▒▒▒▒▒▒▒█
        ███████████████
        ");
                Console.ResetColor();
                Thread.Sleep(1000);
            }

            public static void JokerFaceJumpScare()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"    ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                                        ⣿⣿⣿⣿⣿⣿⣿⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢦⠙⢿⣿⣿⣿⣿⣿⣿⣿
                                        ⣿⣿⣿⣿⢯⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢃⠛⢿⣿⣿⣿⣿⣿
                                        ⣿⣿⣿⢧⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡕⠂⠈⢻⣿⣿⣿⣿
                                        ⣿⣿⡅⣻⡿⢿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠿⢿⣿⡇⠀⠀⠈⣿⣿⣿⣿
                                        ⣿⣿⠀⠀⠀⠘⣿⣿⣿⣿⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⣹⣿⣿⣿
                                        ⣿⣿⠀⠀⠀⠀⣿⣿⡿⠿⠛⠻⣿⣿⣿⣿⡿⠟⠁⠈⠀⠉⠻⡆⠀⠀⠀⣿⣿⣿
                                        ⣿⣯⠄⠂⠀⠀⣿⡋⠀⢀⠀⠀⠀⠉⣿⣿⡀⠀⠀⠘⠓⣠⣶⣿⡀⠀⠀⠘⣿⣿
                                        ⣿⣫⡆⠀⠀⢀⣿⣷⣶⣄⠀⢀⣤⣴⣿⣿⣿⣶⣄⠀⣴⣿⣿⣿⠁⠀⠀⠀⠘⣿
                                        ⣿⣿⠁⠀⠀⡤⠙⢿⣿⣿⣷⣾⣿⡿⣿⣿⢿⠿⣿⣧⣿⣿⡿⢣⠀⠀⠀⠀⢠⣿
                                        ⣷⣌⠈⠀⠀⠀⠀⣆⠈⡉⢹⣿⣿⣆⡀⠀⠀⢠⣿⣿⣿⡿⢃⣼⠀⠀⠀⠀⣸⣿
                                        ⣿⣿⡇⠀⠀⠀⠀⠙⢿⣿⣆⠈⠛⠛⠛⠀⠀⠈⠉⠁⠀⢠⣿⠇⠀⠀⠀⠹⢿⡇
                                        ⣿⡫⠀⠀⠁⠀⠀⠀⠈⠻⣿⢢⣄⠀⠀⠀⠀⠀⣀⣠⣾⡾⠋⠀⠀⠀⠀⢀⠴⠋
                                        ⣿⣁⠄⠀⠀⠀⣀⠀⠀⠀⠈⠛⠿⣿⣿⣿⣿⣿⠿⡿⠋⠀⠀⠀⠀⠀⣀⠬⠆⢀
                                        ⣿⣿⣧⣄⠀⠀⠉⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠠⠙
          HAHAHAHAHA!");
                Thread.Sleep(800);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" JOKER: „Widzisz mnie, Nietoperzu?! Zobacz co zrobiłeś!”");
                Thread.Sleep(1500);
                Console.ResetColor();
                Console.Clear();
            }
        public static void CasinoGothamIntro()
        {
            string[] frames = new string[]
            {
            "                                   W I T A M Y   W   C A S I N O   G O T H A M !",
            "                                       SZANSA NA WSZYSTKO... ALBO NIC ?",
            "                                   OBSTAW I PRZEKONAJ SIĘ, CZY LOS CI SPRZYJA ?"
            };

            for (int i = 0; i < 3; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@"
                ................................................................................
                .   ██████╗ █████╗ ███████╗██╗███╗   ██╗ ██████╗     ██████╗  ██████╗ ████████╗ .
                .  ██╔════╝██╔══██╗╚══███╔╝██║████╗  ██║██╔═══██╗    ██╔══██╗██╔═══██╗╚══██╔══╝ .
                .  ██║     ███████║  ███╔╝ ██║██╔██╗ ██║██║   ██║    ██████╔╝██║   ██║   ██║    .
                .  ██║     ██╔══██║ ███╔╝  ██║██║╚██╗██║██║   ██║    ██╔═══╝ ██║   ██║   ██║    .
                .  ╚██████╗██║  ██║███████╗██║██║ ╚████║╚██████╔╝    ██║     ╚██████╔╝   ██║    .
                .   ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝╚═╝  ╚═══╝ ╚═════╝     ╚═╝      ╚═════╝    ╚═╝    .
                ................................................................................
                ");
                Console.WriteLine(frames[i % frames.Length]);

                Console.Beep(800 + (i * 200), 150); 
                Thread.Sleep(900);
                Console.ResetColor();
            }

            Thread.Sleep(500);
            Console.Clear();
        }
    }

    }

