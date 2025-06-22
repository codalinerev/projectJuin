using System;


using Raylib_cs;
using System.Numerics;

namespace projectJuin;

public class ScoreGui
{
    static IGameController gameController = Services.Get<IGameController>();
    public void Draw()
    {
        Raylib.DrawText($"Score: {gameController.GetScore()}", 1010, 10, 20, Color.Green);
        /*Raylib.DrawText($"Paused: {countPauses}", 1010, 80, 20, Color.Red);
        Raylib.DrawText($"Speed: {gameController.GetSpeed()}", 1010, 50, 20, Color.Blue);
        Raylib.DrawText($"Snake Length: {gameController.GetSnakeLength()}", 1010, 110, 20, Color.Purple);
        Raylib.DrawText($"Shoots: {countShoots}", 1010, 140, 20, Color.Orange);*/
    }

}
