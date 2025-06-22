//using System;

namespace projectJuin;

public interface IScenesManager
{
    void Load<T>() where T : Scene, new();
 }

class ScenesManager : IScenesManager
{
    private Scene? _currentScene;

    public ScenesManager()
    { 
    Services.Register<IScenesManager>(this); 
    }

    public void Load<T>() where T : Scene, new()
    {
        _currentScene?.Unload();
        _currentScene = new T();
        _currentScene.Load();
    }

    public void Update()
    {
        _currentScene?.Update();
    }

    public void Draw()
    {
        _currentScene?.Draw();
    }
    
}
