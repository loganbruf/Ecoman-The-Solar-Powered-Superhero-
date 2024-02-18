using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform focusObject;
    public float camOffsetX;
    public float camOffsetY;

    // Update is called once per frame
    void Update()
    {
        var objPos = focusObject.position;
        transform.position = new Vector3(objPos.x + camOffsetX, objPos.y + camOffsetY, transform.position.z);
    }
}
