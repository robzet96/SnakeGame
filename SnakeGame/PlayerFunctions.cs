using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SnakeGame
{
    public class PlayerFunctions
    {
        List<Player> PlayerList = new List<Player>();
        public void InsertNewScore(Player player)
        {
            if (File.Exists("players.json"))
            {
                var json = readjson();
                PlayerList = JsonConvert.DeserializeObject<List<Player>>(json);
            }
            PlayerList.Add(player);
            File.WriteAllText("players.json", JsonConvert.SerializeObject(PlayerList, (Formatting)1));
        }
        private string readjson()
        {
            return File.ReadAllText("players.json");
        }
        public Player CreateNewPlayer(int score)
        {
            Console.WriteLine("Insert your name: ");
            string name = Console.ReadLine();
            Player gamer = new Player();
            gamer.PlayerName = name;
            gamer.PlayerScore = score;
            gamer.Date = DateOnly.FromDateTime(DateTime.Now);
            newhighscore(score);
            return gamer;
        }
        public void DisplayHighScores()
        {
            if (File.Exists("players.json"))
            {
                var json = readjson();
                PlayerList = JsonConvert.DeserializeObject<List<Player>>(json);
            }
            foreach (var item in PlayerList.OrderByDescending(x => x.PlayerScore).ToList())
            {
                Console.WriteLine(item.PlayerName + "\t" + item.PlayerScore + "\t" + item.Date);
                Console.WriteLine();
            }
        }
        private void newhighscore(int score)
        {
            if (File.Exists("players.json"))
            {
                var json = readjson();
                PlayerList = JsonConvert.DeserializeObject<List<Player>>(json);
            }
            bool isHigh = false;
            foreach (var item in PlayerList)
            {
                if (score < item.PlayerScore)
                {
                    isHigh = false;
                    break;
                }
                else
                {
                    isHigh = true;
                }
            }
            if (isHigh == true)
            {
                Console.WriteLine("New highscore!");
            }
        }
    }
}
