using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // ** 라운드 텍스트
    public Text roundsText;

    // ** 메인메뉴 이름
    public string menuSceneName = "MainMenu";

    // ** 씬 페이더
    public SceneFader sceneFader;

    // ** 게임 오버 시, 라운드 텍스트는 현재 라운드를 문자열화 한다
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

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
