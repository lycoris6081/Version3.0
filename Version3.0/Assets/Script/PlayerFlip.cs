using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float lastMouseX;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastMouseX = Input.mousePosition.x;
    }

    void PictureFlip()
    {
        // ����ƹ���e��X��m
        float mouseX = Input.mousePosition.x;

        // �p��ƹ����ʪ���V
        float direction = Mathf.Sign(mouseX - lastMouseX);

        // �ھڤ�V�����Ϥ�
        if (direction > 0)
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
