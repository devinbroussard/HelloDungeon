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
        public Entity(string Name, int Hp, int Attack, bool IsTurn)
        {
            name = Name;
            hp = Hp;
            attack = Attack;
            isTurn = IsTurn;
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
    }
}
