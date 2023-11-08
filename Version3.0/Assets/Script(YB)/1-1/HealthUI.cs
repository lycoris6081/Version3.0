using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image image1; // �Ĥ@??��
    public Sprite sprite1; // ?��1��Sprite
    public Sprite sprite2; // ?��2��Sprite

    // �bStart��k����l��
    void Start()
    {
        UpdateHealthUI(PlayerHP.hp);
    }

    // �bUpdate��k��??hp��?�Ʀ}��sUI
    void Update()
    {
        UpdateHealthUI(PlayerHP.hp);
    }

    // ���uhp���ȧ�sUI
    void UpdateHealthUI(int hp)
    {
        if (hp >= 3)
        {
            image1.sprite = sprite1;
        }
        else
        {
            image1.sprite = sprite2;
        }
    }
}

