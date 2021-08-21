using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Entity
    {
        public string name;
        private float hp;
        public float Health
        {
            get { return hp; }
        }
        public int attack;
        public bool isTurn;
        public int critHit;
        public int defense;
        public int damageAmount;

        public Entity(string Name, int Hp, int Attack, bool IsTurn, int CritHit, int Defense)
        {
            name = Name;
            hp = Hp;
            attack = Attack;
            isTurn = IsTurn;
            critHit = CritHit;
            defense = Defense;
        }

        public int takeDamage(int damageAmount, int enemyCrit, int enemyDefense)
        {
            hp -= damageAmount * (100 - defense) / 100;

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



        public void Attack( Entity otherEntity)
        {
            otherEntity.takeDamage(attack, critHit, defense);
            Console.WriteLine($"{name} attacks the {otherEntity.name} for {attack} damage!");
            Console.WriteLine($"{otherEntity.name}'s new Hp: {otherEntity.Health}");
            Console.ReadLine();
            isTurn = false;
            otherEntity.isTurn = true;
        }

        public void Scavage()
        {

        }
    }
}
