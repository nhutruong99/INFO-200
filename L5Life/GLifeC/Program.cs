//Nhu Truong
//2020-01-16
//TINFO 200 Game of Life simulation
//Change HIstory 
//Date          Developer       Descroiption

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLifeC
{
    class Program
    {
        //
        static void Main(string[] args)
        {
            //create a top level object that represents the game
            Game game = new Game();

            //start the main game simulation
            game.PlayGame();


        }
    }
}
