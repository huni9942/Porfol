using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSpawner : MonoBehaviour
{
    // ** 마우스를 감지했을 시 색상
    public Color hoverColor;
    // ** 건설 가능할 시 색상
    public Color canBuildColor;
    // ** 건설 불가능 시 색상
    public Color cannotBuildColor;
    // ** 업그레이드 가능할 시 색상
    public Color canUpgradeColor;
    // ** 터렛의 위치 조정
    public Vector3 positionOffset;

    [HideInInspector]
    // ** 건설할 터렛
    public GameObject turret;
    [HideInInspector]
    // ** 터렛 청사진
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    // ** 업그레이드 상태
    public bool isUpgraded = false;
    // ** 렌더러
    public Renderer rend;
    // ** 초기 색상
    public Color startColor;

    public GameObject notEnoughMoneyText;
    public GameObject pleasePickTurretText;

    // ** 빌드 매니저 스크립트
    BuildManager buildManager;
    private void Start()
    {
        // ** 타워 스포너의 렌더러 컴포넌트
        rend = GetComponent<Renderer>();
        // ** 초기 색상을 설정한다
        startColor = rend.material.color;

        // ** 타워 위치를 Y축으로 1만큼 올린다
        positionOffset = Vector3.up;

        // ** 빌드 매니저의 인스턴스
        buildManager = BuildManager.instance;
    }

    // ** 타워를 빌드할 위치
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    // ** 타워 스포너 클릭 시
    private void OnMouseDown()
    {
        // ** 마우스 포인터가 다른 게임 오브젝트 위에 존재할 때 반환한다
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        // ** 터렛 존재 시 선택한다
        if (turret != null)
        {
             buildManager.SelectTurret(this);
             return;
        }

        // ** 빌드할 터렛이 존재하지 않을 때 반환한다
        if (!buildManager.CanBuild)
        {
            pleasePickTurret();
            return;
        }
        // ** 그 외의 경우에 터렛을 빌드한다
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        // ** 보유한 돈이 터렛 가격보다 적을 경우 반환한다
        if (PlayerStats.Money < blueprint.cost)
        {
            notEnoughMoeny();
            return;
        }
        // ** 보유한 돈에서 터렛 가격만큼 차감한다
        PlayerStats.Money -= blueprint.cost;

        // ** 빌드할 터렛을 복사한다
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        // ** 복사한 터렛을 빌드한다
        turret = _turret;

        turretBlueprint = blueprint;

        // ** 빌드 시 이펙트를 복사 생성한다
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // ** 이펙트를 소멸시킨다
        Destroy(effect, 5.0f);
        clearText();
    }

    public void UpgradeTurret()
    {
        // ** 보유한 돈이 터렛 가격보다 적을 경우 반환한다
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            notEnoughMoeny();
            return;
        }
        // ** 보유한 돈에서 터렛 가격만큼 차감한다
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        // ** 빌드할 터렛을 복사한다
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        // ** 복사한 터렛을 빌드한다
        turret = _turret;

        // ** 빌드 시 이펙트를 복사 생성한다
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // ** 이펙트를 소멸시킨다
        Destroy(effect, 5.0f);

        // ** 업그레이드 상태를 참으로 한다
        isUpgraded = true;

        clearText();
    }

    // ** 터렛 판매
    public void SellTurret()
    {
        // ** 플레이어가 현재 보유한 돈을 판매한 값 만큼 증가시킨다
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        // ** 빌드 시 이펙트를 복사 생성한다
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        // ** 이펙트와 터렛을 소멸시킨다
        Destroy(effect, 5.0f);
        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
        clearText();
    }

    // ** 마우스를 감지했을 때 색상 변경
    private void OnMouseEnter()
    {
        // ** 마우스 포인터가 다른 게임 오브젝트 위에 존재할 때 반환한다
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // ** 터렛을 선택했으나 이미 터렛이 존재할 때
        if (buildManager.CanBuild && turret != null)
            rend.material.color = cannotBuildColor;
        // ** 터렛을 선택하고 터렛이 존재하지 않을 때
        else if (buildManager.CanBuild && turret == null)
            rend.material.color = canBuildColor;
        else
            rend.material.color = hoverColor;

        // ** 터렛을 선택했으나 돈이 없을 경우
        if (buildManager.CanBuild && !buildManager.HasMoney)
        {
            rend.material.color = cannotBuildColor;
        }

        // ** 터렛이 존재하고 업그레이드된 상태가 아니며 돈이 충분할 경우
        if (turret != null && !isUpgraded && PlayerStats.Money > turretBlueprint.upgradeCost)
            rend.material.color = canUpgradeColor;
        else if (turret != null && !isUpgraded && PlayerStats.Money < turretBlueprint.upgradeCost)
            rend.material.color = cannotBuildColor;
    }

    // ** 마우스가 벗어났을 때 색상 초기화
    private void OnMouseExit()
    {
            resetColor();
    }

    public void resetColor()
    {
        rend.material.color = startColor;
    }

    public void notEnoughMoeny()
    {
        if (pleasePickTurretText.activeSelf == true)
            pleasePickTurretText.SetActive(false);

        notEnoughMoneyText.SetActive(true);
    }

    public void pleasePickTurret()
    {
        if (notEnoughMoneyText.activeSelf == true)
            notEnoughMoneyText.SetActive(false);

        pleasePickTurretText.SetActive(true);
    }

    public void clearText()
    {
         notEnoughMoneyText.SetActive(false);
         pleasePickTurretText.SetActive(false);
    }
}
