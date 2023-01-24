using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWatchingPlayer : MonoBehaviour
{
    // Variable que referencia al transform del jugador.
    [SerializeField] private Transform player;

    // Velocidad a la que gira el enemigo para observar al jugador.
    [SerializeField] private float rotationSpeed;

    void Update()
    {
        WatchingPlayer();
    }

    // Este método permite que el enemigo rote sobre su propio centro para seguir al jugador,
    // sea donde sea que este se mueva. Se agrega un pequeño ajuste para que el enemigo
    // se gire con un pequeño delay.
    // Primero se obtiene el vector a partir de estos dos objetos (enemigo y jugador).
    // Luego se calcula el nuevo punto al que debería mirar el enemigo, que corresponde a la
    // posición del jugador.
    // Por último se aplica esta rotación al enemigo, que se realiza suavemente, de acuerdo a
    // la velocidad de giro del enemigo y el tiempo entre cada cuadro.
    private void WatchingPlayer()
    {
        var vectorToPlayer = player.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(vectorToPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }
}
