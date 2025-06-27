namespace projectJuin;
using System;
using System.Formats.Asn1;
using System.Numerics;
using Raylib_cs;
using static Snake;


public class Apple
{
    public Coordinates coordinates { get; private set; }
    private Grid grid;

    static AssetsManager _assetsManager = Services.Get<AssetsManager>();

    Texture2D appleNormal = _assetsManager.getTextureFromString("normal");
    Texture2D appleFuzzy = _assetsManager.getTextureFromString("fuzzy");
    //Texture2D imageApple;


    public enum appleType { Normal, Fuzzy };
    public appleType typeApple = appleType.Normal;


    public Apple(Grid grid)
    {
        this.grid = grid;
        coordinates = Coordinates.Random(grid.columns, grid.rows);
    }

    public appleType RandomType()
    {
        Random randomIndex = new Random();
        int i = randomIndex.Next(2);
        Console.WriteLine($"i = {i}");
        if (i == 0) return appleType.Normal;
        else
            return appleType.Fuzzy; // for now, only two types of apples, Normal and Crazy     
    }

    public void Respawn()
    {
        coordinates = Coordinates.Random(grid.columns - 1, grid.rows - 1);
        typeApple = RandomType();
        Console.WriteLine($"type de pomme: {typeApple}");     
    }

    public void Draw()
    {
        var pos = grid.GridToWorld(coordinates);

        if (typeApple == appleType.Fuzzy) 
            Raylib.DrawTexture(appleFuzzy, (int)pos.X, (int)pos.Y, Color.White); 
        else
            Raylib.DrawTexture(appleNormal, (int)pos.X, (int)pos.Y, Color.White);     
        
    }
}
