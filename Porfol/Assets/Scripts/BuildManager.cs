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
    private TurretBlueprint turretToBuild;

    // ** ������ �ͷ��� null�� �ƴ� �� ���� ��
    public bool CanBuild { get { return turretToBuild != null; } }

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
    }

    // ** ������ �ͷ� ����
    public void SelectTurretToBuild( TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
