using System;
using System.Numerics;
using Raylib_cs;

namespace projectJuin;

public class SceneGame : Scene
{
    Grid grid;
    Snake snake;
    Apple apple;

   

    ScoreGui score = new ScoreGui();
    static IGameController gameController = Services.Get<IGameController>();
    int apples = gameController.GetApplesEaten();
    int length = gameController.GetSnakeLength();
    int shoots = gameController.GetShoots();
    int pauses = gameController.GetPauses();

    Timer timer;
    Timer gameOverTimer;

    bool IsGameOver = false;
    bool GamePause = false;

    //Coordinates coord = new(10, 10);
    public SceneGame()
    {
        //Console.WriteLine("SceneGame initialized with coordinates: " + coord);
        grid = new Grid();
        apple = new Apple(grid);
        snake = new Snake(new(5, 5), grid);
        timer = new Timer((float)snake.moveSpeed, OnMoveTimerTriggered);
        gameOverTimer = new Timer(2f, () =>
        {
            Services.Get<IScenesManager>().Load<GameOverScene>();
        }, false);
        gameOverTimer.Stop();
    }

    public override void Load()
    {
        grid.position = new Vector2(100, 100);

    }

    public override void Draw()
    {
        //base.Draw();
        grid.Draw();
        grid.DrawMini();
        snake.Draw();
        apple.Draw();
        score.Draw();
        Raylib.DrawRectangleLines(200, 200, 100, 50, Color.Black);
        Raylib.DrawText("apple is at " + apple.coordinates, 200, 200, 20, Color.Red);
        Raylib.DrawText("snake is at " + snake.Head, 200, 230, 20, Color.Blue);
        Raylib.DrawText($"Apples Eaten : {apples}", 1010, 300, 15, Color.Black);
        Raylib.DrawText($"Shoots : { shoots} :", 1010, 350, 15, Color.Black);
        Raylib.DrawText($"Pauses : {pauses}", 1010, 400, 15, Color.Black);
        Raylib.DrawText($"Apples Eaten :", 1010, 300, 15, Color.Black);
        

        if (IsGameOver)
            Raylib.DrawText("GAMEOVER", 100, 100, 20, Color.Red);
    }

    public override void Unload()
    {
        Console.WriteLine("SceneTest.Unload");
    }

    public override void Update()
    {
        gameOverTimer.Update(Raylib.GetFrameTime());
        if (IsGameOver) return;
        snake.ChangeDirection(GetInputsDirection());
        timer.Update(Raylib.GetFrameTime());
    }


    private void OnMoveTimerTriggered()
    {
        snake.Move();
        if (snake.IsCollidingWithApple(apple))
        {
            Console.WriteLine("Snake collided with apple at: " + apple.coordinates);
            apple.Respawn();
            
            snake.Grow();
            gameController.AddScore(1000);
            snake.SpeedUp();
            timer.SetDuration((float)snake.moveSpeed);
        }
        if (snake.IsCollidingWithItself() || snake.IsOutOfBounds())
        {
            IsGameOver = true;
            gameOverTimer.Start();
        }
    }

    private Coordinates GetInputsDirection()
    {
        var direction = Coordinates.Zero;
        if (Raylib.IsKeyPressed(KeyboardKey.Up)) return Coordinates.Up;
        if (Raylib.IsKeyPressed(KeyboardKey.Down)) return Coordinates.Down;
        if (Raylib.IsKeyPressed(KeyboardKey.Left)) return Coordinates.Left;
        if (Raylib.IsKeyPressed(KeyboardKey.Right)) return Coordinates.Right;
        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            GamePause = !GamePause;
            if (GamePause)
            {
                timer.Pause();
                pauses ++;
                Raylib.DrawText("Game Paused", 200, 200, 20, Color.Yellow);
            }
            else 
            {
                timer.Start();
                Raylib.DrawText("Game Reset", 200, 200, 20, Color.Green);
            }
        }
        return Coordinates.Zero; // No direction change
    }
}
