using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 dir = Vector3.up;

        transform.position += dir * speed * Time.deltaTime;
    }
}
