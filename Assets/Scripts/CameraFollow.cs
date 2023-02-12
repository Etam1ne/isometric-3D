using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;

    void LateUpdate()
    {
        transform.position = targetObject.transform.position;
    }
}
