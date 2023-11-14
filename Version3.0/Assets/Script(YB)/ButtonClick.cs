using UnityEngine;
using TMPro;

public class ButtonClick : MonoBehaviour
{
    public TextMeshProUGUI textToHide;

    // �bUnity Inspector���N���s�������o���ܼƤ�
    public UnityEngine.UI.Button yourButton;

    private void Start()
    {
        // �T�O���s����w�]�m�A�M��q�\���U�ƥ�
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(HideText);
        }
        else
        {
            Debug.LogError("�ЦbInspector�����w���s����!");
        }
    }

    void HideText()
    {
        // �ˬdTextMeshPro����O�_�s�b
        if (textToHide != null)
        {
            // ����TextMeshPro����
            textToHide.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("�ЦbInspector�����wTextMeshPro����!");
        }
    }
}

