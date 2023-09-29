using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{

    public static int hp = 1;
    public int max_hp = 0;
    public static bool Isdead;

    public GameObject gameOverUI; // 游戏结束UI
    // Start is called before the first frame update
    void Start()
    {
        max_hp = 1;
        hp = max_hp;
        gameOverUI.SetActive(false);
        Isdead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Playercontroller.isAttacking == false)
        {
            if (hp <= 0)
            {

                // 显示游戏结束UI
                gameOverUI.SetActive(true);

                Isdead = true;
            }
        }


        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Playercontroller.isAttacking == false)
            {
                hp -= 1;
            }
           
        }
        if (other.gameObject.tag == "Bullet")
        {
            if (Playercontroller.isAttacking == false)
            {
                hp -= 1;
                Destroy(other.gameObject);
            }
            
           
        }

    }
}
