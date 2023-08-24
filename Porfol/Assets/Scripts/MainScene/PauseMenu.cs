using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // ** �Ͻ����� UI
    public GameObject ui;

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    void Update()
    {
        // ** ESC�� P�� ������ �� �����Ѵ� 
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    // ** �Ͻ� ���� ���
    public void Toggle()
    {
        // ** UI�� Ȱ��ȭ ���¸� �ݴ�� �Ѵ�
        ui.SetActive(!ui.activeSelf);

        // ** UI�� Ȱ��ȭ ������ �� �ð��� ���߰�, ��Ȱ��ȭ ������ �� �ð��� ���������� �帥��
        if (ui.activeSelf)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    // ** ��õ�
    public void Retry()
    {
        Toggle();
        EnemyController[] Enemy = FindObjectsOfType<EnemyController>();
        foreach (EnemyController enemy in Enemy)
            enemy.Die();
        // ** ���� Ȱ��ȭ ���� ���� �ٽ� �ҷ��´�
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
