using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{       
        public class Player : Character
        {
            public int Batarangs { get; private set; } = 4;
            private  int maxBatarangs = 8;
            public int GadgetStunTurnsLeft { get; set; } = 0;
            public int GadgetEvadeTurnsLeft { get; set; } = 0;
            public int GadgetDisableTricksTurnsLeft { get; set; } = 0;

        public int MaxBatarangs => maxBatarangs;
            public Location CurrentLocation { get; private set; }
            public bool NextAttackMisses { get; set; } = false;
            public bool HasSmokeBomb = true;
            public bool HasGrapple = true;
            public bool HasEMP = true;

            public bool SkipNextBossTurn = false;
            public bool EvadeNextAttack = false;
            public bool DisableBossTricks = false;
            

        public Player() : base("Batman", 100, 25, 15) { }
            public void MoveTo(Location newLocation)
            {
                CurrentLocation = newLocation;
            }


            public void ThrowBatarang(Character target)
            {
                if (Batarangs > 0)
                {
                    int damage = AttackPower + 10;
                    target.Health -= damage;
                    Batarangs--;
                    Console.WriteLine($"{Name} rzuca batarangiem w {target.Name}! Zadaje {damage} obrażeń!");
                }
                else
                {
                    Console.WriteLine("Brak batarangów! Użyj zwykłego ataku.");
                }
            }
        public void AddBatarang()
        {
            if (Batarangs < MaxBatarangs)
            {
                Batarangs++;
                Console.WriteLine($"*** Uzupełniono ekwipunek: masz teraz {Batarangs} batarangów.***");
            }
            else
            {
                Console.WriteLine("*** Masz już maksymalną liczbę batarangów.***");
            }
        }
        public void UpgradeAttack()
        {
            AttackPower += 5;
            Console.WriteLine(" Ulepszono siłę ataku! Nowa wartość: " + AttackPower);
        }

        public void UpgradeDefense()
        {
            Defense += 5;
            Console.WriteLine(" Ulepszono obronę! Nowa wartość: " + Defense);
        }

        

        public void UpgradeBatarangLimit()
        {
            maxBatarangs++;
            Console.WriteLine(" Zwiększono limit batarangów do: " + maxBatarangs);
        }
        public void LowerDefense(int amount)
        {
            Defense = Math.Max(0, Defense - amount);
            Console.WriteLine($" Obrona obniżona o {amount}! Aktualna: {Defense}");
        }

        public void TakeTrueDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($" Otrzymałeś {damage} obrażeń (ignorując obronę)!");
        }
        public void Heal(int amount)
        {
            Health = Math.Min(100, Health + amount);
            Console.WriteLine($"🩹 Uleczyłeś się o {amount} HP! Aktualne zdrowie: {Health}");
        }

        
        public void UseGadget(BossEnemy boss)
        {
            Console.WriteLine(" Wybierz gadżet:");
            Console.WriteLine("1. Granat Dymny (Joker pudłuje)");
            Console.WriteLine("2. Wyrzutnia haków (unik ataku)");
            Console.WriteLine("3. EMP (blokada sztuczek)");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (HasSmokeBomb)
                    {
                        SkipNextBossTurn = true;
                        HasSmokeBomb = false;
                        GadgetStunTurnsLeft = 2;
                        Console.WriteLine(" Rzuciłeś granat dymny!");
                        Console.WriteLine("Joker: \"Ugh, ale smród! To NIE fair, Batmanie!\"");
                    }
                    else Console.WriteLine(" Nie masz już granatu.");
                    break;

                case "2":
                    if (HasGrapple)
                    {
                        EvadeNextAttack = true;
                        HasGrapple = false;
                        GadgetEvadeTurnsLeft = 2;
                        Console.WriteLine("Batman unika kolejnego ataku!");
                        Console.WriteLine("Joker: \"Stój w miejscu, szczurze!\"");
                    }
                    else Console.WriteLine(" Nie masz już wyrzutni!");
                    break;

                case "3":
                    if (HasEMP)
                    {
                        DisableBossTricks = true;
                        HasEMP = false;
                        GadgetDisableTricksTurnsLeft = 2;
                        Console.WriteLine(" EMP aktywowane!");
                        Console.WriteLine("Joker: \"CO?! Moje zabawki! Ty... TY!\"");
                    }
                    else Console.WriteLine(" EMP już użyty.");
                    break;

                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }




    }

}



    

