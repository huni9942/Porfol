using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    // ** 플레이어의 생명력을 나타낼 텍스트
    public Text livesText;

    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString();
    }
}
