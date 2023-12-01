using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityEffect : MonoBehaviour
{
    public GameObject HealthEffect;
    public GameObject ShieldEffect;
    public GameObject BoomEffect;
    public GameObject AttackLvUpEffect;
    public GameObject SlowDownEffect;


    public void HealthStart()
    {
        if (HealthEffect != null)
        {
            Instantiate(HealthEffect, transform.position, Quaternion.identity);
        }
    }

    public void ShieldStart()
    {
        if (ShieldEffect != null)
        {
            Instantiate(ShieldEffect, transform.position, Quaternion.identity);
        }
    }
    public void BoomStart()
    {
        if (BoomEffect != null)
        {
            Instantiate(BoomEffect, transform.position, Quaternion.identity);
        }
    }
    public void AttackLvUpStart()
    {
        if (AttackLvUpEffect != null)
        {
            // 实例化效果
            GameObject effectInstance = Instantiate(AttackLvUpEffect, transform.position, Quaternion.identity);

            // 将效果的父级设置为玩家
            if (transform.parent != null)
            {
                effectInstance.transform.parent = transform.parent;
            }
        }
    }
    public void SlowDownStart()
    {
        if (SlowDownEffect != null)
        {
            Instantiate(SlowDownEffect, transform.position, Quaternion.identity);
        }
    }
}
