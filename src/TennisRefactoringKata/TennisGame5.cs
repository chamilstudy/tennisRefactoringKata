using System.ComponentModel.Design;

namespace TennisRefactoringKata
{
    public class TennisGame5 : ITennisGame
    {
        private int player1Score;
        private int player2Score;
        private string player1Name;
        private string player2Name;

        public TennisGame5(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            CheckPlayerName(playerName);

            if (playerName == player1Name)
            {
                player1Score++;
            }
            else
            {
                player2Score++;
            }
        }

        private void CheckPlayerName(string playerName)
        {
            if ((playerName == player1Name) && (playerName == player2Name))
            {
                throw new ArgumentException("Invalid player name.");
            }
        }

        public string GetScore()
        {
            int player1Score = this.player1Score;
            int player2Score = this.player2Score;

            while (player1Score > 4 || player2Score > 4)
            {
                player1Score--;
                player2Score--;
            }

            return MatchStateToString(player1Score, player2Score);
        }

        private string MatchStateToString(int player1Score, int player2Score)
        {
            var isNotEndGame = ((player1Score + player2Score) < 6) && ((player1Score != 4) && (player2Score != 4));
            
            if (isNotEndGame)
            {
                if (player1Score == player2Score)
                {
                    return $"{ScoreSlang(player1Score)}-All";
                }
                else
                {
                    return $"{ScoreSlang(player1Score)}-{ScoreSlang(player2Score)}";
                }
            } 
            else
            {
                var leadingPlayer = player1Score > player2Score ? player1Name : player2Name;
                var advantageCheck = (player1Score - player2Score) * (player1Score - player2Score) > 1;

                if (player1Score == player2Score)
                {
                    return "Deuce"; 
                }
                else if (advantageCheck)
                {
                    return $"Win for {leadingPlayer}";
                }
                else
                {
                    return $"Advantage {leadingPlayer}";
                }
            }
        }

        public string ScoreSlang(int score) {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => throw new ArgumentException("Invalid score."),
            };
        }
    }
}