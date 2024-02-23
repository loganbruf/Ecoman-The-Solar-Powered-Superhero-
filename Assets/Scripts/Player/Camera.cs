using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform focusObject;
    public float camOffsetX;
    public float camOffsetY;
    public float minY;
    public float minX;

    // Update is called once per frame
    void Update()
    {
        var objPos = focusObject.position;
        transform.position = new Vector3(Mathf.Max(objPos.x + camOffsetX, minX), Mathf.Max(objPos.y  + camOffsetY, minY), transform.position.z);
    }
}
