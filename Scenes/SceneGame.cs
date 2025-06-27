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
    static AssetsManager _assetsManager = Services.Get<AssetsManager>();

    int apples = gameController.GetApplesEaten();
    int length = gameController.GetSnakeLength();
    //int shoots = gameController.GetShoots(); // idée pas encore implementée
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
        grid.Draw();
        snake.Draw();
        apple.Draw();   
        Raylib.DrawText("press SPACE for pause", 1000, 200, 15, Color.Blue);
        Raylib.DrawText("move snake with arrows", 1000, 100, 15, Color.DarkGreen);
        Raylib.DrawText($"Pauses : {pauses}", 1010, 400, 15, Color.Black);
        Raylib.DrawText($"Apples Eaten : {apples}", 1010, 300, 15, Color.Black);
        if (snake.isFuzzy)
        {
            Raylib.DrawText("!!!!!", 1030, 500, 40, Color.Red);
            Raylib.DrawText("FUZZY", 1010, 540, 30, Color.Red);
            Raylib.DrawText("SNAKE", 1020, 570, 30, Color.Red);
            Raylib.DrawText("apple was Fuzzy", 1010, 600, 15, Color.Red);
            Raylib.DrawText("invert commands!!!", 1010, 630, 15, Color.Red);
        }

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
        
        if (snake.isFuzzy) { snake.ChangeDirection(GetInputsFuzzyDirection()); }
        if (!snake.isFuzzy) { snake.ChangeDirection(GetInputsDirection()); }
        timer.Update(Raylib.GetFrameTime());
    }


    private void OnMoveTimerTriggered()
    {
        snake.Move();
        if (snake.IsCollidingWithApple(apple))
        {
            Console.WriteLine("Snake collided with apple at: " + apple.coordinates);
            if (apple.typeApple == Apple.appleType.Fuzzy)
                snake.isFuzzy = true;
            else snake.isFuzzy = false;
                 
            apple.Respawn();
            Console.WriteLine($"<string>Apple.appleType");
            apples++;
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
                pauses++;
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
    
     private Coordinates GetInputsFuzzyDirection()
    {
        var direction = Coordinates.Zero;
        if (Raylib.IsKeyPressed(KeyboardKey.Up)) return Coordinates.Down;
        if (Raylib.IsKeyPressed(KeyboardKey.Down)) return Coordinates.Up;
        if (Raylib.IsKeyPressed(KeyboardKey.Left)) return Coordinates.Right;
        if (Raylib.IsKeyPressed(KeyboardKey.Right)) return Coordinates.Left;
       //pas de pause possible pendant la "crazy state"
       
        return Coordinates.Zero; // No direction change
    }
}
