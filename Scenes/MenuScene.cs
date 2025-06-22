using Raylib_cs;


namespace projectJuin;

public class MenuScene : Scene
{
     Texture2D appleNormal = Raylib.LoadTexture("assets/apple_basic.png)");
    public override void Load()
    {
        Console.WriteLine("Load scene menu");
       
    }
    public override void Draw()
    {
        Raylib.DrawText("Snake", 300, 300, 60, Color.Green);
        Raylib.DrawText("Press enter to start", 500, 300, 20, Color.Black);
        Raylib.DrawTexture(appleNormal, 600, 300, Color.Red);
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
