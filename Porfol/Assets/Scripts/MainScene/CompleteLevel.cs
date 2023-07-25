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

    public void Continue()
    {
        // ** ���� ������ �ر� ������ ����
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        // ** ���� ���� ������ �̵�
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
