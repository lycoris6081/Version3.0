using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    private float originalBulletSpeed;
    private bool isSlowdownActive = false;

    // �� MonsterShooting �}�����ޥ�
    private MonsterShooting monsterShooting;

    private void Start()
    {
        monsterShooting = GetComponent<MonsterShooting>();
        originalBulletSpeed = monsterShooting.bulletForce;
    }

    public void SlowDownBullets(float duration, float slowdownFactor)
    {
        if (!isSlowdownActive)
        {
            StartCoroutine(SlowDownCoroutine(duration, slowdownFactor));
        }
    }

    private IEnumerator SlowDownCoroutine(float duration, float slowdownFactor)
    {
        isSlowdownActive = true;

        // ��C�l�u�t��
        monsterShooting.bulletForce *= slowdownFactor;

        // ���ݫ��w������ɶ�
        yield return new WaitForSeconds(duration);

        // ��_��l�l�u�t��
        monsterShooting.bulletForce = originalBulletSpeed;

        isSlowdownActive = false;
    }
}
