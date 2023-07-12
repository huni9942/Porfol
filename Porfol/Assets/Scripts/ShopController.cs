using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    // ** ���� �Ŵ��� �ν��Ͻ� ����
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    // ** �⺻ �ͷ� ����
    public void SelectStandardTurret ()
    {
        // ** �⺻ �ͷ��� ������ �ͷ����� ����
        buildManager.SelectTurretToBuild(standardTurret);
    }

    // ** �̻��� �ͷ� ����
    public void SelectMissileLauncher()
    {
        // ** �̻��� �ͷ��� ������ �ͷ����� ����
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
