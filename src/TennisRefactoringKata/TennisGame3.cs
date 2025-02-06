using System.Reflection.Metadata.Ecma335;

namespace TennisRefactoringKata
{
    public class TennisGame3 : ITennisGame
    {
        private int player2Score;
        private int player1Score;
        private string player1Name;
        private string player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var isNotEndGame = (player1Score < 4 && player2Score < 4) && (player1Score + player2Score < 6);
            
            if (isNotEndGame)
            {
                if (player1Score == player2Score)
                {
                    return $"{ScoreSlang(player1Score)}-All";
                } else {
                    return $"{ScoreSlang(player1Score)}-{ScoreSlang(player2Score)}";
                }
            }
            else
            {
                string leadingPlayerName;
                var advantageCheck = (player1Score - player2Score) * (player1Score - player2Score) == 1;
                leadingPlayerName = player1Score > player2Score ? player1Name : player2Name;
                
                if (player1Score == player2Score)
                    return "Deuce";                

                if (advantageCheck) {
                    return "Advantage " + leadingPlayerName;
                } else {
                    return "Win for " + leadingPlayerName;
                }
            }
        }

        public string ScoreSlang(int playerScore) {
            return playerScore switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.player1Score++;
            else
                this.player2Score++;
        }

    }
}