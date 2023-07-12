using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    // ** ���� �Ŵ��� �ν��Ͻ� ����
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    // ** �⺻ �ͷ� ����
    public void PurchaseStandardTurret ()
    {
        // ** �⺻ �ͷ��� ������ �ͷ����� ����
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    // ** �̻��� �ͷ� ����
    public void PurchaseMissileLauncher()
    {
        // ** �̻��� �ͷ��� ������ �ͷ����� ����
        buildManager.SetTurretToBuild(buildManager.MissileLauncherPrefab);
    }
}
