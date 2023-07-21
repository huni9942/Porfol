using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // ** target의 트랜스폼
    private Transform target;
    // ** target의 EnemyController 스크립트
    private EnemyController targetEnemy;
    
    [Header("General")]
    // ** turret의 사거리
    public float range = 15.0f;

    [Header("Use Bullets (default)")]
    // ** 총알 프리펩
    public GameObject bulletPrefab;
    // ** 공격 속도
    public float fireRate = 1.0f;
    // ** 공격 카운트다운
    private float fireCountdown = 0.0f;

    [Header("Use Laser")]
    // ** 레이저 사용 On/Off
    public bool useLaser = false;

    // ** 레이저 터렛의 시간당 대미지
    public int damageOverTimer = 30;
    // ** 레이저 터렛의 공격 시 슬로우 값
    public float slowAmount = 0.5f;

    // ** 레이저의 라인렌더러
    public LineRenderer lineRenderer;
    // ** 레이저 공격시 이펙트
    public ParticleSystem laserImpactEffect;
    // ** 레이저 공격 시 발광 효과
    public Light laserImpactLight;

    [Header("Unity Setup Fields")]

    // ** Enemy의 태그 지정
    public string enemyTag = "Enemy";

    // ** 회전할 부분의 트랜스폼
    public Transform partToRotate;
    // ** 회전 속도
    public float turnSpeed = 10.0f;


    // ** 총알 발사 위치
    public Transform firePoint;

    void Start()
    {
        // ** 'UpdateTarget' 메소드를 0.0초 후, 0.5초마다 실행한다
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
    }

    // ** target 변경 함수
    void UpdateTarget()
    {
        // ** enemyTag를 가진 게임 오브젝트를 찾아, enemies 배열에 저장한다
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        // ** Enemy와의 최단거리, Enemy가 존재하지 않을 때의 거리는 무한대
        float shortestDistance = Mathf.Infinity;
        // ** 가장 가까운 Enemy
        GameObject nearestEnemy = null;
        // ** enemies에 속한 enemy만큼 반복한다
        foreach (GameObject enemy in enemies)
        {
            // ** 현재 enemy와 Turret 사이의 거리 변수
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            // ** 현재 enemy와 Turret 사이의 거리가 기존 enemy와의 최단거리보다 짧을 때
            if (distanceToEnemy < shortestDistance)
            {
                // ** 최단거리 = 현재 enemy와 Turret 사이의 거리
                shortestDistance = distanceToEnemy;
                // ** 가장 가까운 Enemy = 현재 enemy
                nearestEnemy = enemy;
            }
        }

        // ** 가장 가까운 Enemy가 null이 아니며, 사거리 이내에 존재할 경우
        if (nearestEnemy != null && shortestDistance <= range)
        {
            // ** target = 가장 가까운 Enemy
            target = nearestEnemy.transform;
            // ** targetEnemy = 가장 가까운 Enemy의 EnemyController 스크립트 컴포넌트
            targetEnemy = nearestEnemy.GetComponent<EnemyController>();
        }
        else
        {
            // ** target이 존재하지 않는 상태
            target = null;
        }
    }

    void Update()
    {
        // ** target이 존재하지 않을 때
        if (target == null)
        {
            // ** 레이저를 사용 중일 때
            if (useLaser)
            {
                // ** 레이저의 라인 렌더러가 On 상태일 때
                if (lineRenderer.enabled)
                {
                    // ** 라인 렌더러를 Off한다
                    lineRenderer.enabled = false;
                    // ** 레이저 이펙트를 멈춘다
                    laserImpactEffect.Stop();
                    // ** 레이저 발광 효과를 Off한다
                    laserImpactLight.enabled = false;
                }

            }
            return;
        }
            

        LockOnTarget();

        // ** 레이저를 사용 중일 때
        if(useLaser)
        {
            Laser();
        }
        else
        {

            // ** 카운트다운이 0이하가 되었을 경우
            if (fireCountdown <= 0)
            {
                // ** 공격
                Shoot();
                // ** 공격 속도에 따른 카운트다운
                fireCountdown = 1.0f / fireRate;
            }

            // ** 카운트다운은 시간에 따라 감소한다
            fireCountdown -= Time.deltaTime;
        }

    }

    void LockOnTarget()
    {
        // ** Turret이 볼 방향
        Vector3 dir = target.position - transform.position;
        // ** Turret이 볼 방향으로 회전
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // ** 회전을 오일러각으로 변환, 선형보간하여 부드럽게 회전한다
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // ** Turret의 회전할 부분을 y축으로만 회전한다
        partToRotate.rotation = Quaternion.Euler(0.0f, rotation.y, 0.0f);
    }

    // ** 레이저 공격
    void Laser()
    {
        // ** target은 시간당 대미지를 받는다
        targetEnemy.TakeDamage(damageOverTimer * Time.deltaTime);
        // ** target은 감속량만큼 속도가 줄어든다
        targetEnemy.Slow(slowAmount);

        // ** 라인 렌더러가 Off 상태일 때
        if (!lineRenderer.enabled)
        {
            // ** 라인 렌더러를 On 시킨다
            lineRenderer.enabled = true;
            // ** 레이저 이펙트를 플레이한다
            laserImpactEffect.Play();
            // ** 레이저 발광 효과를 On시킨다
            laserImpactLight.enabled = true;
        }

        // ** 라인 렌더러를 firePoint의 위치에서 시작하여 target의 위치까지 잇는다
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        // ** 레이저 이펙트를 이동시킬 벡터
        Vector3 dir = firePoint.position - target.position;

        // ** 이펙트의 위치를 타겟의 위치에서 dir 벡터만큼 이동시킨다
        laserImpactEffect.transform.position = target.position + dir.normalized;

        // ** 이펙트의 각도를 dir벡터쪽으로 움직인다
        laserImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    // ** 공격
    void Shoot()
    {
        // ** 총알 프리펩을 발사 위치에 복사 생성한다
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // ** 복사 생성한 총알의 BulletController 컴포넌트
        BulletController bullet = bulletGO.GetComponent<BulletController>();

        // ** BulletController 컴포넌트가 존재할 때
        if (bullet != null)
            // ** target을 추적한다
            bullet.Seek(target);
    }

    // ** Turret의 사거리를 표시하는 Gizmos
    private void OnDrawGizmosSelected()
    {
        // ** Gizmos의 색깔을 붉은색으로 변경한다
        Gizmos.color = Color.red;
        // ** Gizmos를 Turret의 위치에 반지름이 사거리만큼인 WireSphere로 표시한다
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
