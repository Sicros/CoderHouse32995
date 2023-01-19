using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 movement;

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical);
        Move(movement);
    }

    void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
