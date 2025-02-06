namespace TennisRefactoringKata
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string GetScore();
    }
}