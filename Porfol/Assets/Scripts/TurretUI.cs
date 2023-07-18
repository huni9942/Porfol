using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    // ** UI�� ������ ������Ʈ
    public GameObject ui;
    // ** UI�� ǥ���� �ͷ�
    private TowerSpawner target;

    // ** UI�� ǥ���� �ͷ� ����
    public void SetTarget(TowerSpawner _target)
    {
        target = _target;
        // ** UI�� ��ġ = �ͷ��� ��ġ
        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }

    // ** UI �����
    public void Hide()
    {
        ui.SetActive(false);
    }

}
