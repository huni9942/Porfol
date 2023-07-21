using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    // ** 터렛 프리펩
    public GameObject prefab;
    // ** 터렛 비용
    public int cost;

    // ** 업그레이드 터렛 프리펩
    public GameObject upgradedPrefab;
    // ** 업그레이드 비용
    public int upgradeCost;

    // ** 판매 비용
    public int GetSellAmount()
    {
        return cost / 2;
    }
}
