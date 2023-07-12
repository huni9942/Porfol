using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // ** �̱��� �ν��Ͻ� ����
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // ** �⺻ �ͷ� ������
    public GameObject standardTurretPrefab;

    public GameObject MissileLauncherPrefab;

    // ** ������ �ͷ�
    private GameObject turretToBuild;
    
    // ** ������ �ͷ� ��ȯ
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    // ** ������ �ͷ� ����
    public void SetTurretToBuild ( GameObject turret)
    {
        turretToBuild = turret;
    }
}