using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Velocidad a la que se mueve el personaje.
    [SerializeField] float walkingSpeed;

    // Velocidad a la que gira el personaje.
    [SerializeField] float rotateSpeed;

    // Movimiento que realiza el personaje (moviendo en los ejes X,Z)
    [SerializeField] Vector3 movement;

    // Tecla para mover hacia delante el personaje.
    [SerializeField] private KeyCode moveUp;

    // Tecla para mover hacia atrás el personaje.
    [SerializeField] private KeyCode moveDown;

    // Tecla para rotar hacia la izquierda al personaje.
    [SerializeField] private KeyCode rotateLeft;

    // Tecla para rotar hacia la derecha al personaje.
    [SerializeField] private KeyCode rotateRight;

    // Permite usar las teclas AD para rotar hacia los lados (eje X),
    // y WS para moverse hacia delante y atrás (eje Z).
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            transform.Translate(0, 0, walkingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveDown))
        {
            transform.Translate(0, 0, -walkingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(rotateLeft))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(rotateRight))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }
}
