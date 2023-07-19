using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // ** 싱글톤 인스턴스 생성
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // ** 기본 터렛 프리펩
    public GameObject standardTurretPrefab;
    // ** 미사일 터렛 프리펩
    public GameObject MissileLauncherPrefab;
    // ** 터렛 빌드 시 이펙트
    public GameObject buildEffect;

    // ** 빌드할 터렛
    private TurretBlueprint turretToBuild;
    // ** 선택한 터렛
    private TowerSpawner selectedTurret;

    // ** 터렛 UI
    public TurretUI turretUI;

    // ** 빌드할 터렛이 null이 아닐 때 참인 값
    public bool CanBuild { get { return turretToBuild != null; } }
    // ** 플레이어의 돈이 타워의 비용보다 많을 때 참인 값
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    // ** 터렛 선택
    public void SelectTurret(TowerSpawner turret)
    {
        // ** 터렛을 이미 선택했을 경우, 선택을 해제한다
        if (selectedTurret == turret)
        {
            DeselectTurret();
            return;
        }

        // ** 터렛을 선택한다
        selectedTurret = turret;
        // ** 빌드할 터렛을 해제한다
        turretToBuild = null;

        // ** 터렛 UI를 표시한다
        turretUI.SetTarget(turret);
    }

    // ** 터렛 선택 해제
    public void DeselectTurret()
    {
        // ** 터렛을 선택 해제한다
        selectedTurret = null;
        // ** UI를 숨긴다
        turretUI.Hide();
    }

    // ** 빌드할 터렛을 세팅한다
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
