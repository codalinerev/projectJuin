using Raylib_cs;


namespace projectJuin;

public class MenuScene : Scene
{
    
    Texture2D appleNormal = Services.Get<AssetsManager>().getTextureFromString("normal");
    Texture2D appleFuzzy = Services.Get<AssetsManager>().getTextureFromString("fuzzy");

    public override void Load()
    {
        Console.WriteLine("Load scene menu");

    }
    public override void Draw()
    {
        Raylib.DrawText("Snake", 280, 300, 250, Color.Green);
        Raylib.DrawText("Press enter to start", 300, 100, 25, Color.Black);
        Raylib.DrawTexture(appleNormal, 380, 370, Color.White);
        Raylib.DrawTexture(appleFuzzy, 300, 370, Color.White);
        Raylib.DrawText("Move snake with arrows", 300, 180, 25, Color.DarkGray);
        Raylib.DrawText("press space for pause or restart", 400, 560, 25, Color.DarkBlue);
        Raylib.DrawText("! Fuzzy apples make the snake fuzzy", 320, 620, 35, Color.Lime);
        Raylib.DrawText("It will misunderstand your commands", 320, 670, 30, Color.Red);
        Raylib.DrawText("and do the opposite (for example, left for right)", 320, 720, 35, Color.Pink);
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
