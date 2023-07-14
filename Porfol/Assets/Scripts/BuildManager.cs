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

    // ** 빌드할 터렛이 null이 아닐 때 참인 값
    public bool CanBuild { get { return turretToBuild != null; } }
    // ** 플레이어의 돈이 타워의 비용보다 많을 때 참인 값
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    // ** 터렛 빌드
    public void BuildTurretOn (TowerSpawner towerSpawner)
    {
        // ** 보유한 돈이 터렛 가격보다 적을 경우 반환한다
        if (PlayerStats.Money < turretToBuild.cost)
            return;

        // ** 보유한 돈에서 터렛 가격만큼 차감한다
        PlayerStats.Money -= turretToBuild.cost;

        // ** 빌드할 터렛을 복사한다
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, towerSpawner.GetBuildPosition(), Quaternion.identity);
        // ** 복사한 터렛을 빌드한다
        towerSpawner.turret = turret;

        // ** 빌드 시 이펙트를 복사 생성한다
        GameObject effect = (GameObject)Instantiate(buildEffect, towerSpawner.GetBuildPosition(), Quaternion.identity);
        // ** 이펙트를 소멸시킨다
        Destroy(effect, 5.0f);
    }

    // ** 빌드할 터렛을 세팅한다
    public void SelectTurretToBuild( TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
