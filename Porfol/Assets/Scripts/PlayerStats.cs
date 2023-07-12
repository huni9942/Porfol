using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // ** 플레이어가 현재 보유중인 돈
    public static int Money;
    // ** 시작 시 지급할 돈
    public int startMoney = 400;

    private void Start()
    {
        Money = startMoney;
    }
}
