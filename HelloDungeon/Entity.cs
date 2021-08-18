using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Entity
    {
        public string name;
        private int hp;
        public int Health
        {
            get { return hp; }
        }
        public int attack;
        public bool isTurn;
        public int critHit;
        public int defense;

        public Entity(string Name, int Hp, int Attack, bool IsTurn, int CritHit, int Defense)
        {
            name = Name;
            hp = Hp;
            attack = Attack;
            isTurn = IsTurn;
            critHit = CritHit;
            defense = Defense;
        }

        public int takeDamage(int damageAmount)
        {
            hp -= damageAmount;

            if (hp < 0)
            {
                hp = 0;
            }

            return damageAmount;
        }
        public bool isAlive()
        {
            return hp > 0;
        }

        public void Fight(Entity otherEntity)
        {
            otherEntity.takeDamage(attack);
            Console.WriteLine($"{name} attacks the {otherEntity.name} for {attack} damage!");
            Console.WriteLine($"{otherEntity.name}'s new Hp: {otherEntity.Health}");
            Console.ReadLine();
            isTurn = false;
            otherEntity.isTurn = true;
        }
    }
}
