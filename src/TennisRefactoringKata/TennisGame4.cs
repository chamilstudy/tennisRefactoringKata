namespace TennisRefactoringKata;

public class TennisGame4  : ITennisGame
{
    public int ServerScore;
    public int ReceiverScore;
    internal readonly string Server;
    internal readonly string Receiver;
    private static readonly string[] Scores = { "Love", "Fifteen", "Thirty", "Forty" };

    

    public TennisGame4(string player1Name, string player2Name)
    {
        Server = player1Name;
        Receiver = player2Name;
    }

    public void WonPoint(string playerName)
    {
        if (Server.Equals(playerName))
            ServerScore += 1;
        else
            ReceiverScore += 1;
    }

    public string GetScore()
    {
        var getScoreState = ScoreState();
        return getScoreState switch
        {
            0 => $"Advantage {Server}",
            1 => $"Advantage {Receiver}",
            2 => $"Win for {Server}",
            3 => $"Win for {Receiver}",
            4 => ServerScore >= 3 ? "Deuce" : $"{Scores[ServerScore]}-All",
            5 => $"{Scores[ServerScore]}-{Scores[ReceiverScore]}",
        };
    }

    private int ScoreState()
    {
        if (ServerScore >= 3 && ReceiverScore >= 3 && (ServerScore - ReceiverScore) == 1)
            return 0;

        if (ServerScore >= 3 && ReceiverScore >= 3 && (ServerScore - ReceiverScore) == -1)
            return 1;

        if (ServerScore >= 4 && (ServerScore - ReceiverScore) >= 2)
            return 2;

        if (ReceiverScore >= 4 && (ReceiverScore - ServerScore) >= 2)
            return 3;

        if (ServerScore == ReceiverScore)
            return 4;

        return 5;
    }
}