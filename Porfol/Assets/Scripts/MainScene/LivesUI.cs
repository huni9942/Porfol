using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    // ** �÷��̾��� ������� ��Ÿ�� �ؽ�Ʈ
    public Text livesText;

    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString();
    }
}
