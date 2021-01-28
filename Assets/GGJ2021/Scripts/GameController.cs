using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehabiourSingleton<GameController>
{
    public bool paused { get; private set; }
    public bool softPaused { get; private set; }


    public void PauseGame()
    {
        paused = true;
    }

    public void SoftPause()
    {
        softPaused = true;
    }

    public void ResumeGame()
    {
        paused = false;
        softPaused = false;
    }
}
