using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;

    Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = GetComponent<Transform>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        float z = cameraTransform.position.z;
        cameraTransform.position = new Vector3(Target.position.x,Target.position.y,z);
        
    }
}
