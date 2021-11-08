using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Hp = 10;

            Destroy(gameObject);
        }
    }
}