using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
private void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("FlashlightTrigger").GetComponent<FlashController>().Charges = 5;

            Destroy(gameObject);
        }
    }
}
