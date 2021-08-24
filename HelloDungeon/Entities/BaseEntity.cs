using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    interface BaseEntity
    {
        string name { get; set; }
        float health { get; set; }
        int attack { get; set; } 
        int defense { get; set; }
        bool isTurn { get; set; }
        int critHit { get; set; }

        bool isAlive();
        void Attack(BaseEntity otherEntity);
        void takeDamage(float damageAmount);
    }
}
