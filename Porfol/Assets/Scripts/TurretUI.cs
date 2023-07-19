using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    // ** UI�� ������ ������Ʈ
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    // ** UI�� ǥ���� �ͷ�
    private TowerSpawner target;

    // ** UI�� ǥ���� �ͷ� ����
    public void SetTarget(TowerSpawner _target)
    {
        target = _target;
        // ** UI�� ��ġ = �ͷ��� ��ġ
        transform.position = target.GetBuildPosition();

        if(!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        ui.SetActive(true);
    }

    // ** UI �����
    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade ()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectTurret();
    }
}
