namespace Minefield.Services
{
    public interface IPlayer
    {
        int CurrentColumn { get; set; }
        int CurrentRow { get; set; }
        int LivesRemaining { get; set; }
        int TotalLives { get; set; }
        string PlayerName { get; set; }

        string ChessboardLocation();
        bool MoveDown();
        bool MoveLeft();
        bool MoveRight();
        bool MoveUp();
        void ResetLocation();
    }
}