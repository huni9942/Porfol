using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    // ** 기본 터렛의 청사진
    public TurretBlueprint standardTurret;
    // ** 미사일 터렛의 청사진
    public TurretBlueprint missileLauncher;
    // ** 레이저 터렛의 청사진
    public TurretBlueprint laserBeamer;

    // ** 빌드 매니저 스크립트
    BuildManager buildManager;

    private void Start()
    {
        // ** 빌드 매니저 스크립트의 인스턴스
        buildManager = BuildManager.instance;
    }

    // ** 기본 터렛 구입
    public void SelectStandardTurret ()
    {
        // ** 기본 터렛을 빌드할 터렛으로 세팅한다
        buildManager.SelectTurretToBuild(standardTurret);
    }

    // ** 미사일 터렛 구입
    public void SelectMissileLauncher()
    {
        // ** 미사일 터렛을 빌드할 터렛으로 세팅한다
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    // ** 레이저 터렛 구입
    public void SelectLaserBeamer()
    {
        // ** 레이저 터렛을 빌드할 터렛으로 세팅한다
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
