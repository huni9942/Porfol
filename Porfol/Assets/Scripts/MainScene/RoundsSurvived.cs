using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    // ** 라운드 텍스트
    public Text roundsText;

    // ** 게임 오버 시, 라운드 텍스트는 현재 라운드를 문자열화 한다
    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = PlayerStats.Rounds.ToString();

        yield return new WaitForSeconds(0.07f);
    }

}
