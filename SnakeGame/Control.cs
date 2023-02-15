using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Control
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey key = ConsoleKey.DownArrow;
        public void keyinput()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            }
        }
        public bool gameover(bool isgameover, int snakepos, char[,] arr)
        {
            if(snakepos < 1 | snakepos >= arr.GetLength(0) - 1)
            {                
                isgameover = true;
            }
            return isgameover;
        }
        public bool iscolision(int snakeposx, int snakeposy, char[,] arr)
        {
            bool colision = false;
            if (arr[snakeposx,snakeposy] == 'S')
            {
                colision = true;
            }
            return colision;
        }
        public void gameoverinfo(int score)
        {
            Console.Clear();
            Console.WriteLine("Game over");
            Console.WriteLine("Score: " + score);
        }
    }
}
