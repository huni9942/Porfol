using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    // ** UI�� ������ ������Ʈ
    public GameObject ui;

    // ** ���׷��̵� ��� �ؽ�Ʈ
    public Text upgradeCost;
    // ** ���׷��̵� ��ư
    public Button upgradeButton;

    // ** �Ǹ� ��� �ؽ�Ʈ
    public Text sellAmount;

    // ** UI�� ǥ���� �ͷ�
    private TowerSpawner target;

    // ** UI�� ǥ���� �ͷ� ����
    public void SetTarget(TowerSpawner _target)
    {
        target = _target;
        // ** UI�� ��ġ = �ͷ��� ��ġ
        transform.position = target.GetBuildPosition();

        // ** �ͷ��� ���׷��̵� �� ���°� �ƴ� ��, ��ư ��ȣ�ۿ� Ȱ��ȭ
        if(!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost + "G";
            upgradeButton.interactable = true;
        }
        // ** �ͷ��� ���׷��̵� ������ ��, ��ư ��ȣ�ۿ� ��Ȱ��ȭ
        else
        {
            upgradeCost.text = "�Ϸ�";
            upgradeButton.interactable = false;
        }

        // ** �ͷ� �Ǹ� �ؽ�Ʈ
        sellAmount.text = target.turretBlueprint.GetSellAmount() + "G";

        // ** UI Ȱ��ȭ
        ui.SetActive(true);
    }

    // ** UI ��Ȱ��ȭ
    public void Hide()
    {
        ui.SetActive(false);
    }

    // ** ���׷��̵�
    public void Upgrade ()
    {
        // ** �ͷ� ���׷��̵� �� �ͷ� ���� ����
        target.UpgradeTurret();
        BuildManager.instance.DeselectTurret();
    }

    // ** �Ǹ�
    public void Sell ()
    {
        // ** �ͷ� �Ǹ� �� �ͷ� ���� ����
        target.SellTurret();
        BuildManager.instance.DeselectTurret();
    }
}
