using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public SceneFader sceneFader;

    public void MainMenu()
    {
        sceneFader.FadeTo("MainMenu");
    }
}
