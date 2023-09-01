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

    void OnEnable()
    {
        Time.timeScale = 0.0f;
    }

    // ** ��õ� ��ư Ŭ�� ��, ���� Ȱ��ȭ �Ǿ��ִ� ���� �ٽ� �ҷ��´�
    public void Retry()
    {
        Cleaner();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    // ** �޴� ��ư Ŭ�� ��, ���� �޴��� �̵��Ѵ�
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
