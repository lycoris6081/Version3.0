using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLessLife : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CATCAT")
        {
            PlayerHP.hp = 0;

        }
        
    }
}
