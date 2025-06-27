using Raylib_cs;

public class AssetsManager
{
    private List<Texture2D> assetsList = [];
    public AssetsManager()
    {
        assetsList.Add(Raylib.LoadTexture("assets/apple_normal.png"));
        assetsList.Add(Raylib.LoadTexture("assets/apple_normal.png"));
        assetsList.Add(Raylib.LoadTexture("assets/apple_normal.png"));
    }

    public Texture2D getTextureFromString(string appleName)
    {
        if (appleName == "crazy")
            return assetsList[1];       
        return assetsList[0];      
    }
}