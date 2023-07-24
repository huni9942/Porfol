using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    // ** ������ Enemy�� ��
    public static int EnemiesAlive = 0;
    
    // ** Wave �迭
    public WaveController[] waves;
    // ** spawnPoint�� Ʈ������
    public Transform spawnPoint;

    // ** Wave ���� �ð� ����
    public float timeBetweenWaves = 5.0f;
    // ** ���� Wave���� �ɸ��� �ð�
    private float countdown = 2.0f;

    // ** countdown�� ǥ���ϴ� �ؽ�Ʈ
    public Text waveCountdownText;

    // ** �¸� �� ó���� ���� ���� �Ŵ��� 
    public GameManager gameManager;

    // ** ���� Wave �ܰ�
    private int waveIndex = 0;

    private void Update()
    {
        // ** Enemy�� ������ �� �����Ѵ�
        if(EnemiesAlive > 0)
        {
            return;
        }

        // ** countdown�� 0������ �� SpawnWave �ڷ�ƾ �Լ� ���� �� countdown �ʱ�ȭ
        if (countdown <= 0.0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        // ** countdown�� ���� �ð���ŭ �����Ѵ�
        countdown -= Time.deltaTime;

        // ** countdown�� 0���� ���Ѵ� ������ ��
        countdown = Mathf.Clamp(countdown, 0.0f, Mathf.Infinity);

        // ** countdown�� ���ڿ��� ��ȯ�Ͽ� �ؽ�Ʈ�� ǥ���Ѵ�
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    // ** Wave ���� �Լ�
    IEnumerator SpawnWave()
    {
        // ** ���带 ������Ų��
        PlayerStats.Rounds++;

        // ** ���� Wave ����� Wave�� �ҷ��´�
        WaveController wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        // ** Wave �ܰ迡 ���� ���� ���ݸ��� �Լ� ȣ���� �ݺ��Ѵ�
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1.0f / wave.rate);
        }
        // ** Wave �ܰ踦 ������Ų��
        waveIndex++;

        // ** Wave�� ������ �¸� ó�� �� ��Ȱ��ȭ�Ѵ�
        if (waveIndex == waves.Length)
        {
            gameManager.winLevel();
            this.enabled = false;
        }
    }

    // ** Enemy ���� �Լ�
    void SpawnEnemy(GameObject enemy)
    {
        // ** spawnPoint�� ��ġ�� ȸ������ ���� enemy�� ���� �����Ѵ�
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
