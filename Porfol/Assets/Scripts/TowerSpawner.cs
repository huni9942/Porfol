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

    [Header("Optional")]
    // ** �Ǽ��� �ͷ�
    public GameObject turret;
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
        buildManager.BuildTurretOn(this);
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
