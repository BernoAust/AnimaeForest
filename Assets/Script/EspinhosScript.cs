using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhosScript : MonoBehaviour
{
    
    public PlayerController PlayerScript;
    void Update()
    {
        PlayerScript = PlayerController.PController;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            PlayerScript.PlayerDeath();
        }

    }

}
