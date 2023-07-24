using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ** 게임 종료 On/Off
    public static bool GameIsOver;
    // ** 게임 오버 UI를 관리할 오브젝트
    public GameObject gameOverUI;
    // ** 다음 레벨 씬 이름
    public string nextLevel = "Level02";
    // ** 활성화할 레벨
    public int levelToUnlock = 2;
    // ** 씬 페이더
    public SceneFader sceneFader;

    private void Start()
    {
        // ** 게임 종료 비활성화
        GameIsOver = false;
    }

    void Update()
    {

        // ** 게임 종료 값이 참인 상태일 때 반환
        if (GameIsOver)
            return;

        // ** 플레이어의 생명력이 0 이하일 때
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    // ** 게임 종료
    void EndGame()
    {
        // ** 게임 종료 및 UI On
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    // ** 게임 승리
    public void winLevel()
    {
        // ** 최종 레벨을 해금 레벨로 설정
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        // ** 다음 레벨 씬으로 이동
        sceneFader.FadeTo(nextLevel);
    }
}
