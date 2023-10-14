using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideCanvasOnButtonClick : MonoBehaviour
{
    public Canvas canvasToHide; // �NCanvas����o���ܼƤ�
    public Button hideButton; // �N���s����o���ܼƤ�

    void Start()
    {
        // �K�[���s�I���ƥ��ť��
        hideButton.onClick.AddListener(HideCanvas);
    }

    void HideCanvas()
    {
        // �]�mCanvas�����i��
        canvasToHide.enabled = false;
    }
}

