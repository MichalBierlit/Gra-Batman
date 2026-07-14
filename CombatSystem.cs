using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public class CombatSystem
    {
        public static void StartCombat(Player player, Enemy enemy)
        {
            Console.WriteLine("Nacisnij enter, aby przejśc do walki...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"***** WALKA: {player.Name} vs {enemy.Name} *****");
            
            while (player.IsAlive && enemy.IsAlive)
            {
                

                Console.WriteLine($"\n# {player.Name} HP: {player.Health} | Batarangi: {player.Batarangs}");
                Console.WriteLine($"#  {enemy.Name} HP: {enemy.Health}");
                Console.WriteLine("\nCo chcesz zrobić?");
                Console.WriteLine("1. Zwykły atak");
                Console.WriteLine("2. Rzut batarangiem (+10 dmg)");
                Console.WriteLine("3. Leczenie (+10 HP)");
                Console.WriteLine("4. Ucieczka");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        player.Attack(enemy);
                        break;

                    case "2":
                        player.ThrowBatarang(enemy);
                        break;

                    case "3":
                        player.Heal(10);
                        break;

                    case "4":
                        Console.WriteLine("Uciekasz z pola walki...");
                        return;

                    default:
                        Console.WriteLine("Nie rozpoznano komendy.");
                        continue;
                }

                if (!enemy.IsAlive)
                {
                    Console.WriteLine($" Pokonałeś {enemy.Name}!");
                    break;
                }

                Console.WriteLine($"\n{enemy.Name} kontratakuje!");
                enemy.Attack(player);

                if (!player.IsAlive)
                {
                    Console.WriteLine(" Zostałeś pokonany. Gotham pogrąża się w chaosie...");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("\nNaciśnij Enter, by kontynuować...");
            Console.ReadLine();
        }
        public static void StartBossCombat(Player player, BossEnemy boss)
        {
            Random rng = new Random();

            int turnCount = 0;
            while (player.IsAlive && boss.IsAlive)
            {
                turnCount++;
                Console.Clear();
                if (player.GadgetStunTurnsLeft > 0) player.GadgetStunTurnsLeft--;
                if (player.GadgetEvadeTurnsLeft > 0) player.GadgetEvadeTurnsLeft--;
                if (player.GadgetDisableTricksTurnsLeft > 0) player.GadgetDisableTricksTurnsLeft--;
                bool bossStunned = player.GadgetStunTurnsLeft > 0;
                bool evadeActive = player.GadgetEvadeTurnsLeft > 0;
                bool tricksDisabled = player.GadgetDisableTricksTurnsLeft > 0;

                if (turnCount == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(" SYSTEM AWARYJNY: Oświetlenie awaryjne aktywne.");
                    Console.WriteLine(" Światła migoczą czerwienią...");
                    Console.ResetColor();
                }

                if (turnCount == 4)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(" UWAGA: Cela 7 została otwarta!");
                    Console.WriteLine(" Joker wypuszcza iluzję... ale to tylko cień.");
                    Console.ResetColor();
                }

                if (turnCount == 6)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(" Gaz Smylex-X przedostaje się do wentylacji...");
                    Console.WriteLine(" Obraz się rozmazuje. Walka staje się chaotyczna.");
                    Console.ResetColor();
                }
                
                Console.WriteLine($" {player.Name} HP: {player.Health}");
                Console.WriteLine($" {boss.Name} HP: {boss.Health}");
                Console.WriteLine($" Batarangi: {player.Batarangs}\n");

                Console.WriteLine("Wybierz akcję:");
                Console.WriteLine("1. Szybki atak");
                Console.WriteLine("2. Rzut batarangiem (+10 AD)");
                Console.WriteLine("3. Leczenie (+20 HP)");
                Console.WriteLine("4. Użyj gadżetu");

                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        if (player.NextAttackMisses)
                        {
                            Console.WriteLine(" Twój atak chybia! Joker zniknął!");
                            player.NextAttackMisses = false;
                        }
                        else player.Attack(boss);
                        break;

                    case "2":
                        player.ThrowBatarang(boss);
                        break;

                    case "3":
                        player.Heal(20);
                        break;

                    case "4":
                        player.UseGadget(boss);
                        if (player.NextAttackMisses)
                        {
                            Console.WriteLine(" Twój atak chybia! Joker zniknął!");
                            player.NextAttackMisses = false;
                        }
                        else
                        {
                            player.Attack(boss);
                        }
                        break;
                       

                    default:
                        Console.WriteLine(" Zły wybór. Tracisz turę.");
                        break;
                }

                if (!boss.IsAlive) break;

                Console.WriteLine("\nJoker szykuje się do ruchu...");
                string taunt = boss.Taunts[rng.Next(boss.Taunts.Count)];
                Console.WriteLine(taunt);

                if (player.SkipNextBossTurn)
                {
                    Console.WriteLine(" Joker kaszle w dymie – traci turę!");
                    player.SkipNextBossTurn = false;
                }
                else
                {
                    if (rng.Next(0, 3) == 0 && !player.DisableBossTricks)
                    {
                        boss.PerformSpecialTrick(player);
                    }
                    else
                    {
                        if (player.EvadeNextAttack)
                        {
                            Console.WriteLine(" Batman unika ataku dzięki hakowi!");
                            player.EvadeNextAttack = false;
                        }
                        else
                        {
                            boss.Attack(player);
                        }
                    }
                }

                
                Console.WriteLine("\nNaciśnij Enter, by kontynuować...");
                Console.ReadLine();
            }

            if (!player.IsAlive)
            {
                Effects.JokerFaceJumpScare();
                Console.WriteLine(" Joker wygrał. Gotham kona.");
                Environment.Exit(0);
            }
            else
            {
                Effects.BossExplosion();
                Console.WriteLine($" Pokonałeś {boss.Name}!");
            }
            player.GadgetStunTurnsLeft = 0;
            player.GadgetEvadeTurnsLeft = 0;
            player.GadgetDisableTricksTurnsLeft = 0;
        }


    }

    public class Enemy : Character
    {
        public Enemy(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense) { }
    }
}

