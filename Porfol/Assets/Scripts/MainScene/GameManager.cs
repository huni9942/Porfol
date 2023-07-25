using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ** 게임 종료 On/Off
    public static bool GameIsOver;
    // ** 게임 오버 UI를 관리할 오브젝트
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

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
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
