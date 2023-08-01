using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSpawner : MonoBehaviour
{
    // ** ���콺�� �������� �� ����
    public Color hoverColor;
    // ** �Ǽ� ������ �� ����
    public Color canBuildColor;
    // ** �Ǽ� �Ұ��� �� ����
    public Color cannotBuildColor;
    // ** ���׷��̵� ������ �� ����
    public Color canUpgradeColor;
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

    public GameObject notEnoughMoneyText;
    public GameObject pleasePickTurretText;

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
        {
            pleasePickTurret();
            return;
        }
        // ** �� ���� ��쿡 �ͷ��� �����Ѵ�
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        // ** ������ ���� �ͷ� ���ݺ��� ���� ��� ��ȯ�Ѵ�
        if (PlayerStats.Money < blueprint.cost)
        {
            notEnoughMoeny();
            return;
        }
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
        clearText();
    }

    public void UpgradeTurret()
    {
        // ** ������ ���� �ͷ� ���ݺ��� ���� ��� ��ȯ�Ѵ�
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            notEnoughMoeny();
            return;
        }
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

        clearText();
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
        isUpgraded = false;
        clearText();
    }

    // ** ���콺�� �������� �� ���� ����
    private void OnMouseEnter()
    {
        // ** ���콺 �����Ͱ� �ٸ� ���� ������Ʈ ���� ������ �� ��ȯ�Ѵ�
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // ** �ͷ��� ���������� �̹� �ͷ��� ������ ��
        if (buildManager.CanBuild && turret != null)
            rend.material.color = cannotBuildColor;
        // ** �ͷ��� �����ϰ� �ͷ��� �������� ���� ��
        else if (buildManager.CanBuild && turret == null)
            rend.material.color = canBuildColor;
        else
            rend.material.color = hoverColor;

        // ** �ͷ��� ���������� ���� ���� ���
        if (buildManager.CanBuild && !buildManager.HasMoney)
        {
            rend.material.color = cannotBuildColor;
        }

        // ** �ͷ��� �����ϰ� ���׷��̵�� ���°� �ƴϸ� ���� ����� ���
        if (turret != null && !isUpgraded && PlayerStats.Money > turretBlueprint.upgradeCost)
            rend.material.color = canUpgradeColor;
        else if (turret != null && !isUpgraded && PlayerStats.Money < turretBlueprint.upgradeCost)
            rend.material.color = cannotBuildColor;
    }

    // ** ���콺�� ����� �� ���� �ʱ�ȭ
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
