using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooting : MonoBehaviour
{
    private BulletSpeed BulletSpeed;

    public Transform firePoint; // 射击点
    public GameObject bulletPrefab; // 子弹预制体
    public float bulletForce = 10f; // 子弹发射力量
    public float fireRate = 2f; // 发射频率（每秒发射次数）
    public static bool ISshooting = false;

    private Transform player; // 玩家的Transform
    private float nextFireTime; // 下一次射击的时间

    public AudioClip fireSound;
    AudioSource AudioSource;

    void Start()
    {
        player = GameObject.Find("CATCAT").transform; // 根据玩家的名称查找玩家对象
        nextFireTime = Time.time; // 初始化下一次射击时间
        AudioSource = GetComponent<AudioSource>();
        BulletSpeed = GetComponent<BulletSpeed>();
    }

    void Update()
    {
        // 检查是否到达射击时间
        if (Time.time >= nextFireTime)
        {
            
            // 计算子弹朝向玩家的方向
            Vector3 direction = (player.position - firePoint.position).normalized;

            // 计算子弹朝向玩家的角度
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // 创建子弹，并将其旋转到正确的角度
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, angle));
            AudioSource.PlayOneShot(fireSound);


            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
 
            // 应用射击力量
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);

            // 更新下一次射击的时间
            nextFireTime = Time.time + 1f / fireRate;
            ISshooting = true;
        }
        
       

        if (AbilityControl.Slowdown)
        {
            // 通知 BulletManager 減慢子彈
            BulletSpeed.SlowDownBullets(5f, 0.5f); // 根據需要調整持續時間和減速因子
        }


    }
    private IEnumerator SlowDownBullet(GameObject bullet, float duration)
    {
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // 保存原始速度
        Vector2 originalVelocity = rb.velocity;

        // 減慢速度
        rb.velocity /= 2;

        // 等待持續時間
        yield return new WaitForSeconds(duration);

        // 恢復正常速度
        rb.velocity = originalVelocity;
    }

    private void SlowdownBulletsWithTag(string tag, float duration)
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject bullet in bullets)
        {
            // 直接將子彈 GameObject 傳遞給 SlowDownBullet 函數
            StartCoroutine(SlowDownBullet(bullet, duration));
        }
    }

}
