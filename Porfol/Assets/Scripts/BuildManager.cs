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
    // ** ������ �ͷ�
    private TowerSpawner selectedTurret;

    // ** �ͷ� UI
    public TurretUI turretUI;

    // ** ������ �ͷ��� null�� �ƴ� �� ���� ��
    public bool CanBuild { get { return turretToBuild != null; } }
    // ** �÷��̾��� ���� Ÿ���� ��뺸�� ���� �� ���� ��
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    // ** �ͷ� ����
    public void SelectTurret(TowerSpawner turret)
    {
        // ** �ͷ��� �̹� �������� ���, ������ �����Ѵ�
        if (selectedTurret == turret)
        {
            DeselectTurret();
            return;
        }

        // ** �ͷ��� �����Ѵ�
        selectedTurret = turret;
        // ** ������ �ͷ��� �����Ѵ�
        turretToBuild = null;

        // ** �ͷ� UI�� ǥ���Ѵ�
        turretUI.SetTarget(turret);
    }

    // ** �ͷ� ���� ����
    public void DeselectTurret()
    {
        // ** �ͷ��� ���� �����Ѵ�
        selectedTurret = null;
        // ** UI�� �����
        turretUI.Hide();
    }

    // ** ������ �ͷ��� �����Ѵ�
    public void SelectTurretToBuild( TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectTurret();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
