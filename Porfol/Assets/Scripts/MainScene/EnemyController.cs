using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Enemy�� ���� �ӵ�
    public float startSpeed = 10.0f;
    
    [HideInInspector]
    // ** Enemy�� �ӵ�
    public float speed;

    // ** Enemy�� ü��
    public float starthealth = 100.0f;

    private float health;

    // ** Enemy�� ����
    public int reward = 50;

    // ** ��� �� ����Ʈ
    public GameObject deathEffect;

    public Image healthBar;

    private void Start()
    {
        // ** �ӵ��� �ʱ�ȭ�Ѵ�
        speed = startSpeed;

        health = starthealth;
    }

    // ** Enemy�� �Դ� ����
    public void TakeDamage(float amount)
    {
        // ** ���ط���ŭ ü���� �Ҹ��Ѵ�
        health -= amount;

        healthBar.fillAmount = health / starthealth;

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

        WaveSpawner.EnemiesAlive--;

        // ** Enemy�� �ı��Ѵ�
        Destroy(gameObject);
    }

    
}
