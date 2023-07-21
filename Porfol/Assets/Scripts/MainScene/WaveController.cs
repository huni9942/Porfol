using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveController
{
    // ** 소환할 Enemy 프리펩
    public GameObject enemy;
    // ** 소환할 갯수
    public int count;
    // ** 소환할 시간 차이
    public float rate;
}
