using System;
using System.Timers;
using System.Collections.Generic;

namespace projectJuin;

public class Timer
{
    private float elapsedTime = 0f;
    public float duration { get; private set; }
    public bool isLooping { get; set; }
    public bool isRunning { get; private set; }
    public Action? callback { private get; set; }

    public Timer(float duration, Action? callback = null, bool isLooping = true)
    {
        this.duration = duration;
        this.isLooping = isLooping;
        this.callback = callback;
        elapsedTime = 0f;
        isRunning = true;
    }

    public void Pause()
    { isRunning = false; }
    public void Stop()
    {
        Reset();
        isRunning = false;
    }

    public void Start()
    {
        isRunning = true;
        elapsedTime = 0f;
    }
    public void Reset()
    { elapsedTime = 0f; }

    public void SetDuration(float newDuration)
    { duration = newDuration; }

    public bool isFinished()
    {
        return duration >= elapsedTime;
    }

    public void Update(float deltaTime)
    {
        if (!isRunning) return;
        elapsedTime += deltaTime;
        if (elapsedTime >= duration)
        {
            callback?.Invoke();
            if (isLooping) { elapsedTime = 0f; }
            else { Stop(); }
        }
    }

}


