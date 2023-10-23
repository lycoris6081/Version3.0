using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopMenager : MonoBehaviour
{
    public int SOUL;
    public TMP_Text soulTXT;

    private void Start()
    {
        soulTXT.text = "Souls" + SOUL.ToString();
    }


    public void addSoul()
    {
        SOUL++;
        soulTXT.text = "Soul:" + SOUL.ToString();
     
    }
}
