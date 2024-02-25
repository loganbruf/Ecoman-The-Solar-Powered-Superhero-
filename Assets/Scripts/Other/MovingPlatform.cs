using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    public Transform point1;
    public Transform point2;
    public float speed;
    private int _phase;
    

    // Update is called once per frame
    void Update()
    {
        if (_phase == 0)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, point1.position, step);
            if (Vector2.Distance(transform.position, point1.position) < 0.1f)
            {
                _phase = 1;
            }
        }
        else
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, point2.position, step);
            if (Vector2.Distance(transform.position, point2.position) < 0.1f)
            {
                _phase = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerActions>() == null) return;
        other.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerActions>() == null) return;
        other.transform.SetParent(null);
    }
}
