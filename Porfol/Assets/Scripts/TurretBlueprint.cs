using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    // ** �ͷ� ������
    public GameObject prefab;
    // ** �ͷ� ���
    public int cost;

    // ** ���׷��̵� �ͷ� ������
    public GameObject upgradedPrefab;
    // ** ���׷��̵� ���
    public int upgradeCost;

    // ** �Ǹ� ���
    public int GetSellAmount()
    {
        return cost / 2;
    }
}
