using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public static class PenguinHack
    {
        public static bool StartHack()
        {
            Console.Clear();
            Console.WriteLine(" SYSTEM MIEJSKI WAYNE TECH – WYMAGANA AUTORYZACJA");
            Console.WriteLine(" Szukasz informacji o 'COLD STORAGE 92' – podejrzanym magazynie Pingwina.");
            Console.WriteLine(" Wprowadź hasło: (7-literowy angielski wyraz powiązany z zamrażaniem)");
            Console.WriteLine("Masz maksymalnie 3 próby na złamanie szyfru.. Do dzieła Batmanie!");

            int attempts = 3;
            while (attempts > 0)
            {
                Console.Write(" Hasło: ");
                string input = Console.ReadLine().Trim().ToUpper();

                if (input == "FREEZER")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Dostęp przyznany. Znaleziono lokalizację 'Canal Hideout'.");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    attempts--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Złe hasło. Próby pozostałe: {attempts}");
                    Console.ResetColor();

                    if (attempts == 2)
                        Console.WriteLine(" Podpowiedź: Trzyma rzeczy zimne...");
                    else if (attempts == 1)
                        Console.WriteLine(" Podpowiedź: Zaczyna się na 'F' i jest to urządzenie AGD, ma 7 liter...");
                }
            }

            Console.WriteLine(" Zbyt wiele błędów. System został zablokowany.");
            return false;
        }
    }
}
