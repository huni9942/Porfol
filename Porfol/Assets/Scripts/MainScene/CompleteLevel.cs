using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public string levelSelectSceneName = "LevelSelect";
    // ** ���� ���� �� �̸�
    public string nextLevel;
    // ** Ȱ��ȭ�� ����
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
        // ** ���� ������ �ر� ������ ����
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        // ** ���� ���� ������ �̵�
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
