namespace TennisRefactoringKata;

public class TennisGame7 : ITennisGame
{
    private int player1Score;
    private int player2Score;
    private string player1Name;
    private string player2Name;

    public TennisGame7(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == player1Name)
            player1Score++;
        else
            player2Score++;
    }

    public string GetScore()
    {
        string result = "Current score: ";

        if (player1Score == player2Score)
        {
            // tie score
            result += player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
        }
        else if (player1Score >= 4 || player2Score >= 4)
        {
            // end-game score
            result += (player1Score - player2Score) switch
            {
                1 => $"Advantage {player1Name}",
                -1 => $"Advantage {player2Name}",
                >= 2 => $"Win for {player1Name}",
                _ => $"Win for {player2Name}",
            };
        }
        else
        {
            // regular score
            result = $"{ScoreSlang(player1Score)}-{ScoreSlang(player2Score)}";
        }

        return result + ", enjoy your game!";
    }

    private static string ScoreSlang(int playerScore)
    {
        return playerScore switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty"
        };
    }
}