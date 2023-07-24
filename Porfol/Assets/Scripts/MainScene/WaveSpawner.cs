using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    // ** 생존한 Enemy의 수
    public static int EnemiesAlive = 0;
    
    // ** Wave 배열
    public WaveController[] waves;
    // ** spawnPoint의 트랜스폼
    public Transform spawnPoint;

    // ** Wave 사이 시간 간격
    public float timeBetweenWaves = 5.0f;
    // ** 다음 Wave까지 걸리는 시간
    private float countdown = 2.0f;

    // ** countdown을 표기하는 텍스트
    public Text waveCountdownText;

    // ** 승리 시 처리를 위한 게임 매니저 
    public GameManager gameManager;

    // ** 현재 Wave 단계
    private int waveIndex = 0;

    private void Update()
    {
        // ** Enemy가 존재할 때 리턴한다
        if(EnemiesAlive > 0)
        {
            return;
        }

        // ** countdown이 0이하일 때 SpawnWave 코루틴 함수 실행 및 countdown 초기화
        if (countdown <= 0.0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
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
        // ** 라운드를 증가시킨다
        PlayerStats.Rounds++;

        // ** 현재 Wave 목록의 Wave를 불러온다
        WaveController wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        // ** Wave 단계에 따라 일정 간격마다 함수 호출을 반복한다
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1.0f / wave.rate);
        }
        // ** Wave 단계를 증가시킨다
        waveIndex++;

        // ** Wave가 끝나면 승리 처리 후 비활성화한다
        if (waveIndex == waves.Length)
        {
            gameManager.winLevel();
            this.enabled = false;
        }
    }

    // ** Enemy 생성 함수
    void SpawnEnemy(GameObject enemy)
    {
        // ** spawnPoint의 위치와 회전값을 가진 enemy를 복사 생성한다
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
