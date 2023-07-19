using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSpawner : MonoBehaviour
{
    // ** ���콺�� �������� �� ����
    public Color hoverColor;
    // ** ���� ������ �� ����
    public Color notEnoughMoneyColor;
    // ** �ͷ��� ��ġ ����
    public Vector3 positionOffset;

    [HideInInspector]
    // ** �Ǽ��� �ͷ�
    public GameObject turret;
    [HideInInspector]
    // ** �ͷ� û����
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    // ** ���׷��̵� ����
    public bool isUpgraded = false;
    // ** ������
    public Renderer rend;
    // ** �ʱ� ����
    public Color startColor;

    // ** ���� �Ŵ��� ��ũ��Ʈ
    BuildManager buildManager;
    private void Start()
    {
        // ** Ÿ�� �������� ������ ������Ʈ
        rend = GetComponent<Renderer>();
        // ** �ʱ� ������ �����Ѵ�
        startColor = rend.material.color;

        // ** Ÿ�� ��ġ�� Y������ 1��ŭ �ø���
        positionOffset = Vector3.up;

        // ** ���� �Ŵ����� �ν��Ͻ�
        buildManager = BuildManager.instance;
    }

    // ** Ÿ���� ������ ��ġ
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    // ** Ÿ�� ������ Ŭ�� ��
    private void OnMouseDown()
    {
        // ** ���콺 �����Ͱ� �ٸ� ���� ������Ʈ ���� ������ �� ��ȯ�Ѵ�
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // ** �ͷ� ���� �� �����Ѵ�
        if (turret != null)
        {
             buildManager.SelectTurret(this);
             return;
        }

        // ** ������ �ͷ��� �������� ���� �� ��ȯ�Ѵ�
        if (!buildManager.CanBuild)
            return;

        // ** �� ���� ��쿡 �ͷ��� �����Ѵ�
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        // ** ������ ���� �ͷ� ���ݺ��� ���� ��� ��ȯ�Ѵ�
        if (PlayerStats.Money < blueprint.cost)
            return;

        // ** ������ ������ �ͷ� ���ݸ�ŭ �����Ѵ�
        PlayerStats.Money -= blueprint.cost;

        // ** ������ �ͷ��� �����Ѵ�
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        // ** ������ �ͷ��� �����Ѵ�
        turret = _turret;

        turretBlueprint = blueprint;

        // ** ���� �� ����Ʈ�� ���� �����Ѵ�
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // ** ����Ʈ�� �Ҹ��Ų��
        Destroy(effect, 5.0f);
    }

    public void UpgradeTurret()
    {
        // ** ������ ���� �ͷ� ���ݺ��� ���� ��� ��ȯ�Ѵ�
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
            return;

        // ** ������ ������ �ͷ� ���ݸ�ŭ �����Ѵ�
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        // ** ������ �ͷ��� �����Ѵ�
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        // ** ������ �ͷ��� �����Ѵ�
        turret = _turret;

        // ** ���� �� ����Ʈ�� ���� �����Ѵ�
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // ** ����Ʈ�� �Ҹ��Ų��
        Destroy(effect, 5.0f);

        // ** ���׷��̵� ���¸� ������ �Ѵ�
        isUpgraded = true;
    }

    // ** �ͷ� �Ǹ�
    public void SellTurret()
    {
        // ** �÷��̾ ���� ������ ���� �Ǹ��� �� ��ŭ ������Ų��
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        // ** ���� �� ����Ʈ�� ���� �����Ѵ�
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        // ** ����Ʈ�� �ͷ��� �Ҹ��Ų��
        Destroy(effect, 5.0f);
        Destroy(turret);
        turretBlueprint = null;
    }

    // ** ���콺�� �������� �� ���� ����
    private void OnMouseEnter()
    {
        // ** ���콺 �����Ͱ� �ٸ� ���� ������Ʈ ���� ������ �� ��ȯ�Ѵ�
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // ** ������ �ͷ��� �������� ���� �� ��ȯ�Ѵ�
        if (!buildManager.CanBuild)
            return;
        // ** TowerSpawner�� �÷��� �����Ѵ�
        rend.material.color = hoverColor;

        // ** ���� ����� ���
        if(buildManager.HasMoney)
        {
            // ** �ͷ� ���� ���� �������� �����Ѵ�
            rend.material.color = hoverColor;
        }
        // ** ���� ������ ���
        else
        {
            // ** �ͷ� ���� �Ұ��� �������� �����Ѵ�
            rend.material.color = notEnoughMoneyColor;
        }
    }

    // ** ���콺�� ����� �� ���� �ʱ�ȭ
    private void OnMouseExit()
    {
            rend.material.color = startColor;
    }
}
