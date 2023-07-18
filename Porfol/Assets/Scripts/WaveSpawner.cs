using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    // ** enemyPrefab의 트랜스폼
    public Transform enemyPrefab;
    // ** spawnPoint의 트랜스폼
    public Transform spawnPoint;

    // ** Wave 사이 시간 간격
    public float timeBetweenWaves = 5.0f;
    // ** 다음 Wave까지 걸리는 시간
    private float countdown = 2.0f;

    // ** countdown을 표기하는 텍스트
    public Text waveCountdownText;

    // ** 현재 Wave 단계
    private int waveIndex = 0;

    private void Update()
    {
        // ** countdown이 0이하일 때 SpawnWave 함수 실행 및 countdown 초기화
        if (countdown <= 0.0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        // ** countdown은 실제 시간만큼 감소한다
        countdown -= Time.deltaTime;

        // ** countdown은 0에서 무한대 사이의 값
        countdown = Mathf.Clamp(countdown, 0.0f, Mathf.Infinity);

        // ** countdown을 문자열로 변환하여 텍스트로 표시한다
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    // ** Wave 생성 함수
    IEnumerator SpawnWave()
    {
        // ** Wave 단계를 증가시킨다
        waveIndex++;
        // ** 라운드를 증가시킨다
        PlayerStats.Rounds++;

        // ** Wave 단계에 따라 0.5초마다 함수 호출을 반복한다
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    // ** Enemy 생성 함수
    void SpawnEnemy()
    {
        // ** spawnPoint의 위치와 회전값을 가진 enemyPrefab을 복사 생성한다
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
