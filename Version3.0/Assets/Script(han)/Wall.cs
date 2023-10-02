using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
     Collider2D wallCollider;

    private void Start()
    {
        // 获取墙壁对象的Collider2D组件
        wallCollider = GetComponent<Collider2D>();

    }

    // 在需要时可以调用此方法来开启或关闭Collider2D的OnTrigger选项
    public void SetColliderTrigger(bool isTrigger)
    {
        if (wallCollider != null)
        {
            wallCollider.isTrigger = isTrigger;
        }
    }
}
