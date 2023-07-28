using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        // ** Floor 클릭 시 빌드할 터렛 선택 해제
        buildManager.DeseletTurretToBuild();
    }
}
