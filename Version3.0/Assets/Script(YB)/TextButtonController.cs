using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextButtonController : MonoBehaviour
{
    public TextMeshProUGUI[] texts; // �s����C�� TextMeshProUGUI
    public Button[] buttons; // �s����C�ӫ��s

    void Start()
    {
        // �T�O texts �M buttons ���׬۵�
        if (texts.Length != buttons.Length)
        {
            Debug.LogError("texts �M buttons ���ƶq���Ӭ۵��I");
            return;
        }

        // ��l�Ƴ]�m�A�T�O�u�� Text1 ��ܡA��L Text ����
        for (int i = 1; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(false);
        }

        // �K�[���s�I���ƥ�
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // ���F�b���s�I���ƥ󤤨ϥΥ��T������
            buttons[i].onClick.AddListener(() => SwitchText(index));
        }
    }

    void SwitchText(int activeIndex)
    {
        // �M���Ҧ� Text�A�u�� activeIndex �� Text ��ܡA��L Text ����
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(i == activeIndex);
        }
    }
}
