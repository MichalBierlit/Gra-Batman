using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
     
    
        public static class RiddlerChallenge
        {
            public static bool SnakeRiddleInternal()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Riddler: \"Zabawmy się... W grę węża. Ale nie byle jakiego.\"\n");
                Console.WriteLine(" \"Masz przed sobą labirynt. Wprowadź sekwencję ruchów (W, A, S, D), aby doprowadzić węża 'S' do wyjścia 'E'.\"");
                Console.WriteLine("‼️ \"Nie rozbij się o ścianę (#) ani nie wyjdź poza mapę. Powodzenia.\"\n");
                Console.ResetColor();

                char[,] map = {
                { '#', '#', '#', '#', '#' },
                { '#', 'S', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', '#' },
                { '#', ' ', '#', 'E', '#' },
                { '#', '#', '#', '#', '#' }
            };

                int playerX = 1;
                int playerY = 1;

                void DrawMap()
                {
                    
                    for (int y = 0; y < map.GetLength(0); y++)
                    {
                        for (int x = 0; x < map.GetLength(1); x++)
                        {
                            Console.Write(map[y, x]);
                        }
                        Console.WriteLine();
                    }
                }

                DrawMap();
                Console.WriteLine("\n Wpisz sekwencję ruchów (np. SDDS):");
                Console.Write(" Ruchy: ");
                string input = Console.ReadLine().ToUpper();
                

                foreach (char move in input)
                {
                    map[playerY, playerX] = ' ';

                    switch (move)
                    {
                        case 'W': playerY--; break;
                        case 'S': playerY++; break;
                        case 'A': playerX--; break;
                        case 'D': playerX++; break;
                        default:
                            Console.WriteLine(" Niepoprawny znak w ruchach.");
                            return false;
                    }

                    if (playerX < 0 || playerX >= map.GetLength(1) ||
                        playerY < 0 || playerY >= map.GetLength(0) ||
                        map[playerY, playerX] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Rozbiłeś się o ścianę! Riddler: \"HAHAHA! Może następnym razem...\"");
                        Console.ResetColor();
                        Console.ReadLine();
                        return false;
                    }

                    if (map[playerY, playerX] == 'E')
                    {
                        map[playerY, playerX] = 'S';
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Riddler: \"Niemożliwe... przeszedłeś pierwszy test!\"");
                        Console.ResetColor();
                        Console.WriteLine("Naciśnij Enter, aby przejść dalej...");
                        Console.ReadLine();
                        return true;
                    }

                    map[playerY, playerX] = 'S';
                    
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Nie dotarłeś do wyjścia. Riddler: \"Jak zwykle zawiodłeś, Batmanie.\"");
                Console.ResetColor();
                Console.ReadLine();
                return false;
            }

            public static bool MemoryBombInternal()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Riddler: \"Zobaczmy, jak masz się z pamięcią, Nietoperzu...\"");
                Console.WriteLine(" \"Przed Tobą druga z zagadek --->` bomba z cyfrowym zamkiem. Musisz odtworzyć sekwencję przycisków, zanim eksploduje.\"");
                Console.WriteLine(" \"Masz tylko kilka sekund na zapamiętanie!\"");
                Console.ResetColor();
                Console.WriteLine("Naciśnij Enter, by zobaczyć sekwencję...");
                Console.ReadLine();

                Random rng = new Random();
                string[] symbols = { "A", "B", "X", "Y" }; // możliwe przyciski
                int sequenceLength = 5;
                string sequence = "";

                for (int i = 0; i < sequenceLength; i++)
                {
                    sequence += symbols[rng.Next(symbols.Length)];
                }

                Console.Clear();
                Console.WriteLine(" Sekwencja:");
                Console.WriteLine($" {sequence}");
                Thread.Sleep(3000); // 3 sekundy na zapamiętanie

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Riddler: \"No dobrze. Teraz ją wpisz, litera po literze (bez spacji):\"");
                Console.ResetColor();
                Console.Write(" Twoja odpowiedź: ");
                string answer = Console.ReadLine().ToUpper();

                if (answer == sequence)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Riddler: \"Imponujące... twoje szare komórki jeszcze żyją.\"");
                    Console.ResetColor();
                    Console.WriteLine("Naciśnij Enter, aby przejść dalej...");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" BOOOOM! Sekwencja była błędna.");
                    Console.ResetColor();
                    Console.WriteLine($"Prawidłowa: {sequence}");
                    return false;
                }

                
            }

            public static bool SejfRiddleraInternal()
            {   
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Riddler: \"Dotarłeś do mojego sejfu...\"");
                Console.WriteLine("\"Aby go otworzyć, musisz rozwiązać tę ostatnią zagadkę logiczną.\"");
                Console.WriteLine(" Zagadnienie:");
                Console.WriteLine();
                Console.WriteLine("„Jestem trzema liczbami.");
                Console.WriteLine("Ich suma to 14.");
                Console.WriteLine("Największa z nich to suma dwóch pozostałych.”");
                Console.ResetColor();
                Console.WriteLine("Wprowadź kod w formacie: X Y Z (oddziel spacją)");
                Console.WriteLine();

                Console.Write(" Twój kod: ");
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');

                if (parts.Length != 3 ||
                    !int.TryParse(parts[0], out int a) ||
                    !int.TryParse(parts[1], out int b) ||
                    !int.TryParse(parts[2], out int c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Riddler: \"To nie są nawet liczby... WSTYD!\"");
                    Console.ResetColor();
                    Console.ReadLine();
                    return false;
                }
                
                int sum = a + b + c;
                int max = Math.Max(a, Math.Max(b, c));
                int other1 = (a == max) ? b : a;
                int other2 = (c == max || (a == max && b == c)) ? b : c;

                if (sum == 14 && max == other1 + other2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Riddler: \"KOD POPRAWNY. Sejf otwarty...\"");
                    Console.ResetColor();
                    Console.WriteLine(" \nW środku znajdujesz dokumenty potwierdzające testy Smylex-X na dzieciach z sierocińca...");
                    Console.WriteLine(" Joker, Nygma i Pingwin pracowali razem. Gotham jest w większym niebezpieczeństwie, niż myślałeś.");
                    Console.WriteLine("Zabierasz Riddlera na komisariat.. ");
                    return true;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Riddler: \"Złe liczby, Nietoperzu. Sejf zablokowany. Przegrałeś swoją ostatnią szansę.\"");
                    Console.ResetColor();
                    return false;
                }

                
            }
            public static bool RunRiddles()
            {
                while (true) 
                {
                    int score = 0;

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Riddler: \"Czas na Twój prawdziwy test. Trzy zagadki. Zero błędów.\"");
                    Console.WriteLine(" Jeśli się potkniesz... zaczynamy od nowa.");
                    Console.ResetColor();
                    Console.WriteLine("Naciśnij Enter, aby rozpocząć...");
                    Console.ReadLine();

                    // Snake
                    if (SnakeRiddleInternal())
                    {
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\n ZAWIODŁEŚ w 1. zagadce. Restartuję próbę...");
                        Console.ReadLine();
                        continue;
                    }

                    // Memory
                    if (MemoryBombInternal())
                    {
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\n ZAWIODŁEŚ w 2. zagadce. Restartuję próbę...");
                        Console.ReadLine();
                        continue;
                    }

                    // Sejf
                    if (SejfRiddleraInternal())
                    {
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\n ZAWIODŁEŚ w 3. zagadce. Restartuję próbę...");
                        Console.ReadLine();
                        continue;
                    }

                    
                    return score == 3;
                }
            }





        }
    }

