using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    // ** 마우스를 감지했을 때 색상
    public Color hoverColor;
    // ** 터렛의 위치 조정
    public Vector3 positionOffset;
    // ** 건설할 터렛
    private GameObject turret;
    // ** 렌더러
    private Renderer rend;
    // ** 초기 색상
    private Color startColor;

    private void Start()
    {
        // ** 타워 스포너의 렌더러 가져오기
        rend = GetComponent<Renderer>();
        // ** 초기 색상 설정
        startColor = rend.material.color;
    }

    // ** 타워 스포너 클릭 시
    private void OnMouseDown()
    {
        // ** 터렛 존재 시 반환
        if (turret != null)
        {
            return;
        }
        // ** 빌드할 터렛의 종류 받아오기
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        // ** 빌드할 터렛을 복사하여 소환
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    // ** 마우스를 감지했을 때 색상 변경
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    // ** 마우스가 벗어났을 때 색상 변경
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
