using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // ** target�� Ʈ������
    private Transform target;
    // ** target�� EnemyController ��ũ��Ʈ
    private EnemyController targetEnemy;
    
    [Header("General")]
    // ** turret�� ��Ÿ�
    public float range = 15.0f;

    [Header("Use Bullets (default)")]
    // ** �Ѿ� ������
    public GameObject bulletPrefab;
    // ** ���� �ӵ�
    public float fireRate = 1.0f;
    // ** ���� ī��Ʈ�ٿ�
    private float fireCountdown = 0.0f;

    [Header("Use Laser")]
    // ** ������ ��� On/Off
    public bool useLaser = false;

    // ** ������ �ͷ��� �ð��� �����
    public int damageOverTimer = 30;
    // ** ������ �ͷ��� ���� �� ���ο� ��
    public float slowAmount = 0.5f;

    // ** �������� ���η�����
    public LineRenderer lineRenderer;
    // ** ������ ���ݽ� ����Ʈ
    public ParticleSystem laserImpactEffect;
    // ** ������ ���� �� �߱� ȿ��
    public Light laserImpactLight;

    [Header("Unity Setup Fields")]

    // ** Enemy�� �±� ����
    public string enemyTag = "Enemy";

    // ** ȸ���� �κ��� Ʈ������
    public Transform partToRotate;
    // ** ȸ�� �ӵ�
    public float turnSpeed = 10.0f;


    // ** �Ѿ� �߻� ��ġ
    public Transform firePoint;

    void Start()
    {
        // ** 'UpdateTarget' �޼ҵ带 0.0�� ��, 0.5�ʸ��� �����Ѵ�
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
    }

    // ** target ���� �Լ�
    void UpdateTarget()
    {
        // ** enemyTag�� ���� ���� ������Ʈ�� ã��, enemies �迭�� �����Ѵ�
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        // ** Enemy���� �ִܰŸ�, Enemy�� �������� ���� ���� �Ÿ��� ���Ѵ�
        float shortestDistance = Mathf.Infinity;
        // ** ���� ����� Enemy
        GameObject nearestEnemy = null;
        // ** enemies�� ���� enemy��ŭ �ݺ��Ѵ�
        foreach (GameObject enemy in enemies)
        {
            // ** ���� enemy�� Turret ������ �Ÿ� ����
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            // ** ���� enemy�� Turret ������ �Ÿ��� ���� enemy���� �ִܰŸ����� ª�� ��
            if (distanceToEnemy < shortestDistance)
            {
                // ** �ִܰŸ� = ���� enemy�� Turret ������ �Ÿ�
                shortestDistance = distanceToEnemy;
                // ** ���� ����� Enemy = ���� enemy
                nearestEnemy = enemy;
            }
        }

        // ** ���� ����� Enemy�� null�� �ƴϸ�, ��Ÿ� �̳��� ������ ���
        if (nearestEnemy != null && shortestDistance <= range)
        {
            // ** target = ���� ����� Enemy
            target = nearestEnemy.transform;
            // ** targetEnemy = ���� ����� Enemy�� EnemyController ��ũ��Ʈ ������Ʈ
            targetEnemy = nearestEnemy.GetComponent<EnemyController>();
        }
        else
        {
            // ** target�� �������� �ʴ� ����
            target = null;
        }
    }

    void Update()
    {
        // ** target�� �������� ���� ��
        if (target == null)
        {
            // ** �������� ��� ���� ��
            if (useLaser)
            {
                // ** �������� ���� �������� On ������ ��
                if (lineRenderer.enabled)
                {
                    // ** ���� �������� Off�Ѵ�
                    lineRenderer.enabled = false;
                    // ** ������ ����Ʈ�� �����
                    laserImpactEffect.Stop();
                    // ** ������ �߱� ȿ���� Off�Ѵ�
                    laserImpactLight.enabled = false;
                }

            }
            return;
        }
            

        LockOnTarget();

        // ** �������� ��� ���� ��
        if(useLaser)
        {
            Laser();
        }
        else
        {

            // ** ī��Ʈ�ٿ��� 0���ϰ� �Ǿ��� ���
            if (fireCountdown <= 0)
            {
                // ** ����
                Shoot();
                // ** ���� �ӵ��� ���� ī��Ʈ�ٿ�
                fireCountdown = 1.0f / fireRate;
            }

            // ** ī��Ʈ�ٿ��� �ð��� ���� �����Ѵ�
            fireCountdown -= Time.deltaTime;
        }

    }

    void LockOnTarget()
    {
        // ** Turret�� �� ����
        Vector3 dir = target.position - transform.position;
        // ** Turret�� �� �������� ȸ��
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // ** ȸ���� ���Ϸ������� ��ȯ, ���������Ͽ� �ε巴�� ȸ���Ѵ�
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // ** Turret�� ȸ���� �κ��� y�����θ� ȸ���Ѵ�
        partToRotate.rotation = Quaternion.Euler(0.0f, rotation.y, 0.0f);
    }

    // ** ������ ����
    void Laser()
    {
        // ** target�� �ð��� ������� �޴´�
        targetEnemy.TakeDamage(damageOverTimer * Time.deltaTime);
        // ** target�� ���ӷ���ŭ �ӵ��� �پ���
        targetEnemy.Slow(slowAmount);

        // ** ���� �������� Off ������ ��
        if (!lineRenderer.enabled)
        {
            // ** ���� �������� On ��Ų��
            lineRenderer.enabled = true;
            // ** ������ ����Ʈ�� �÷����Ѵ�
            laserImpactEffect.Play();
            // ** ������ �߱� ȿ���� On��Ų��
            laserImpactLight.enabled = true;
        }

        // ** ���� �������� firePoint�� ��ġ���� �����Ͽ� target�� ��ġ���� �մ´�
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        // ** ������ ����Ʈ�� �̵���ų ����
        Vector3 dir = firePoint.position - target.position;

        // ** ����Ʈ�� ��ġ�� Ÿ���� ��ġ���� dir ���͸�ŭ �̵���Ų��
        laserImpactEffect.transform.position = target.position + dir.normalized;

        // ** ����Ʈ�� ������ dir���������� �����δ�
        laserImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    // ** ����
    void Shoot()
    {
        // ** �Ѿ� �������� �߻� ��ġ�� ���� �����Ѵ�
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // ** ���� ������ �Ѿ��� BulletController ������Ʈ
        BulletController bullet = bulletGO.GetComponent<BulletController>();

        // ** BulletController ������Ʈ�� ������ ��
        if (bullet != null)
            // ** target�� �����Ѵ�
            bullet.Seek(target);
    }

    // ** Turret�� ��Ÿ��� ǥ���ϴ� Gizmos
    private void OnDrawGizmosSelected()
    {
        // ** Gizmos�� ������ ���������� �����Ѵ�
        Gizmos.color = Color.red;
        // ** Gizmos�� Turret�� ��ġ�� �������� ��Ÿ���ŭ�� WireSphere�� ǥ���Ѵ�
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
