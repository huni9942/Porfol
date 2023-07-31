using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo("LevelSelect");
    }

    public void HowToPlay()
    {
        sceneFader.FadeTo("HowToPlay");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
