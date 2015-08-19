using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors {
    interface IPlayer {
        int Wins { get; set; }
        string Act();
    }

    class PlayerRock : IPlayer, IPlayerRock {
        public int Wins { get; set; }
        public string Act() { return "Rock"; }
    }

    class PlayerPaper : IPlayer, IPlayerPaper {
        public int Wins { get; set; }
        public string Act() { return "Paper"; }
    }

    class PlayerScissors : IPlayer, IPlayerScissors {
        public int Wins { get; set; }
        public string Act() { return "Scissors"; }
    }

    class Game {
        public static void Fight(IPlayer first, IPlayer second) {
            var firstAct = first.Act();
            var secondAct = second.Act();

            if (firstAct == "Rock") {
                if (secondAct == "Scissors") {
                    first.Wins += 1;
                } else {
                    second.Wins += 1;
                }
            } else {
                second.Wins += 1;
            }
        }

        static void Main(string[] args) {
            int randomNum;
            var randNum = new Random();
            var rockPlayer = new PlayerRock();
            var paperPlayer = new PlayerPaper();
            var scissorsPlayer = new PlayerScissors();
            for (var i = 1; i <= 100; i++) {
                randomNum = randNum.Next(1,4);
                switch (randomNum) {
                    case 1:
                        Fight(rockPlayer, paperPlayer);
                        break;
                    case 2:
                        Fight(rockPlayer, scissorsPlayer);
                        break;
                    case 3:
                        Fight(paperPlayer, scissorsPlayer);
                        break;
                }
            }
            Console.WriteLine("Rock Wins:      " + rockPlayer.Wins);
            Console.WriteLine("Paper Wins:     " + paperPlayer.Wins);
            Console.WriteLine("Scissors Wins:  " + scissorsPlayer.Wins);
            Console.ReadLine();

        }
    }
}
