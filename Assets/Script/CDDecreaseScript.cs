using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDDecreaseScript : MonoBehaviour
{    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().Hp = 12;
            GameObject.Find("FlashlightTrigger").GetComponent<FlashController>().CooldownMultiplier = 0.8f;

            Destroy(GameObject.Find("Anel"));
        }
    }

}
