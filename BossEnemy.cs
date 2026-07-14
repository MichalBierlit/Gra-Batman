using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public class BossEnemy: Enemy
    {
        public List<string> Taunts { get; private set; }
        private Random rng = new Random();

        public BossEnemy(string name, int health, int attack, int defense, List<string> taunts)
            : base(name, health, attack, defense)
        {
            Taunts = taunts;
        }

        public void PerformSpecialTrick(Player player)
        {
            int trick = rng.Next(4);

            switch (trick)
            {
                case 0:
                    Console.WriteLine(" Joker rzuca granat z uśmiechem! Ignoruje twoją obronę.");
                    int dmg = rng.Next(10, 20);
                    player.TakeTrueDamage(dmg);
                    break;

                case 1:
                    Console.WriteLine(" Joker śmieje się tak przeraźliwie, że tracisz koncentrację!");
                    player.LowerDefense(5);
                    break;

                case 2:
                    Console.WriteLine(" Joker znika w chmurze dymu. Twój kolejny atak chybia!");
                    player.NextAttackMisses = true;
                    break;

                case 3:
                    Console.WriteLine(" Joker wykonuje zdradziecki cios nożem!");
                    bool crit = rng.NextDouble() < 0.5;
                    int baseDmg = AttackPower - player.Defense;
                    if (crit) baseDmg *= 2;
                    player.TakeDamage(baseDmg);
                    break;
            }

            Console.ReadLine();
        }
    }
}
