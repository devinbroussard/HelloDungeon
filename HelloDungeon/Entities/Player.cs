using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Player : BaseEntity
    {
        //Defining members of class
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

        public Player(string Name, int Attack, int Defense, float Health, bool _isTurn, int _critHit)
        {
            attack = Attack;
            name = Name;
            _health = Health;
            isTurn = _isTurn;
            critHit = _critHit;
            defense = Defense;
        }
        public bool isAlive()
        {
            return health > 0;
        }

        //Generic attack function that can be called using multiple enemies
        public void Attack(BaseEntity otherEntity)
        {
            float damageAmount;
            Random random = new Random();
            int rand = random.Next(0, 100);
            //Multplies attack by 1.5 on critical hits
            if (rand < otherEntity.critHit)
            {
                damageAmount = attack * 1.5f * (100 - otherEntity.defense) / 100;

                Console.WriteLine($"Critical hit!");
                Console.ReadKey();
            }
            //
            else
            {
                damageAmount = attack * (100 - otherEntity.defense) / 100;
            }


            otherEntity.health -= 60;
            if (otherEntity.health > 0) otherEntity.health = 0;

            Console.WriteLine($"{name} attacks {otherEntity.name} for {damageAmount} damage!");
            Console.WriteLine($"{otherEntity.name}'s new Hp: {otherEntity.health}");
            Console.ReadKey();

            isTurn = false;

        }
    }
}
