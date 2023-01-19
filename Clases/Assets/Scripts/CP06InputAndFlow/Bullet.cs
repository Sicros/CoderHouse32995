using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float lifeTime2;

    void Start()
    {
        lifeTime2 += Time.time;
    }

    void Update()
    {
        MoveForward();
        // Countdown();
        // Countdown2();
        Destroy(gameObject, lifeTime);
    }

    void MoveForward ()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    // Uso de deltaTime para destruir la bala
    private void Countdown()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            KillBullet();
        }
    }

    // Uso del tiempo de juego para la destrucción de la bala
    private void CountDown2()
    {
        if (lifeTime2 <= Time.time)
        {
            KillBullet();
        }
    }

    private void KillBullet()
    {
        Debug.Log("Bullet Killed");
        Destroy(gameObject);
    }
}
