using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    

    public List <Vector3> LastCheckpoint = new List<Vector3>();

    void Awake()
    {

        DontDestroyOnLoad(this);

    }



}
