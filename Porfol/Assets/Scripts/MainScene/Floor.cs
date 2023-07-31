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
        // ** Floor 클릭 시 빌드할 터렛 선택 해제
        if (!turretUI)
            buildManager.DeseletTurretToBuild();
    }
}
