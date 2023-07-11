using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSpawner : MonoBehaviour
{
    // ** ���콺�� �������� �� ����
    public Color hoverColor;
    // ** �ͷ��� ��ġ ����
    public Vector3 positionOffset;
    // ** �Ǽ��� �ͷ�
    private GameObject turret;
    // ** ������
    private Renderer rend;
    // ** �ʱ� ����
    private Color startColor;

    BuildManager buildManager;
    private void Start()
    {
        // ** Ÿ�� �������� ������ ��������
        rend = GetComponent<Renderer>();
        // ** �ʱ� ���� ����
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    // ** Ÿ�� ������ Ŭ�� ��
    private void OnMouseDown()
    {
        // ** ���콺 �����Ͱ� �ٸ� ���� ������Ʈ ���� ������ �� ��ȯ
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // ** ������ �ͷ��� �������� ���� �� ��ȯ
        if (buildManager.GetTurretToBuild() == null)
            return;

        // ** �ͷ� ���� �� ��ȯ
        if (turret != null)
        {
            return;
        }
        // ** ������ �ͷ��� ���� �޾ƿ���
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        // ** ������ �ͷ��� �����Ͽ� ��ȯ
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    // ** ���콺�� �������� �� ���� ����
    private void OnMouseEnter()
    {
        // ** ���콺 �����Ͱ� �ٸ� ���� ������Ʈ ���� ������ �� ��ȯ
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // ** ������ �ͷ��� �������� ���� �� ��ȯ
        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = hoverColor;
    }

    // ** ���콺�� ����� �� ���� ����
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
