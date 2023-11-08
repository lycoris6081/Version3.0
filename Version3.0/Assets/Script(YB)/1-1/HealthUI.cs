using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image image1; // 第一??片
    public Sprite sprite1; // ?片1的Sprite
    public Sprite sprite2; // ?片2的Sprite

    // 在Start方法中初始化
    void Start()
    {
        UpdateHealthUI(PlayerHP.hp);
    }

    // 在Update方法中??hp的?化并更新UI
    void Update()
    {
        UpdateHealthUI(PlayerHP.hp);
    }

    // 根据hp的值更新UI
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

