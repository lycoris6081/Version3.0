using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityControl : MonoBehaviour
{
    public Image A1;
    public Image A2;
    public Image A3;
    public Image A4;
    public Image A5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ability1()
    {
        PlayerHP.hp++;
        A1.color = new Color(255,255,255,255);

        Debug.Log("+1");
    }
    public void Ability2()
    {
       
    }
    public void Ability3()
    {
        print("3");

    }
    public void Ability4()
    {
        AttackBox.Damage++;
        A2.color = new Color(255, 255, 255, 255);
        Debug.Log("Damage+1");
    }
    public void Ability5()
    {
        print("5");
    }
    public void Ability6()
    {
        print("6");
    }
    public void Ability7()
    {
        print("7");
    }
}
