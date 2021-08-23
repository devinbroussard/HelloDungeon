using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Game
    {
        public void Run()
        {
            Scenes scenes = new Scenes();
            scenes.StartGame();
        }
    }
}