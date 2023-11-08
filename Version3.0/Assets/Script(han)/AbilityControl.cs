﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityControl : MonoBehaviour
{

    private List<Image> selectedAbilityIcons = new List<Image>();
    public Image[] abilityIcons; // 在Unity中分配你的能力图标数组
    public Transform abilityIconsContainer; // 在Unity中分配能力图标容器的Transform

    public static bool Boom = false;

    public static bool Slowdown = false;

    public GameObject character;
    public static bool AttckLevelUP = false;

    private CardControl cardControl;

    private bool isIconVisible = false; // 是否 icon 已顯示


    private float iconDuration = 2f; // icon 顯示持續時間（秒）

    private Collider2D characterCollider;
    private bool isColliderDisabled = false;
    private float duration = 10f;
    public static int Ability6UsageCount = 0; // 追踪Ability6的使用次数
    //public Image A1;
    //public Image A2;
    //public Image A3;
    //public Image A4;
    //public Image A5;
    // Start is called before the first frame update

    void Start()
    {
        abilityIconsContainer.gameObject.SetActive(false);
        Boom = false;
        cardControl = FindObjectOfType<CardControl>();

        characterCollider = character.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliderDisabled)
        {
            duration -= Time.deltaTime;

            if (duration <= 0f)
            {
                characterCollider.enabled = true;
                isColliderDisabled = false;
                Shield.shieldopen = false;
                duration = 10f;
            }
        }
    }
    


    public void Ability1()
    {
        PlayerHP.hp++;

        // 创建一个新的Image对象
        Image newAbilityIcon = Instantiate(abilityIcons[0], abilityIconsContainer);

        // 设置图标的位置，这里假设图标大小是50x50
        Vector3 newPosition = new Vector3(selectedAbilityIcons.Count * 130, 0, 0); // 60是图标之间的间隔
        newAbilityIcon.rectTransform.localPosition = newPosition;

        // 将新的图标添加到已选择的能力列表中
        selectedAbilityIcons.Add(newAbilityIcon);
        // 启用AbilityIconsContainer对象
        abilityIconsContainer.gameObject.SetActive(true);

        Ability6UsageCount++;
        Debug.Log("+1");
    }
    public void Ability2()
    {
        if (!Boom)
        {
            Boom = true;

            // 尋找所有帶有 "Enemy" 標籤的遊戲物體
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // 對每個敵人減少1點血量
            foreach (GameObject enemy in enemies)
            {
                // 檢查是否帶有 Monstercontroller 腳本
                Monstercontroller monsterController = enemy.GetComponent<Monstercontroller>();
                Monster_Flower monsterController_F = enemy.GetComponent<Monster_Flower>();
                // 如果帶有 Monstercontroller 腳本，則對其調用 TakeDamage 方法
                if (monsterController != null)
                {
                    monsterController.TakeDamage(1);
                }
                if (monsterController_F != null)
                {
                    monsterController_F.TakeDamage(3);
                }

            }
            Ability6UsageCount++;
        }


    }
    

    public void Ability3()
    {

       Shield.shieldopen = !Shield.shieldopen;

        print("3");
        // 创建一个新的Image对象
        Image newAbilityIcon = Instantiate(abilityIcons[1], abilityIconsContainer);

        // 设置图标的位置，这里假设图标大小是50x50
        Vector3 newPosition = new Vector3(selectedAbilityIcons.Count * 130, 0, 0); // 60是图标之间的间隔
        newAbilityIcon.rectTransform.localPosition = newPosition;

        // 将新的图标添加到已选择的能力列表中
        selectedAbilityIcons.Add(newAbilityIcon);

        // 启用AbilityIconsContainer对象
        abilityIconsContainer.gameObject.SetActive(true);
        Ability6UsageCount++;
    }
    public void Ability4()
    {
        AttackBox.Damage++;
        AttckLevelUP = true;

        // 创建一个新的Image对象
        Image newAbilityIcon = Instantiate(abilityIcons[2], abilityIconsContainer);

        // 设置图标的位置，这里假设图标大小是50x50
        Vector3 newPosition = new Vector3(selectedAbilityIcons.Count * 130, 0, 0); // 60是图标之间的间隔
        newAbilityIcon.rectTransform.localPosition = newPosition;

        // 将新的图标添加到已选择的能力列表中
        selectedAbilityIcons.Add(newAbilityIcon);

        // 启用AbilityIconsContainer对象
        abilityIconsContainer.gameObject.SetActive(true);

        Debug.Log("Damage+1");
        Ability6UsageCount++;

        // 启动一个协程等待90秒
        StartCoroutine(EndAbilityAfterDelay(90f));
    }

    private IEnumerator EndAbilityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 在这里执行计时结束后的操作，例如禁用AbilityIconsContainer对象
        abilityIconsContainer.gameObject.SetActive(false);
        AttackBox.Damage--;
        AttckLevelUP = false;
        Debug.Log("Ability4 结束");
    }

    public void Ability5()
    {
        Shield.shieldopen = true;

        characterCollider.enabled = false;
        isColliderDisabled = true;
        print("5");
        // 创建一个新的Image对象
        Image newAbilityIcon = Instantiate(abilityIcons[3], abilityIconsContainer);

        // 设置图标的位置，这里假设图标大小是50x50
        Vector3 newPosition = new Vector3(selectedAbilityIcons.Count * 130, 0, 0); // 60是图标之间的间隔
        newAbilityIcon.rectTransform.localPosition = newPosition;

        // 将新的图标添加到已选择的能力列表中
        selectedAbilityIcons.Add(newAbilityIcon);

        // 启用AbilityIconsContainer对象
        abilityIconsContainer.gameObject.SetActive(true);
        Ability6UsageCount++;
    }



    public void Ability6()
    {
        print("6");

        if(!Slowdown)
        {
            Slowdown = true;
            Ability6UsageCount++;
        }

        // 创建一个新的Image对象
        Image newAbilityIcon = Instantiate(abilityIcons[4], abilityIconsContainer);

        // 设置图标的位置，这里假设图标大小是50x50
        Vector3 newPosition = new Vector3(selectedAbilityIcons.Count * 130, 0, 0); // 60是图标之间的间隔
        newAbilityIcon.rectTransform.localPosition = newPosition;

        // 将新的图标添加到已选择的能力列表中
        selectedAbilityIcons.Add(newAbilityIcon);

        // 启用AbilityIconsContainer对象
        abilityIconsContainer.gameObject.SetActive(true);


        StartCoroutine(IconDurationCoroutine());
    }

    private IEnumerator IconDurationCoroutine()
    {
        // 等待指定的持續時間
        yield return new WaitForSeconds(iconDuration);

        // 持續時間結束後，將 icon 隱藏
        Slowdown = false;

        // 找到 Ability6() 按鈕對應的 icon 並刪除它
        Image iconToRemove = selectedAbilityIcons.Find(icon => icon.sprite == abilityIcons[6].sprite);
        if (iconToRemove != null)
        {
            selectedAbilityIcons.Remove(iconToRemove);
            Destroy(iconToRemove.gameObject);
        }

        // 重新排列剩餘的 icon 的位置
        RearrangeIcons();

        // 如果沒有其他 icon，則關閉 AbilityIconsContainer 對象
        if (selectedAbilityIcons.Count == 0)
        {
            abilityIconsContainer.gameObject.SetActive(false);
        }

       
    }
    private void RearrangeIcons()
    {
        float iconSpacing = 130f; // 假設圖標之間的間隔是130
        for (int i = 0; i < selectedAbilityIcons.Count; i++)
        {
            Vector3 newPosition = new Vector3(i * iconSpacing, 0, 0);
            selectedAbilityIcons[i].rectTransform.localPosition = newPosition;
        }
    }


    public void Ability7()
    {
        cardControl.ReshuffleAbilities();
        Ability6UsageCount++;
    }
}
