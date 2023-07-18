using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    // ** UI를 관리할 오브젝트
    public GameObject ui;
    // ** UI를 표시할 터렛
    private TowerSpawner target;

    // ** UI를 표시할 터렛 지정
    public void SetTarget(TowerSpawner _target)
    {
        target = _target;
        // ** UI의 위치 = 터렛의 위치
        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }

    // ** UI 숨기기
    public void Hide()
    {
        ui.SetActive(false);
    }

}
