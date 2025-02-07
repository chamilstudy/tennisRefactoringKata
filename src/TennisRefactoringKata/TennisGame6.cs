namespace TennisRefactoringKata;

public class TennisGame6 : ITennisGame
{
    private int player1Score;
    private int player2Score;
    private string player1Name;
    private string player2Name;
    private string result;

    public TennisGame6(string player1Name, string player2Name)
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
        if (player1Score == player2Score)
        {
            HandleEqualScore();
        }
        else if (player1Score >= 4 || player2Score >= 4)
        {
            HandleGamePoint();
        }
        else
        {
            HandleTempScore();
        }
        return result;
    }
    private void HandleEqualScore()
    {
        result = player1Score switch
        {
            0 => "Love-All",
            1 => "Fifteen-All",
            2 => "Thirty-All",
            _ => "Deuce"
        };
    }

    private void HandleGamePoint()
    {
        result = (player1Score - player2Score) switch
        {
            1 => $"Advantage {player1Name}",
            -1 => $"Advantage {player2Name}",
            >= 2 => $"Win for {player1Name}",
            <= -2 => $"Win for {player2Name}"
        };
    }
    private void HandleTempScore()
    {
        var score1 = GetPlayerScore(player1Score);
        var score2 = GetPlayerScore(player2Score);
        result = $"{score1}-{score2}";
    }

    private string GetPlayerScore(int playerScore)
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