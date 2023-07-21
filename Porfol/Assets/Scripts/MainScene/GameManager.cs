using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ** ���� ���� On/Off
    public static bool GameIsOver;
    // ** ���� ���� UI�� ������ ������Ʈ
    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {

        // ** ���� ���� ���� ���� ������ �� ��ȯ
        if (GameIsOver)
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
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
