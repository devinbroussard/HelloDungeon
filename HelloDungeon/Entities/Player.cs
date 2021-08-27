using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    //Player class created from the BaseEntity interface
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

        //Constructor used to declare variable values when creating instance of class
        public Player(string Name, int Attack, int Defense, float Health, bool _isTurn, int _critHit)
        {
            attack = Attack;
            name = Name;
            _health = Health;
            isTurn = _isTurn;
            critHit = _critHit;
            defense = Defense;
        }
        //Function used to check if entity is alive
        public bool isAlive()
        {
            return health > 0;
        }

        //Function used to deal damage to the private health variable
        public void takeDamage(float damageAmount)
        {
            _health -= damageAmount;

            if (_health < 0)
            {
                _health = 0;
            }
        }

        //Generic attack function that can be called using multiple enemiesa
        public void Attack(BaseEntity otherEntity)
        {
            //variable used for the actual damage that the otherEntity will be hit for, accounting for defense, crit, etc
            float damageAmount;
            //creating a random int that will determine if the attack was a critical hit
            Random random = new Random();
            int rand = random.Next(0, 100);


            //Multplies attack by 1.5 on critical hits
            if (rand < otherEntity.critHit)
            {
                damageAmount = attack * 1.5f * (100 - otherEntity.defense) / 100;

                Console.WriteLine($"Critical hit incoming!\n");
                Console.ReadKey();
            }
            //If not a critical, attacks normally
            else
            {
                damageAmount = attack * (100 - otherEntity.defense) / 100;
            }
            otherEntity.takeDamage(damageAmount);

            Console.WriteLine($"{name} attacks {otherEntity.name} for {damageAmount} damage!");
            Console.WriteLine($"{otherEntity.name}'s new Hp: {otherEntity.health}\n");
            Console.ReadKey();

            //Changes turn to the other entity
            isTurn = false;
            otherEntity.isTurn = true;

        }
    }
}
