using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Enemy의 시작 속도
    public float startSpeed = 10.0f;
    
    [HideInInspector]
    // ** Enemy의 속도
    public float speed;

    // ** Enemy의 체력
    public float starthealth = 100.0f;

    private float health;

    // ** Enemy의 보상
    public int reward = 50;

    // ** 사망 시 이펙트
    public GameObject deathEffect;

    public Image healthBar;

    private void Start()
    {
        // ** 속도를 초기화한다
        speed = startSpeed;

        health = starthealth;
    }

    // ** Enemy가 입는 피해
    public void TakeDamage(float amount)
    {
        // ** 피해량만큼 체력을 소모한다
        health -= amount;

        healthBar.fillAmount = health / starthealth;

        // ** 체력이 0이하일 때 사망한다
        if (health <= 0)
        {
            Die();
        }
    }

    // ** 감속
    public void Slow(float pct)
    {
        speed = startSpeed * (1.0f - pct);
    }

    // ** Enemy 사망 시
    void Die()
    {
        // ** 플레이어의 돈이 보상만큼 증가한다
        PlayerStats.Money += reward;

        // ** 사망 시 이펙트를 복사 생성한다
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        // ** 이펙트를 소멸시킨다
        Destroy(effect, 2.0f);

        WaveSpawner.EnemiesAlive--;

        // ** Enemy를 파괴한다
        Destroy(gameObject);
    }

    
}
