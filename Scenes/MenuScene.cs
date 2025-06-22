using Raylib_cs;


namespace projectJuin;

public class MenuScene : Scene
{
    Texture2D appleNormal = Raylib.LoadTexture("assets/apple_basic.png");
    Texture2D appleCrazy = Raylib.LoadTexture("assets/apple_fuzzy.png");
    public override void Load()
    {
        Console.WriteLine("Load scene menu");

    }
    public override void Draw()
    {
        Raylib.DrawText("Snake", 300, 300, 60, Color.Green);
        Raylib.DrawText("Press enter to start", 500, 300, 20, Color.Black);
        Raylib.DrawTexture(appleNormal, 680, 400, Color.White);
        Raylib.DrawTexture(appleCrazy, 600, 400, Color.White);
    }
    
    public override void Unload()
    {
        Console.WriteLine("Unload scene menu");
    }

    public override void Update()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            var sm = Services.Get<IScenesManager>();
            sm.Load<SceneGame>();
            Raylib.DrawText("Scene Game", 200, 200, 20, Color.Gold);
        }
    } 
}
