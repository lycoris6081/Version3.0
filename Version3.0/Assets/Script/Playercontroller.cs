using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f;



    void Update()
    {
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

