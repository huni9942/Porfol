using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // ** Enemy�� �ӵ�
    public float speed = 10.0f;

    // ** Enemy�� ü��
    public int health = 100;

    // ** Enemy�� ����
    public int reward = 50;

    // ** ��� �� ����Ʈ
    public GameObject deathEffect;

    // ** target�� Ʈ������
    private Transform target;
    // ** waypoint�� index�� ����ų ���� wavepointIndex
    private int wavepointIndex = 0;

    private void Start()
    {
        // ** ù ��° Waypoint�� target���� ����
        target = Waypoints.points[0];
    }

    // ** Enemy�� �Դ� ����
    public void TakeDamage(int amount)
    {
        // ** ���ط���ŭ ü�� �Ҹ�
        health -= amount;

        // ** ü���� 0������ �� ���
        if (health <= 0)
        {
            Die();
        }
    }

    // ** Enemy ��� ��
    void Die()
    {
        // ** �÷��̾��� ���� ����ŭ ����
        PlayerStats.Money += reward;

        // ** ��� �� ����Ʈ ���� ����
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        // ** ����Ʈ �Ҹ�
        Destroy(effect, 2.0f);
        // ** Enemy �ı�
        Destroy(gameObject);
    }

    private void Update()
    {
        // ** Waypoint�� �����ϱ� ���� ���� ���� ����
        Vector3 dir = target.position - transform.position;
        // ** Enemy�� Transform�� Space.World ��ǥ ����, ����ȭ�� ���� * �ӵ� * �ð��� ���� �̵�
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // ** Enemy�� Waypoint ������ �Ÿ��� 0.4f ������ �� �Լ� ȣ��
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    // ** ���� Waypoint�� ã�� �Լ�
    void GetNextWaypoint()
    {
        // ** ���� Waypoint�� �������� ��, Enemy�� �ı�
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        // ** wavepointIndex �� ����
        wavepointIndex++;
        // ** ���� Waypoint�� target���� ����
        target = Waypoints.points[wavepointIndex];
    }

    // ** Enemy�� ���� Waypoint�� �������� ��
    void EndPath()
    {
        // ** �÷��̾��� ����� �Ҹ�
        PlayerStats.Lives--;
        // ** Enemy �ı�
        Destroy(gameObject);
    }
}
