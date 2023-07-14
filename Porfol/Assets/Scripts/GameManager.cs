using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ** ���� ���� On/Off
    private bool gameEnded = false;

    void Update()
    {
        // ** ���� ���� ���� ���� ������ �� ��ȯ
        if (gameEnded)
            return;

        // ** �÷��̾��� ������� 0 ������ ��
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    // ** ���� ���� �Լ�
    void EndGame()
    {
        // ** ���� ���� On
        gameEnded = true;
    }
}
