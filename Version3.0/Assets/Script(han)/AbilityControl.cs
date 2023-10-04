using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityControl : MonoBehaviour
{

    private List<Image> selectedAbilityIcons = new List<Image>();
    public Image[] abilityIcons; // 在Unity中分配你的能力图标数组
    public Transform abilityIconsContainer; // 在Unity中分配能力图标容器的Transform




    

    //public Image A1;
    //public Image A2;
    //public Image A3;
    //public Image A4;
    //public Image A5;
    // Start is called before the first frame update

    void Start()
    {
        abilityIconsContainer.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
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

        Debug.Log("+1");
    }
    public void Ability2()
    {
        
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

    }
    public void Ability4()
    {
        AttackBox.Damage++;
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
    }
    public void Ability5()
    {
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
    }
    public void Ability6()
    {
        print("6");
        // 创建一个新的Image对象
        Image newAbilityIcon = Instantiate(abilityIcons[4], abilityIconsContainer);

        // 设置图标的位置，这里假设图标大小是50x50
        Vector3 newPosition = new Vector3(selectedAbilityIcons.Count * 130, 0, 0); // 60是图标之间的间隔
        newAbilityIcon.rectTransform.localPosition = newPosition;

        // 将新的图标添加到已选择的能力列表中
        selectedAbilityIcons.Add(newAbilityIcon);

        // 启用AbilityIconsContainer对象
        abilityIconsContainer.gameObject.SetActive(true);
    }
    public void Ability7()
    {
        print("7");
        
    }
}
