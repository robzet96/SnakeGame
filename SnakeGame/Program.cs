using SnakeGame;

Control Control = new Control();
GameField GameField = new GameField();
PlayerFunctions Functions = new PlayerFunctions();

char[,] arr = new char[20, 20];
List<int> SnakePosDataX = new List<int>();
List<int> SnakePosDataY = new List<int>();
int snakeposy = 10;
int snakeposx = 10;
SnakePosDataY.Add(snakeposy);
SnakePosDataX.Add(snakeposx);
bool isgameover = false;
Random randx = new Random();
Random randy = new Random();
var tmp = ConsoleKey.DownArrow;
var prevkey = tmp;
int fruitx = GameField.randomfood();
int fruity = GameField.randomfood();
int counter = 0;
int score = 0;
int speed = 300;
string choice = string.Empty;
while (true)
{
    Console.Clear();
    Console.WriteLine("1. Play the game\n" +
        "2. Highscores\n" +
        "3. Quit");
    choice = Console.ReadLine();
	switch (choice)
	{
		case "1":
            counter = 0;
            score = 0;
            SnakePosDataX.Clear();
            SnakePosDataY.Clear();
            isgameover = false;
            snakeposy = 10;
            snakeposx = 10;
            SnakePosDataY.Add(snakeposy);
            SnakePosDataX.Add(snakeposx);
            tmp = ConsoleKey.DownArrow;
            Console.WriteLine("Choose game mode: \n" +
                "[E]asy\n" +
                "[M]edium\n" +
                "[H]ard");
            string gamemode = string.Empty;
            while (gamemode.ToLower() != "e" ^ gamemode.ToLower() != "m" ^  gamemode.ToLower() != "h")
            {
                gamemode = Console.ReadLine();
            }
            if (gamemode.ToLower() == "e")
            {
                speed = 500;
            }
            else if (gamemode.ToLower() == "m")
            {
                speed = 300;
            }
            else if (gamemode.ToLower() == "h")
            {
                speed = 100;
            }
            GameField.field(arr, snakeposy, snakeposx);
            while (!Control.gameover(isgameover, snakeposy, arr))
            {
                Console.WriteLine(score);
                arr[fruity, fruitx] = 'F';
                switch (tmp)
                {
                    case ConsoleKey.UpArrow:
                        do
                        {
                            while (!Console.KeyAvailable)
                            {
                                snakeposy--;
                                SnakePosDataY.Add(snakeposy);
                                SnakePosDataX.Add(snakeposx);
                                if (Control.gameover(isgameover, snakeposy, arr))
                                {
                                    Control.gameoverinfo(score);
                                    goto TheEnd;
                                }
                                if (Control.iscolision(snakeposy, snakeposx, arr))
                                {
                                    Control.gameoverinfo(score);
                                    goto TheEnd;
                                }
                                Console.Clear();
                                for (int i = 0; i < arr.GetLength(0); i++)
                                {
                                    for (int j = 0; j < arr.GetLength(1); j++)
                                    {
                                        GameField.snakebackerase(counter, SnakePosDataX, SnakePosDataY, arr);
                                        if (snakeposx == fruitx && snakeposy == fruity)
                                        {
                                            counter--;
                                            fruitx = GameField.randomfood();
                                            fruity = GameField.randomfood();
                                            if (arr[fruity, fruitx] != ' ')
                                            {
                                                fruitx = GameField.fruitappear(fruitx, fruity, arr);
                                            }
                                            arr[fruity, fruitx] = 'F';
                                            score += 10;
                                        }
                                        arr[snakeposy, snakeposx] = 'S';
                                        Console.Write(arr[i, j]);
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Score: " + score);
                                Thread.Sleep(speed);
                                counter++;
                            }
                            if (isgameover != true)
                            {
                                tmp = Console.ReadKey(true).Key;
                                prevkey = ConsoleKey.UpArrow;
                            }
                            else
                            {
                                break;
                            }
                        } while (tmp == ConsoleKey.UpArrow);
                        break;
                    case ConsoleKey.DownArrow:
                        do
                        {
                            while (!Console.KeyAvailable)
                            {
                                snakeposy++;
                                SnakePosDataY.Add(snakeposy);
                                SnakePosDataX.Add(snakeposx);
                                if (Control.gameover(isgameover, snakeposy, arr))
                                {
                                    Control.gameoverinfo(score);
                                    goto TheEnd;
                                }
                                if (Control.iscolision(snakeposy, snakeposx, arr))
                                {
                                    Control.gameoverinfo(score);
                                    goto TheEnd;
                                }
                                Console.Clear();
                                for (int i = 0; i < arr.GetLength(0); i++)
                                {
                                    for (int j = 0; j < arr.GetLength(1); j++)
                                    {
                                        GameField.snakebackerase(counter, SnakePosDataX, SnakePosDataY, arr);
                                        if (snakeposx == fruitx && snakeposy == fruity)
                                        {
                                            counter--;
                                            fruitx = GameField.randomfood();
                                            fruity = GameField.randomfood();
                                            if (arr[fruity, fruitx] != ' ')
                                            {
                                                fruitx = GameField.fruitappear(fruitx, fruity, arr);
                                            }
                                            arr[fruity, fruitx] = 'F';
                                            score += 10;
                                        }
                                        arr[snakeposy, snakeposx] = 'S';
                                        Console.Write(arr[i, j]);
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Score: " + score);
                                Thread.Sleep(speed);
                                counter++;
                            }
                            if (isgameover != true)
                            {
                                tmp = Console.ReadKey(true).Key;
                                prevkey = ConsoleKey.DownArrow;
                            }
                            else
                            {
                                break;
                            }
                        } while (tmp == ConsoleKey.DownArrow);
                        break;
                    case ConsoleKey.LeftArrow:
                        do
                        {
                            while (!Console.KeyAvailable)
                            {
                                snakeposx--;
                                SnakePosDataY.Add(snakeposy);
                                SnakePosDataX.Add(snakeposx);
                                if (Control.gameover(isgameover, snakeposx, arr))
                                {
                                    Control.gameoverinfo(score);
                                    goto TheEnd;
                                }
                                if (Control.iscolision(snakeposy, snakeposx, arr))
                                {
                                    Control.gameoverinfo(score);
                                    goto TheEnd;
                                }
                                Console.Clear();
                                for (int i = 0; i < arr.GetLength(0); i++)
                                {
                                    for (int j = 0; j < arr.GetLength(1); j++)
                                    {
                                        GameField.snakebackerase(counter, SnakePosDataX, SnakePosDataY, arr);
                                        if (snakeposx == fruitx && snakeposy == fruity)
                                        {
                                            counter--;
                                            fruitx = GameField.randomfood();
                                            fruity = GameField.randomfood();
                                            if (arr[fruity, fruitx] != ' ')
                                            {
                                                fruitx = GameField.fruitappear(fruitx, fruity, arr);
                                            }
                                            arr[fruity, fruitx] = 'F';
                                            score += 10;
                                        }
                                        arr[snakeposy, snakeposx] = 'S';
                                        Console.Write(arr[i, j]);
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Score: " + score);
                                Thread.Sleep(speed);
                                counter++;
                            }
                            if (isgameover != true)
                            {
                                tmp = Console.ReadKey(true).Key;
                                prevkey = ConsoleKey.LeftArrow;
                            }
                            else
                            {
                                break;
                            }
                        } while (tmp == ConsoleKey.LeftArrow);
                        break;
                    case ConsoleKey.RightArrow:
                        do
                        {
                            while (!Console.KeyAvailable)
                            {
                                snakeposx++;
                                SnakePosDataY.Add(snakeposy);
                                SnakePosDataX.Add(snakeposx);
                                if (Control.gameover(isgameover, snakeposx, arr))
                                {
                                    Control.gameoverinfo(score);
                                    goto TheEnd;
                                }
                                if (Control.iscolision(snakeposy, snakeposx, arr))
                                {
                                    Control.gameoverinfo(score);
                                    goto TheEnd;
                                }
                                Console.Clear();
                                for (int i = 0; i < arr.GetLength(0); i++)
                                {
                                    for (int j = 0; j < arr.GetLength(1); j++)
                                    {
                                        GameField.snakebackerase(counter, SnakePosDataX, SnakePosDataY, arr);
                                        if (snakeposx == fruitx && snakeposy == fruity)
                                        {
                                            counter--;
                                            fruitx = GameField.randomfood();
                                            fruity = GameField.randomfood();
                                            if (arr[fruity, fruitx] != ' ')
                                            {
                                                fruitx = GameField.fruitappear(fruitx, fruity, arr);
                                            }
                                            arr[fruity, fruitx] = 'F';
                                            score += 10;
                                        }
                                        arr[snakeposy, snakeposx] = 'S';
                                        Console.Write(arr[i, j]);
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Score: " + score);
                                Thread.Sleep(speed);
                                counter++;
                            }
                            if (isgameover != true)
                            {
                                tmp = Console.ReadKey(true).Key;
                                prevkey = ConsoleKey.RightArrow;
                            }
                            else
                            {
                                break;
                            }
                        } while (tmp == ConsoleKey.RightArrow);
                        break;
                    default:
                        tmp = prevkey;
                        break;
                }
            }
        TheEnd:
            Control.gameoverinfo(score);
            Functions.InsertNewScore(Functions.CreateNewPlayer(score));
            Console.ReadKey();
            break;
        case "2":
            Console.Clear();
            Functions.DisplayHighScores();
            Console.ReadKey();
            break;
        case "3":
            return;
		default:
            Console.WriteLine("No option like this");
            break;
	}
}

