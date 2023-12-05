using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheatCodeAbility : MonoBehaviour
{
    private PlayerHP playerHP;

    void Start()
    {
       
        // 在 Start 方法中获取对 PlayerHP 实例的引用
        playerHP = FindObjectOfType<PlayerHP>();
    }
    public void Ability5()
    {
        Shield.shieldopen = true;
        PlayerHP.invincibilityDuration = 1000f;
        // 触发无敌状态
        StartCoroutine(playerHP.InvincibilityCoroutine());

        
    }
    public void SkiptoBoss()
    {
        SceneManager.LoadScene(9);
    }

    public void SkiptoEndLess()
    {
        SceneManager.LoadScene(4);
    }
}
