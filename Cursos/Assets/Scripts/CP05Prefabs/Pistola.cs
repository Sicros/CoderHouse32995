using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public GameObject bullet;
    public Transform pointOfShoot;

    void Start()
    {
        Instantiate(bullet, pointOfShoot);
    }

    void Update()
    {
    }
}
