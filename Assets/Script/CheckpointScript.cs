using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    public PlayerData PD;

    void Start()
    {
        PD = PlayerData.PData;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            PD.SetLastCheckpoint(transform.position);
        }

    }

    
}
