using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // ** 일시정지 UI
    public GameObject ui;

    void Update()
    {
        // ** ESC나 P를 눌렀을 때 실행한다 
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    // ** 일시 정지 토글
    public void Toggle()
    {
        // ** UI의 활성화 상태를 반대로 한다
        ui.SetActive(!ui.activeSelf);

        // ** UI가 활성화 상태일 때 시간을 멈추고, 비활성화 상태일 때 시간이 정상적으로 흐른다
        if (ui.activeSelf)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    // ** 재시도
    public void Retry()
    {
        Toggle();
        // ** 현재 활성화 중인 씬을 다시 불러온다
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {

    }
}
