using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        // ** Ÿ�� �������� ������ ��������
        rend = GetComponent<Renderer>();
        // ** �ʱ� ���� ����
        startColor = rend.material.color;
    }

    // ** Ÿ�� ������ Ŭ�� ��
    private void OnMouseDown()
    {
        // ** �ͷ� ���� �� ��ȯ
        if (turret != null)
        {
            return;
        }
        // ** ������ �ͷ��� ���� �޾ƿ���
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        // ** ������ �ͷ��� �����Ͽ� ��ȯ
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    // ** ���콺�� �������� �� ���� ����
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    // ** ���콺�� ����� �� ���� ����
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
