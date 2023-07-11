using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    // ** 빌드 매니저 인스턴스 참조
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    // ** 기본 터렛 구입
    public void PurchaseStandardTurret ()
    {
        // ** 기본 터렛을 빌드할 터렛으로 세팅
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseMissileLauncher()
    {
        buildManager.SetTurretToBuild(buildManager.MissileLauncherPrefab);
    }
}
