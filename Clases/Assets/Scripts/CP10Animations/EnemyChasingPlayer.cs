using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingPlayer : MonoBehaviour
{
    // Referencia al transform del objeto que actua como el jugador.
    [SerializeField] private Transform player;

    // Velocidad a la que se mueve el enemigo
    [SerializeField] private float chasingSpeed;

    // Distancia que mantiene el enemigo del jugador
    [SerializeField] private float keepDistance;

    void Update()
    {
        ChasingPlayer();
    }

    // Este método permite al enemigo seguir al usuario a una velocidad definida desde el inspector.
    // Primero se obtiene el vector de la diferencia entre los vectores del jugador y el enemigo.
    // Luego se pregunta si la distancia que existe entre ellos es mayor a la definido por el usuario.
    // De cumplirse lo anterior, el enemigo comenzará a moverse hacia el jugador.
    // Por último, se agrega un último método que permite al enemigo siempre estar mirando al jugador.
    private void ChasingPlayer()
    {
        var vectorToPlayer = player.position - transform.position;
        if (vectorToPlayer.magnitude > keepDistance)
        {
            transform.position += vectorToPlayer.normalized * chasingSpeed * Time.deltaTime;
        }
        transform.LookAt(player);
    }
}
