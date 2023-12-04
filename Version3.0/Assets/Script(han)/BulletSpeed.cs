using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    private float originalBulletSpeed;
    private bool isSlowdownActive = false;

    // 對 MonsterShooting 腳本的引用
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

        // 減慢子彈速度
        monsterShooting.bulletForce *= slowdownFactor;

        // 等待指定的持續時間
        yield return new WaitForSeconds(duration);

        // 恢復原始子彈速度
        monsterShooting.bulletForce = originalBulletSpeed;

        isSlowdownActive = false;
    }
}
