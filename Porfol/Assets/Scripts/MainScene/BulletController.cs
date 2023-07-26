using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // ** target�� Ʈ������
    private Transform target;

    // ** �Ѿ��� �ӵ�
    public float speed = 70.0f;
    // ** �Ѿ��� �����
    public int damage = 50;
    // ** �Ѿ��� ���� �ݰ�
    public float explosionRadius = 0.0f;
    // ** �浹 ����Ʈ
    public GameObject impactEffect;
    
    // ** Ÿ�� Ž��
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        // ** target�� �������� ���� ���
        if(target == null)
        {
            // ** �Ѿ��� �ı��Ѵ�
            Destroy(gameObject);
            return;
        }

        // ** �Ѿ��� target�� ���� ���ư� ���� ����
        Vector3 dir = target.position - transform.position;
        // ** ���� �����ӿ��� �Ѿ��� ������ �Ÿ�
        float distanceThisFrame = speed * Time.deltaTime;

        // ** ���� �����ӿ��� �Ѿ��� ������ �Ÿ��� �߻�� ���� �Ѿ˰� target ������ �Ÿ��� ���ų� �� ���
        if (dir.magnitude <= distanceThisFrame)
        {
            // ** �Ѿ��� target�� �浹�Ѵ�
            HitTarget();
            return;
        }

        // ** �Ѿ��� ���� ��ǥ ������ (����ȭ�� ���� ���� * ���� �����ӿ��� �Ѿ��� ������ �Ÿ�)�� ���� �̵�
        // ** target�� �󸶳� ������ �ֵ�, �ӵ��� ���ϰ� ���� �ʱ� ����
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        // ** �Ѿ��� target�� �ٶ󺸵���
        transform.LookAt(target);
    }

    // ** �浹 ��
    void HitTarget()
    {
        // ** �浹 ȿ�� ���� ���� �� �����Ѵ�
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5.0f);

        // ** ���� �ݰ��� 0���� Ŭ ��
        if (explosionRadius > 0.0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        // ** �Ѿ��� �����Ѵ�
        Destroy(gameObject);
    }
    
    // ** ����
    void Explode()
    {
        // ** ���� �� ���� �ݰ� �� �����ϴ� ��� �ݸ������� �迭
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        // ** ���� �ݰ� ���� �ȿ� �����ϴ� �ݸ�������
        foreach (Collider collider in colliders)
        {
            // ** �ݸ����� �±װ� Enemy�� ��
            if(collider.tag == "Enemy")
            {
                // ** �ݸ����� ������� ���Ѵ�
                Damage(collider.transform);
            }
        }
    }

    // ** ����� ����
    void Damage (Transform enemy)
    {
        // ** Enemy�� ���� ������Ʈ EnemyController�� ������ ��
        EnemyController e = enemy.GetComponent<EnemyController>();
        // ** Enemy�� EnemyController�� ������ �ִٸ�
        if(e!=null)
        {
            // ** Enemy�� ������� �Դ´�
            e.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}