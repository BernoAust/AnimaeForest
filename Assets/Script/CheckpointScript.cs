using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    private GameManager GM;

    void Start()
    {
        GM = GameManager.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            GM.SetLastCheckpoint(transform.position);
        }

    }


}
