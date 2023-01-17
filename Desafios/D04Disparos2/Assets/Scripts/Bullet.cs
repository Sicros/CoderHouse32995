using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Velocidad a la que viaja la bala.
    public float speed;

    // Vector que almacena la dirección en la que viaja la bala.
    public Vector3 direction;

    // Daño que provoca la bala al personaje
    public float damage;

    // Tiempo de vida de la bala. Se mide en segundos.
    public float lifeTime;

    // Método en el que se mueve la bala frame por frame. También define un tiempo de vida
    // para que esta sea destruida.
    void Update()
    {
        transform.position += direction * (Time.deltaTime * speed);
        Destroy(gameObject, lifeTime);
    }
}
