using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    // ** UI를 관리할 오브젝트
    public GameObject ui;

    // ** 업그레이드 비용 텍스트
    public Text upgradeCost;
    // ** 업그레이드 버튼
    public Button upgradeButton;

    // ** 판매 비용 텍스트
    public Text sellAmount;

    // ** UI를 표시할 터렛
    private TowerSpawner target;

    // ** UI를 표시할 터렛 지정
    public void SetTarget(TowerSpawner _target)
    {
        target = _target;
        // ** UI의 위치 = 터렛의 위치
        transform.position = target.GetBuildPosition();

        // ** 터렛이 업그레이드 된 상태가 아닐 때, 버튼 상호작용 활성화
        if(!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost + "G";
            upgradeButton.interactable = true;
        }
        // ** 터렛이 업그레이드 상태일 때, 버튼 상호작용 비활성화
        else
        {
            upgradeCost.text = "완료";
            upgradeButton.interactable = false;
        }

        // ** 터렛 판매 텍스트
        sellAmount.text = target.turretBlueprint.GetSellAmount() + "G";

        // ** UI 활성화
        ui.SetActive(true);
    }

    // ** UI 비활성화
    public void Hide()
    {
        ui.SetActive(false);
    }

    // ** 업그레이드
    public void Upgrade ()
    {
        // ** 터렛 업그레이드 후 터렛 선택 해제
        target.UpgradeTurret();
        BuildManager.instance.DeselectTurret();
    }

    // ** 판매
    public void Sell ()
    {
        // ** 터렛 판매 후 터렛 선택 해제
        target.SellTurret();
        BuildManager.instance.DeselectTurret();
    }
}
