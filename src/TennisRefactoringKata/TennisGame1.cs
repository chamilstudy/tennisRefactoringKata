namespace TennisRefactoringKata
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score = 0;
        private int player2Score = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
            {
                player1Score++;
            }
            else
            {
                player2Score++;
            }
        }

        public string GetScore()
        {
            if (player1Score == player2Score)
            {
                return TieToTieSlang(player1Score);
            }
            else if (CheckDeuce())
            {
                return MatchScoreState();
            }
            else
            {
                return $"{ScoreToScoreSlang(player1Score)}-{ScoreToScoreSlang(player2Score)}";
            }
        }

        private string MatchScoreState()
        {
            var playerAdavantage = player1Score - player2Score;

            return playerAdavantage switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2",
            };
        }

        private string TieToTieSlang(int playerScore)
        {
            return playerScore switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
        }

        private static string ScoreToScoreSlang(int playerScore)
        {
            return playerScore switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => "",
            };
        }

        private bool CheckDeuce()
        {
            return player1Score >= 4 || player2Score >= 4;
        }
    }
}
