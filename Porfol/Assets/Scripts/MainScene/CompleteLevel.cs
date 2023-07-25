using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public string levelSelectSceneName = "LevelSelect";
    // ** 다음 레벨 씬 이름
    public string nextLevel;
    // ** 활성화할 레벨
    public int levelToUnlock;

    public SceneFader sceneFader;

    public void Continue()
    {
        // ** 최종 레벨을 해금 레벨로 설정
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        // ** 다음 레벨 씬으로 이동
        sceneFader.FadeTo(nextLevel);
    }

    public void LevelSelect()
    {
        sceneFader.FadeTo(levelSelectSceneName);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
