namespace projectJuin;
using System;
using System.Formats.Asn1;
using System.Numerics;
using Raylib_cs;


public class Apple
{
    public Coordinates coordinates { get; private set; }
    private Grid grid;
    private bool surprise = false;
    Texture2D appleNormal = Raylib.LoadTexture("assets/apple_basic.png");
    Texture2D appleCrazy = Raylib.LoadTexture("assets/apple_fuzzy.png");
    Texture2D texApple;

    public string typeApple = "Normal";
    public string lastApple = "Normal";

    public static string[] typesApple = { "Normal", "Crazy" };

    public Apple(Grid grid)
    {
        this.grid = grid;
        coordinates = Coordinates.Random(grid.columns, grid.rows);
    }

    public string RandomType()
    {
        Random randomT = new Random();
        int i = randomT.Next(0,typesApple.Length);
        return typesApple[i];  // for now, only two types of apples, Normal and Crazy     
    } 

    public void Respawn()
    {
        coordinates = Coordinates.Random(grid.columns-1, grid.rows-1);
        typeApple = RandomType();       
    }

    public void Draw()
    {
        var pos = grid.GridToWorld(coordinates);
        //for debug  Raylib.DrawTexture(appleNormal, 300, 300, Color.White);
        //for debug Raylib.DrawTexture(appleCrazy, 400, 300, Color.White);
        //pos += new Vector2(grid.cellSize * 0.5f, grid.cellSize * 0.5f);
        //Raylib.DrawCircle((int)pos.X, (int)pos.Y, grid.cellSize * 0.5f, Color.Red);
        texApple = appleNormal;
        if (typeApple == "Crazy") texApple = appleCrazy;
        Raylib.DrawTexture(texApple, (int)pos.X, (int)pos.Y, Color.White);
        Raylib.DrawText($"Last Apple was {lastApple}", 1010, 500, 15, Color.Black);
        if (lastApple == "Crazy")
        {            
            Raylib.DrawText("Careful!!! The snake is fuzzy", 1010, 500, 20, Color.Red);
            Raylib.DrawText("because the apple was CRAZY", 1010, 530, 15, Color.Red);
            Raylib.DrawText("it will invert your commands!!!", 1010, 580, 15, Color.Red);
        }
    }
}
