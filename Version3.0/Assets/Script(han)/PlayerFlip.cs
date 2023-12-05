using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void PictureFlip()
    {
        // ����ƹ��b�۾�������m
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // �p��ƹ��۹�󨤦⪺��m
        float relativeX = mousePos.x - transform.position.x;

        // �p��ƹ��۹�󨤦⤤�I����m
        float relativeXCentered = relativeX / Mathf.Abs(relativeX);

        // �ھڬ۹��m�����Ϥ�
        if (relativeXCentered > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PictureFlip();
    }
}
