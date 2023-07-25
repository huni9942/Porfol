using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ** ���� ���� On/Off
    public static bool GameIsOver;
    // ** ���� ���� UI�� ������ ������Ʈ
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    private void Start()
    {
        // ** ���� ���� ��Ȱ��ȭ
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

    // ** ���� ����
    void EndGame()
    {
        // ** ���� ���� �� UI On
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    // ** ���� �¸�
    public void winLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
