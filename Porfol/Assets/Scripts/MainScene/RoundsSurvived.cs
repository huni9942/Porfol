using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    // ** ���� �ؽ�Ʈ
    public Text roundsText;

    // ** ���� ���� ��, ���� �ؽ�Ʈ�� ���� ���带 ���ڿ�ȭ �Ѵ�
    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.07f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    }

}
