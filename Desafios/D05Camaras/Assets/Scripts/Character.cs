using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Velocidad a la que se mueve el persona.
    [SerializeField] float speed;

    // Movimiento que realiza el personaje (moviendo en los ejes X,Z)
    [SerializeField] Vector3 movement;

    // Permite usar las teclas AD para moverse hacía los lados (eje X),
    // y WS para moverse hacía arriba y abajo (eje Z). Para realizar el
    // movimiento se llama al método Move(), con la nueva dirección como
    // parámetro.
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical);
        Move(movement);
    }

    // Método que actualiza la posición del personaje.
    void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
