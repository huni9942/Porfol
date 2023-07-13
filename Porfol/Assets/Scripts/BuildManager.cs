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
    // ** �̻��� �ͷ� ������
    public GameObject MissileLauncherPrefab;
    // ** �ͷ� ���� �� ����Ʈ
    public GameObject buildEffect;

    // ** ������ �ͷ�
    private TurretBlueprint turretToBuild;

    // ** ������ �ͷ��� null�� �ƴ� �� ���� ��
    public bool CanBuild { get { return turretToBuild != null; } }
    // ** �÷��̾��� ���� Ÿ���� ��뺸�� ���� �� ���� ��
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    // ** �ͷ� ����
    public void BuildTurretOn (TowerSpawner towerSpawner)
    {
        // ** ������ ���� �ͷ� ���ݺ��� ���� ��� ��ȯ
        if (PlayerStats.Money < turretToBuild.cost)
            return;

        // ** ������ ������ �ͷ� ���ݸ�ŭ ����
        PlayerStats.Money -= turretToBuild.cost;

        // ** ������ �ͷ��� ����
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, towerSpawner.GetBuildPosition(), Quaternion.identity);
        // ** ������ �ͷ��� ����
        towerSpawner.turret = turret;

        // ** ���� �� ����Ʈ ���� ����
        GameObject effect = (GameObject)Instantiate(buildEffect, towerSpawner.GetBuildPosition(), Quaternion.identity);
        // ** ����Ʈ �Ҹ�
        Destroy(effect, 5.0f);
    }

    // ** ������ �ͷ� ����
    public void SelectTurretToBuild( TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
