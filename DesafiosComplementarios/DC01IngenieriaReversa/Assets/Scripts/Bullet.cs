using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float damage;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += direction * (Time.deltaTime * speed);        
    }
}
