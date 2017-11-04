using WarriorWars.Equipment;
using WarriorWars.Enum;
using System;

namespace WarriorWars
{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 5;
        private const int BAD_GUY_STARTING_HEALTH = 5;

        private readonly Faction FACTION;

        private int health;
        private int killCounter;
        private string name;
        private bool isAlive;

        private Weapon weapon;
        private Armor armor;

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
        }

        public Warrior(string name, Faction faction)
        {
            this.name = name;
            FACTION = faction;
            isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;

                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;

                    break;
                default:
                    break;
            }
        }

        public void Attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;
            enemy.health -= damage;

            AttackResult(enemy, damage);
        }

        private void AttackResult(Warrior enemy, int damage)
        {
            if (enemy.health <= 0)
            {
                killCounter++;
                enemy.isAlive = false;
                Tools.ColorfulWriteLine($"{enemy.name} is dead!", ConsoleColor.Red);
                Tools.ColorfulWriteLine($"{name} is victorious!", ConsoleColor.Green);
                
            }
            else
            {
                Console.WriteLine($"{name} attacked {enemy.name}. {damage} damage was inflicted to {enemy.name}, remaining health of {enemy.name} is {enemy.health}");
            }
        }
        
    }
}
