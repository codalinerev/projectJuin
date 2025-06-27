using Raylib_cs;

public class AssetsManager
{
    private List<Texture2D> assetsList = [];
    public AssetsManager()
    {
        assetsList.Add(Raylib.LoadTexture("assets/apple_basic.png"));
        assetsList.Add(Raylib.LoadTexture("assets/apple_fuzzy.png"));
        assetsList.Add(Raylib.LoadTexture("assets/apple_normal.png"));
    }

    public Texture2D getTextureFromString(string appleName)
    {
        if (appleName == "crazy")
            return assetsList[1];
        else if (appleName == "normal")
            return assetsList[0];
        return assetsList[0];
    }

    /*public Draw()
    {
       Raylib.DrawTexture(GetTextexAppleFromString, (int)pos.X, (int)pos.Y, Color.White) 
    }*/
}