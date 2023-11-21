using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;

    // �bStart��k���i���l��
    void Start()
    {
        // ��l�]�m�Acanvas1�i���Acanvas2���i��
        canvas1.enabled = true;
        canvas2.enabled = false;
    }

    // ��s�C�@�V�����A
    void Update()
    {
        // �ˬd�O�_���UEscape��A�p�G�O�A�h����Canvas���i����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanvasVisibility();
        }
    }

    // ����Canvas���i����
    void ToggleCanvasVisibility()
    {
        // ����canvas1�Mcanvas2���i����
        canvas1.enabled = !canvas1.enabled;
        canvas2.enabled = !canvas2.enabled;
    }
}

