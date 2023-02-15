using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class GameField
    {
        Random rand = new Random();
        private char[,] fillfield(char[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = ' ';
                }
            }
            return arr;
        }
        public void field(char[,] arr, int snakeposx, int snakeposy)
        {
            Console.CursorVisible = false;
            fillfield(arr);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (i == 0)
                    {
                        arr[i,j] = '*';
                        Console.Write(arr[i,j]);
                    }
                    if (i == arr.GetLength(0) - 1)
                    {
                        arr[i,j] = '*';
                        Console.Write(arr[i,j]);
                    }
                    if (j == 0)
                    {
                        arr[i, j] = '*';
                        Console.Write(arr[i, j]);
                    }
                    if (i > 1 & i < arr.GetLength(0) - 1 & j > 0)
                    {
                        arr[i, j] = ' ';
                        arr[snakeposx, snakeposy] = 'S';
                        Console.Write(arr[i,j]);
                    }
                    if (j == arr.GetLength(0) - 1)
                    {
                        arr[i, j] = '*';
                        Console.Write(arr[i,j]);
                    }
                }
                Console.WriteLine();
            }

        }
        public void snakebackerase(int counter, List<int> snakedatax,List<int> snakedatay, char[,] arr)
        {
            arr[snakedatay[counter],snakedatax[counter]] = ' ';
        }
        public int randomfood()
        {
            int foodpos = rand.Next(1, 19);
            return foodpos;
        }
        public int fruitappear(int fruitposx, int fruitposy, char[,] arr)
        {
            while (arr[fruitposy,fruitposx] != ' ')
            {
                fruitposx = randomfood();
            }
            return fruitposx;
        }
    }
}
