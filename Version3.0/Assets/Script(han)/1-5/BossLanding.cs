using System.Collections;
using UnityEngine;

public class BossLanding : MonoBehaviour
{
    public GameObject LandingCircle;
    public Vector3 landingAreaCenter;  // 降落区域中心
    public Vector3 landingAreaSize;    // 降落区域大小

    public IEnumerator MoveUpAndDown(float duration)
    {
        // 上升
        Vector3 aboveScreenPosition = new Vector3(transform.position.x, transform.position.y + 50f, transform.position.z);
        yield return StartCoroutine(MoveToPosition(aboveScreenPosition, 1f));

        // 等待一段时间
        yield return new WaitForSeconds(3f);

        // 生成 LandingCircle
        Vector3 landingCirclePosition = GetRandomLandingPoint();
        StartCoroutine(SpawnLandingCircle(landingCirclePosition));

        // 等待一段时间
        yield return new WaitForSeconds(3f);

        // 下降
        yield return StartCoroutine(MoveToPosition(landingCirclePosition, duration));
    }

    Vector3 GetRandomLandingPoint()
    {
        // 在降落区域内生成随机点
        Vector3 randomLandingPoint = new Vector3(
            Random.Range(landingAreaCenter.x - landingAreaSize.x / 2, landingAreaCenter.x + landingAreaSize.x / 2),
            Random.Range(landingAreaCenter.y - landingAreaSize.y / 2, landingAreaCenter.y + landingAreaSize.y / 2),
            Random.Range(landingAreaCenter.z - landingAreaSize.z / 2, landingAreaCenter.z + landingAreaSize.z / 2)
        );

        return randomLandingPoint;
    }

    IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            // 使用SmoothStep函數，使移動更平滑
            t = Mathf.SmoothStep(0f, 1f, t);
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

    IEnumerator SpawnLandingCircle(Vector3 position)
    {
        // 实例化 LandingCircle
        GameObject landingIndicator = Instantiate(LandingCircle, position, Quaternion.identity);

        // 等待一段时间
        yield return new WaitForSeconds(3f);

        // 隐身 LandingCircle
        Destroy(landingIndicator);
    }
}