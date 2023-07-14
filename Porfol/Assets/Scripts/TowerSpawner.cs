using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSpawner : MonoBehaviour
{
    // ** 마우스를 감지했을 때 색상
    public Color hoverColor;
    // ** 돈이 부족할 때 색상
    public Color notEnoughMoneyColor;
    // ** 터렛의 위치 조정
    public Vector3 positionOffset;

    [Header("Optional")]
    // ** 건설할 터렛
    public GameObject turret;
    // ** 렌더러
    private Renderer rend;
    // ** 초기 색상
    private Color startColor;

    // ** 빌드 매니저 스크립트
    BuildManager buildManager;
    private void Start()
    {
        // ** 타워 스포너의 렌더러 컴포넌트
        rend = GetComponent<Renderer>();
        // ** 초기 색상을 설정한다
        startColor = rend.material.color;

        // ** 빌드 매니저의 인스턴스
        buildManager = BuildManager.instance;
    }

    // ** 타워를 빌드할 위치
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    // ** 타워 스포너 클릭 시
    private void OnMouseDown()
    {
        // ** 마우스 포인터가 다른 게임 오브젝트 위에 존재할 때 반환한다
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // ** 빌드할 터렛이 존재하지 않을 때 반환한다
        if (!buildManager.CanBuild)
            return;

        // ** 터렛 존재 시 반환한다
        if (turret != null)
        {
            return;
        }

        // ** 그 외의 경우에 터렛을 빌드한다
        buildManager.BuildTurretOn(this);
    }

    // ** 마우스를 감지했을 때 색상 변경
    private void OnMouseEnter()
    {
        // ** 마우스 포인터가 다른 게임 오브젝트 위에 존재할 때 반환한다
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // ** 빌드할 터렛이 존재하지 않을 때 반환한다
        if (!buildManager.CanBuild)
            return;
        // ** TowerSpawner의 컬러를 변경한다
        rend.material.color = hoverColor;

        // ** 돈이 충분할 경우
        if(buildManager.HasMoney)
        {
            // ** 터렛 빌드 가능 색상으로 변경한다
            rend.material.color = hoverColor;
        }
        // ** 돈이 부족할 경우
        else
        {
            // ** 터렛 빌드 불가능 색상으로 변경한다
            rend.material.color = notEnoughMoneyColor;
        }
    }

    // ** 마우스가 벗어났을 때 색상 초기화
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
