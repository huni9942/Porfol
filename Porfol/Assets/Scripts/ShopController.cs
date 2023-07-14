using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    // ** �⺻ �ͷ��� û����
    public TurretBlueprint standardTurret;
    // ** �̻��� �ͷ��� û����
    public TurretBlueprint missileLauncher;
    // ** ������ �ͷ��� û����
    public TurretBlueprint laserBeamer;

    // ** ���� �Ŵ��� ��ũ��Ʈ
    BuildManager buildManager;

    private void Start()
    {
        // ** ���� �Ŵ��� ��ũ��Ʈ�� �ν��Ͻ�
        buildManager = BuildManager.instance;
    }

    // ** �⺻ �ͷ� ����
    public void SelectStandardTurret ()
    {
        // ** �⺻ �ͷ��� ������ �ͷ����� �����Ѵ�
        buildManager.SelectTurretToBuild(standardTurret);
    }

    // ** �̻��� �ͷ� ����
    public void SelectMissileLauncher()
    {
        // ** �̻��� �ͷ��� ������ �ͷ����� �����Ѵ�
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    // ** ������ �ͷ� ����
    public void SelectLaserBeamer()
    {
        // ** ������ �ͷ��� ������ �ͷ����� �����Ѵ�
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
