using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiating the guess number game class
            GuessTheNumberGame Game1 = new GuessTheNumberGame();

            //starting the game
            Game1.Start();
        }
    }
}
