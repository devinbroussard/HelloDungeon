using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Enemy : BaseEntity
    {
        public string name { get; set; }
        private float _health;
        public float health
        {
            get { return _health; }
            set { }
        }
        public int attack { get; set; }
        public int defense { get; set; }
        public bool isTurn { get; set; }
        public int critHit { get; set; }
        public float damageAmount { get; set; }

        public Enemy(string Name, int Attack, int Defense, float Health, bool _isTurn, int _critHit)
        {
            attack = Attack;
            name = Name;
            _health = Health;
            isTurn = _isTurn;
            critHit = _critHit;
        }
        public bool isAlive()
        {
            return health > 0;
        }

        public float takeDamage(float damageAmount, int enemyCrit, int enemyDefense)
        {
            Random random = new Random();
            int rand = random.Next(1, 101);

            if (rand < enemyCrit)
            {
                damageAmount = damageAmount * 1.5f * (100 - enemyDefense) / 100;
                health -= damageAmount;
            }
            else
            {
                damageAmount = damageAmount * (100 - enemyDefense) / 100;
                health -= damageAmount;
            }

            if (health < 0) health = 0;
            return damageAmount;
        }

        public void Attack(BaseEntity otherEntiity)
        {
            otherEntiity.takeDamage(attack, critHit, defense);
            Console.WriteLine($"{name} attacks {otherEntiity.name} for {damageAmount} damage!");
            Console.WriteLine($"{otherEntiity.name}'s new HP: {otherEntiity.health}");
            isTurn = false;
            otherEntiity.isTurn = true;

        }
    }
}
