using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyMovement : MonoBehaviour
{
    // ** target의 트랜스폼
    private Transform target;
    // ** waypoint의 index를 가리킬 변수 wavepointIndex
    private int wavepointIndex = 0;

    // ** Enemy가 가진 스크립트
    private EnemyController enemy;

    private void Start()
    {
        // ** Enemy의 스크립트 컴포넌트를 가져온다
        enemy = GetComponent<EnemyController>();

        // ** 첫 번째 Waypoint를 target으로 지정한다
        target = Waypoints.points[0];
    }

    private void Update()
    {
        // ** Waypoint에 도달하기 위한 방향 벡터를 설정한다
        Vector3 dir = target.position - transform.position;
        // ** Enemy의 Transform이 Space.World 좌표 기준, 정규화된 방향 * 속도 * 시간에 따라 이동한다
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        // ** Enemy와 Waypoint 사이의 거리가 0.4f 이하일 때 함수 호출한다
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        // ** Enemy의 속도를 시작 시 속도로 초기화한다
        enemy.speed = enemy.startSpeed;
    }

    // ** 다음 Waypoint를 찾는 함수
    void GetNextWaypoint()
    {
        // ** 최종 Waypoint에 도달했을 때, Enemy를 파괴한다
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        // ** wavepointIndex 값을 증가한다
        wavepointIndex++;
        // ** 다음 Waypoint를 target으로 지정한다
        target = Waypoints.points[wavepointIndex];
    }

    // ** Enemy가 최종 Waypoint에 도달했을 때
    void EndPath()
    {
        // ** 플레이어의 생명력과 Enemy의 수를 1씩 줄인다
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        // ** Enemy를 파괴한다
        Destroy(gameObject);
    }
}
