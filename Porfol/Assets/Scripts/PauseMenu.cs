using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // ** �Ͻ����� UI
    public GameObject ui;

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
        // ** ���� Ȱ��ȭ ���� ���� �ٽ� �ҷ��´�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {

    }
}
