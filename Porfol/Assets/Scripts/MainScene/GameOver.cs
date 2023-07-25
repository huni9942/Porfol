using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // ** ���θ޴� �̸�
    public string menuSceneName = "MainMenu";

    // ** �� ���̴�
    public SceneFader sceneFader;


    // ** ��õ� ��ư Ŭ�� ��, ���� Ȱ��ȭ �Ǿ��ִ� ���� �ٽ� �ҷ��´�
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    // ** �޴� ��ư Ŭ�� ��, ���� �޴��� �̵��Ѵ�
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
