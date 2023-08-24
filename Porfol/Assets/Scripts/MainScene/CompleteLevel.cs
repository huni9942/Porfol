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

    private void Update()
    {
        if (gameObject)
            Time.timeScale = 0.0f;
    }

    public void Continue()
    {
        Cleaner();
        // ** 최종 레벨을 해금 레벨로 설정
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        // ** 다음 레벨 씬으로 이동
        sceneFader.FadeTo(nextLevel);
    }

    public void LevelSelect()
    {
        Cleaner();
        sceneFader.FadeTo(levelSelectSceneName);
    }

    public void Menu()
    {
        Cleaner();
        sceneFader.FadeTo(menuSceneName);
    }

    void Cleaner()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        EnemyController[] Enemy = FindObjectsOfType<EnemyController>();
        foreach (EnemyController enemy in Enemy)
            enemy.Die();
    }
}
