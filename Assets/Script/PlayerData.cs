using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerData : MonoBehaviour
{
    
    public static PlayerData PData;
    public List <Vector2> LastCheckpoint = new List<Vector2>();

    public Vector2 Last;

    void Awake()
    {

        if (PData == null)
        {
            PData = this;
        }

        DontDestroyOnLoad(this);

        SetLastCheckpoint(new Vector2(6f, -4f));

    }

    public void SetLastCheckpoint(Vector2 CheckpointPosition)
    {
        LastCheckpoint.Add(CheckpointPosition);
        Last = LastCheckpoint.Last();
    }

}
