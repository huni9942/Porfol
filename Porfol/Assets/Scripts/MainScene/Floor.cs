using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    BuildManager buildManager;
    public TurretUI turretUI;

    void Start()
    {
        buildManager = BuildManager.instance;
        turretUI = GetComponent<TurretUI>();
    }

    private void OnMouseDown()
    {
        // ** Floor Ŭ�� �� ������ �ͷ� ���� ����
        if (!turretUI)
            buildManager.DeseletTurretToBuild();
    }
}
