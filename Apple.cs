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
    Texture2D appleCrazy = _assetsManager.getTextureFromString("fuzzy");
    Texture2D imageApple;


    public enum appleType { Normal, Fuzzy };
    public appleType typeApple = appleType.Normal;
    

    public Apple(Grid grid)
    {
        this.grid = grid;
        coordinates = Coordinates.Random(grid.columns, grid.rows);
    }

    public appleType RandomType()
    {
        Random randomIndex = new Random(2);
        int i = randomIndex.Next();
        if (i == 0) return appleType.Normal;
        return appleType.Fuzzy; // for now, only two types of apples, Normal and Crazy     
    } 

    public void Respawn()
    {
        coordinates = Coordinates.Random(grid.columns-1, grid.rows-1);
        typeApple = RandomType();       
    }

    public void Draw()
    {
        var pos = grid.GridToWorld(coordinates);
       
        imageApple = appleNormal;
        if (typeApple == appleType.Fuzzy) imageApple = appleCrazy;
        Raylib.DrawTexture(imageApple, (int)pos.X, (int)pos.Y, Color.White);      
        
    }
}
