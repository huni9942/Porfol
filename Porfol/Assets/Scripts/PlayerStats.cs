using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // ** 플레이어가 현재 보유중인 돈
    public static int Money;
    // ** 시작 시 지급할 돈
    public int startMoney = 400;
    // ** 플레이어의 현재 생명력
    public static int Lives;
    // ** 시작 시 플레이어의 생명력
    public int startLives = 20;

    // ** 라운드 수
    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }
}
