using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform target; // 箭头指向的目标，即箱子

    private void Update()
    {
        if (target != null)
        {
            // 使箭头指向目标位置
            transform.LookAt(target);
        }
    }
}
