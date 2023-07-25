using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // ** 메인메뉴 이름
    public string menuSceneName = "MainMenu";

    // ** 씬 페이더
    public SceneFader sceneFader;


    // ** 재시도 버튼 클릭 시, 현재 활성화 되어있는 씬을 다시 불러온다
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    // ** 메뉴 버튼 클릭 시, 메인 메뉴로 이동한다
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
