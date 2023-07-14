using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    // Enemy�� ���� �ӵ�
    public float startSpeed = 10.0f;
    
    [HideInInspector]
    // ** Enemy�� �ӵ�
    public float speed;

    // ** Enemy�� ü��
    public float health = 100.0f;

    // ** Enemy�� ����
    public int reward = 50;

    // ** ��� �� ����Ʈ
    public GameObject deathEffect;

    private void Start()
    {
        // ** �ӵ��� �ʱ�ȭ�Ѵ�
        speed = startSpeed;
    }

    // ** Enemy�� �Դ� ����
    public void TakeDamage(float amount)
    {
        // ** ���ط���ŭ ü���� �Ҹ��Ѵ�
        health -= amount;

        // ** ü���� 0������ �� ����Ѵ�
        if (health <= 0)
        {
            Die();
        }
    }

    // ** ����
    public void Slow(float pct)
    {
        speed = startSpeed * (1.0f - pct);
    }

    // ** Enemy ��� ��
    void Die()
    {
        // ** �÷��̾��� ���� ����ŭ �����Ѵ�
        PlayerStats.Money += reward;

        // ** ��� �� ����Ʈ�� ���� �����Ѵ�
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        // ** ����Ʈ�� �Ҹ��Ų��
        Destroy(effect, 2.0f);
        // ** Enemy�� �ı��Ѵ�
        Destroy(gameObject);
    }

    
}
