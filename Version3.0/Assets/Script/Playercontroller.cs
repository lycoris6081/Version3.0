using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    private SpriteRenderer spriteRenderer;
    private float lastMouseX;
    Animator animator;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastMouseX = Input.mousePosition.x;
        animator = GetComponent<Animator>();
    }

    void Update()
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

        //����
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetFloat("Attack1",1);
        }
        else
        {
            animator.SetFloat("Attack1",0);
        }

        // ����ƹ���e���̹���m
        Vector3 mousePosition = Input.mousePosition;

        // �N�ƹ���m�q�̹������ഫ���@�ɧ���
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));

        // �p�⪫���ƹ���m����V�V�q
        Vector3 moveDirection = worldMousePosition - transform.position;

        // ���Z�b�A�Ϫ���O���b2D�����W
        moveDirection.z = 0;

        // ���W�Ƥ�V�V�q�A�H�T�O�t�פ@�P
        moveDirection.Normalize();

        // �]�m���骺��m
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

       
    }

    
}

