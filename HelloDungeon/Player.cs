using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Player : BaseEntity
    {
        public string name { get; set; }
        private float hp { get; set; }
        public float Health { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public bool isTurn { get; set; }

        public Player(string Name, int Attack, int Defense, float Hp, bool IsTurn)
        {
            attack = Attack;
            name = Name;
            hp = Hp;
            isTurn = IsTurn;

        }
        public bool isAlive()
        {
            return hp > 0;
        }

        public void fight(BaseEntity otherEntity)
        {

        }

        public float takeDamage(int damageAmount, int enemyCrit, int enemyDefense)
        {
            hp -= damageAmount * (100 - defense) / 100;

            if (hp < 0) hp = 0;


        }
    }
}
