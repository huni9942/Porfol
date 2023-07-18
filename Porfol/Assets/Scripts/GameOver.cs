using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // ** 라운드 텍스트
    public Text roundsText;

    // ** 게임 오버 시, 라운드 텍스트는 현재 라운드를 문자열화 한다
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    // ** 재시도 시, 현재 활성화 되어있는 씬을 다시 불러온다.
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {

    }
}
