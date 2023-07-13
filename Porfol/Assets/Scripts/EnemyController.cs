using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // ** Enemy의 속도
    public float speed = 10.0f;

    // ** Enemy의 체력
    public int health = 100;

    // ** Enemy의 보상
    public int reward = 50;

    // ** 사망 시 이펙트
    public GameObject deathEffect;

    // ** target의 트랜스폼
    private Transform target;
    // ** waypoint의 index를 가리킬 변수 wavepointIndex
    private int wavepointIndex = 0;

    private void Start()
    {
        // ** 첫 번째 Waypoint를 target으로 지정
        target = Waypoints.points[0];
    }

    // ** Enemy가 입는 피해
    public void TakeDamage(int amount)
    {
        // ** 피해량만큼 체력 소모
        health -= amount;

        // ** 체력이 0이하일 때 사망
        if (health <= 0)
        {
            Die();
        }
    }

    // ** Enemy 사망 시
    void Die()
    {
        // ** 플레이어의 돈이 보상만큼 증가
        PlayerStats.Money += reward;

        // ** 사망 시 이펙트 복사 생성
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        // ** 이펙트 소멸
        Destroy(effect, 2.0f);
        // ** Enemy 파괴
        Destroy(gameObject);
    }

    private void Update()
    {
        // ** Waypoint에 도달하기 위한 방향 벡터 설정
        Vector3 dir = target.position - transform.position;
        // ** Enemy의 Transform이 Space.World 좌표 기준, 정규화된 방향 * 속도 * 시간에 따라 이동
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // ** Enemy와 Waypoint 사이의 거리가 0.4f 이하일 때 함수 호출
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    // ** 다음 Waypoint를 찾는 함수
    void GetNextWaypoint()
    {
        // ** 최종 Waypoint에 도달했을 때, Enemy를 파괴
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        // ** wavepointIndex 값 증가
        wavepointIndex++;
        // ** 다음 Waypoint를 target으로 지정
        target = Waypoints.points[wavepointIndex];
    }

    // ** Enemy가 최종 Waypoint에 도달했을 때
    void EndPath()
    {
        // ** 플레이어의 생명력 소모
        PlayerStats.Lives--;
        // ** Enemy 파괴
        Destroy(gameObject);
    }
}
