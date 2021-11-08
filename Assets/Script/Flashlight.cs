using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Transform PlayerFlash;

    Transform LightTransform;
    
    private void Awake()
    {
        LightTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        float z = LightTransform.position.z;
        LightTransform.position = new Vector3(PlayerFlash.position.x,PlayerFlash.position.y,z);
    }
}
