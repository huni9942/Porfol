using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ** 게임 종료 On/Off
    public static bool GameIsOver;
    // ** 게임 오버 UI를 관리할 오브젝트
    public GameObject gameOverUI;

    private void Start()
    {
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

    // ** 게임 종료 함수
    void EndGame()
    {
        // ** 게임 종료 On
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
