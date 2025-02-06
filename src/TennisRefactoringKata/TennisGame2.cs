namespace TennisRefactoringKata
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Score;
        private int player2Score;
        private string player1SlangScore = "";
        private string player2SlangScore = "";

        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            player1Score = player2Score = 0;
        }

        public string GetScore()
        {
            if (player1Score == player2Score)
            {
                return TieToTieSlang(player1Score);
            }
            else if (player1Score >= 4 || player2Score >= 4)
            {
                return CheckMatchState();
            }
            else
            {
                player1SlangScore = ScoreToSlangScore(player1Score);
                player2SlangScore = ScoreToSlangScore(player2Score);
                return player1SlangScore + "-" + player2SlangScore;
            }
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
        private string CheckMatchState()
        {

            var playerAdvantage = player1Score - player2Score;

            switch (playerAdvantage) {
                case 1:
                    return "Advantage player1";
                case -1:
                    return "Advantage player2";
                case >=2:
                    return "Win for player1";
                case <=2:
                    return "Win for player2";
            }
        }

        private string ScoreToSlangScore(int playerScore)
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

        public void SetPlayer1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                player1Score++;
            }
        }

        public void SetPlayer2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                player2Score++;
            }
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                player1Score++;
            else
                player2Score++;
        }
    }
}
