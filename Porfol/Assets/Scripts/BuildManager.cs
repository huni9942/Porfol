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

    public GameObject MissileLauncherPrefab;

    // ** 빌드할 터렛
    private TurretBlueprint turretToBuild;

    // ** 빌드할 터렛이 null이 아닐 때 참인 값
    public bool CanBuild { get { return turretToBuild != null; } }

    // ** 터렛 빌드
    public void BuildTurretOn (TowerSpawner towerSpawner)
    {
        // ** 보유한 돈이 터렛 가격보다 적을 경우 반환
        if (PlayerStats.Money < turretToBuild.cost)
            return;

        // ** 보유한 돈에서 터렛 가격만큼 차감
        PlayerStats.Money -= turretToBuild.cost;

        // ** 빌드할 터렛을 복사
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, towerSpawner.GetBuildPosition(), Quaternion.identity);
        // ** 복사한 터렛을 빌드
        towerSpawner.turret = turret;
    }

    // ** 빌드할 터렛 세팅
    public void SelectTurretToBuild( TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
