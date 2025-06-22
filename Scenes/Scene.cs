using System;
using Raylib_cs;

namespace projectJuin;

public abstract class Scene
{
    public abstract void Unload();

    public abstract void Load();

    public abstract void Draw();
    
    public abstract void Update();
   

}  
