using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoom : MonoBehaviour
{
    // 抖动的强度
    public float shakeIntensity = 0.1f;

    // 抖动的持续时间
    public float shakeDuration = 0.5f;
    // 爆炸前的抖动
    public void ShakeBeforeExplosion()
    {
        StartCoroutine(ShakeCoroutine());
    }

    // 协程用于实现抖动效果
    private IEnumerator ShakeCoroutine()
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            // 生成一个随机偏移
            float offsetX = Random.Range(-1f, 1f) * shakeIntensity;
            

            // 应用偏移
            transform.Translate(new Vector3(offsetX, 0f, 0f));

            elapsed += Time.deltaTime;

            yield return null;
        }

        // 恢复原始位置
        transform.position = originalPosition;
    }
}
