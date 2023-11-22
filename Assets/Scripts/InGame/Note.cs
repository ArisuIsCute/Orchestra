using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private float speed;

        
    
    private void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.smoothDeltaTime));
    }

    private void OnBecameInvisible()
    {
        if(transform.position.y <= -5.3f) Destroy(gameObject);
    }
}