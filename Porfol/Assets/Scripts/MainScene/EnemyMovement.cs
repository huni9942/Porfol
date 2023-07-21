using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyMovement : MonoBehaviour
{
    // ** target�� Ʈ������
    private Transform target;
    // ** waypoint�� index�� ����ų ���� wavepointIndex
    private int wavepointIndex = 0;

    // ** Enemy�� ���� ��ũ��Ʈ
    private EnemyController enemy;

    private void Start()
    {
        // ** Enemy�� ��ũ��Ʈ ������Ʈ�� �����´�
        enemy = GetComponent<EnemyController>();

        // ** ù ��° Waypoint�� target���� �����Ѵ�
        target = Waypoints.points[0];
    }

    private void Update()
    {
        // ** Waypoint�� �����ϱ� ���� ���� ���͸� �����Ѵ�
        Vector3 dir = target.position - transform.position;
        // ** Enemy�� Transform�� Space.World ��ǥ ����, ����ȭ�� ���� * �ӵ� * �ð��� ���� �̵��Ѵ�
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        // ** Enemy�� Waypoint ������ �Ÿ��� 0.4f ������ �� �Լ� ȣ���Ѵ�
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        // ** Enemy�� �ӵ��� ���� �� �ӵ��� �ʱ�ȭ�Ѵ�
        enemy.speed = enemy.startSpeed;
    }

    // ** ���� Waypoint�� ã�� �Լ�
    void GetNextWaypoint()
    {
        // ** ���� Waypoint�� �������� ��, Enemy�� �ı��Ѵ�
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        // ** wavepointIndex ���� �����Ѵ�
        wavepointIndex++;
        // ** ���� Waypoint�� target���� �����Ѵ�
        target = Waypoints.points[wavepointIndex];
    }

    // ** Enemy�� ���� Waypoint�� �������� ��
    void EndPath()
    {
        // ** �÷��̾��� ����°� Enemy�� ���� 1�� ���δ�
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        // ** Enemy�� �ı��Ѵ�
        Destroy(gameObject);
    }
}
