using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ** 게임 종료 값
    private bool gameEnded = false;

    void Update()
    {
        // ** 게임 종료 값이 참인 상태일 때 반환
        if (gameEnded)
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
        // ** 게임 종료 값이 참
        gameEnded = true;
    }
}
