namespace projectJuin;

public interface IGameController
{
    void AddScore(int score);
    int GetScore();
    int GetPauseCount();
    int GetSnakeLength();
    int GetApplesEaten();
    int GetShoots();
    int GetPauses();
}

class GameController : IGameController
{
    private int currenteScore = 0;
    private int pauseCount { get; set; } = 0;
    public int shootCount { get; private set; } = 0;
    public int appleCount { get; private set; } = 0;
    public Snake? Snake { get; private set; }
    public Apple? Apple { get; private set; }

    public GameController()
    { Services.Register<IGameController>(this); }

    public void AddScore(int score)
    { currenteScore += score; }

    public int GetScore()
    { return currenteScore; }

    public int GetPauseCount()
    {
        // Assuming you have a way to track pauses, this is a placeholder
        return pauseCount; // Replace with actual pause count logic
    }

    private void AddPauseCount()
    {
        pauseCount++;
    }

    public int GetSnakeLength()
    {
        if (Snake != null) return Snake.Length;
        return 0;
    }
    public int GetApplesEaten() => appleCount;

    public int GetShoots() => shootCount;
    public int GetPauses() => pauseCount;



}



