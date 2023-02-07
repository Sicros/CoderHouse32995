using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Se construye una lista de valores de acuerdo a las acciones que realiza el enemigo
// Chase: Perseguir al jugador y observar al jugador, sea donde sea que vaya.
// Watch: Solo observa al jugador, quedandose en el punto que quedó.
// DoNothing: Ni persigue ni observa al jugador.
public enum EnemyAction
{
    Chase,
    Watch,
    DoNothing
}

public class EnemyWatchingOrChasing : MonoBehaviour
{
    // Variable que referencia el transform del jugador. Configurable desde el inspector.
    [SerializeField] private Transform player;

    // Velocidad a la que persigue el enemigo al jugador. Configurable desde el inspector.
    [SerializeField] private float chasingSpeed;

    // Distancia que se mantiene alejado el enemigo del jugador. Configurable desde el inspector.
    [SerializeField] private float keepDistance;

    // Velocidad de rotación del enemigo. Configurable desde el inspector.
    [SerializeField] private float rotationSpeed;

    // Acción que realizará el enemigo de acuerdo a la lista definida más arriba.
    [SerializeField] private EnemyAction action;

    // Para decidir que acción tomar, se utiliza un "switch()", que recibe como parámetro
    // la acción definida desde el inspector (action). Cada caso, ejecuta un método llamado
    // ChangeEyesColor(), que permite cambiar el color de los ojos del enemigo de acuerdo
    // a la acción que realice (si persigue son rojos, si solo mira son amarillos y si se
    // queda quieto son verdes).
    void Update()
    {
        switch (action)
        {
            case EnemyAction.Chase:
                ChangeEyesColor(false, false, true);
                WatchingPlayer();
                ChasingPlayer();
                break;
            case EnemyAction.Watch:
                ChangeEyesColor(false, true, false);
                WatchingPlayer();
                break;
            case EnemyAction.DoNothing:
                ChangeEyesColor(true, false, false);
                break;
        }
    }

    // Método de persecución. Igual al que se encuentra en el script de EnemyChasingPlayer.cs,
    // con la diferencia que se elimina el método de "LookAt()", dado que ya existe otro método
    // en el script que permite esto.
    private void ChasingPlayer()
    {
        var vectorToPlayer = player.position - transform.position;
        if (vectorToPlayer.magnitude > keepDistance)
        {
            transform.position += vectorToPlayer.normalized * chasingSpeed * Time.deltaTime;
        }
    }

    // Método que permite al enemigo observar al jugador desde su posición. Es exactamente el
    // mismo método que se encuentra en el script de EnemyWatchingPlayer.cs.
    private void WatchingPlayer()
    {
        var vectorToPlayer = player.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(vectorToPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }

    // Método para activar los ojos de un color y desactivar el resto. Recibe tres booleanos, uno para
    // cada color, verde, amarillo y rojo, respectivamente.
    private void ChangeEyesColor(bool activateGreen, bool activateYellow, bool activateRed)
    {
        transform.Find("Cabeza").Find("OjosVerdes").gameObject.SetActive(activateGreen);
        transform.Find("Cabeza").Find("OjosAmarillos").gameObject.SetActive(activateYellow);
        transform.Find("Cabeza").Find("OjosRojos").gameObject.SetActive(activateRed);
    }
}
