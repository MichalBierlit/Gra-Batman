using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public class Character
    {
        public string Name { get; protected set; }
        public int Health { get;  set; }
        public int AttackPower { get; protected set; }
        public int Defense { get; protected set; }
        public bool IsAlive => Health > 0;

        public Character(string name, int health, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
        }

        public virtual void Attack(Character target)
        {
            int maxDamage = Math.Max(1, AttackPower - target.Defense);
            int damage = new Random().Next(1, maxDamage + 1); // losowa wartość od 1 do maxDamage (włącznie)
            target.Health -= damage;
            Console.WriteLine($"{Name} atakuje {target.Name} i zadaje {damage} obrażeń!");
        }
        public virtual void TakeDamage(int damage)
        {
            Health -= Math.Max(0, damage);
            Console.WriteLine($"{Name} otrzymuje {damage} obrażeń.");
        }

        public virtual void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} leczy się o {amount} punktów zdrowia!");
        }
    }
}
