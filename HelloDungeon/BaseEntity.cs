using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    interface BaseEntity
    {
        string name { get; set; }
        float Health { get; set; }
        int attack { get; set; } 
        int defense { get; set; }
        bool isTurn { get; set; }

        bool isAlive();

        void fight(BaseEntity otherEntity);

    }
}
