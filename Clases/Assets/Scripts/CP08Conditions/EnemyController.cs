using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStatus
{
    Idle,
    Pursuit,
    RunAway
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyStatus currentStatus;
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private float pursuitDistance;
    [SerializeField] private Vector3 initialRotation;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        //transform.rotation = Quaternion.Euler(initialRotation);
        //LookAtPlayer();
    }

    private void Update()
    {
        LookAtPlayerWithTransform();
    }

    private void SetCurrentStatus()
    {
        switch (currentStatus)
        {
            case EnemyStatus.Idle:
                ExecuteIdle();
                break;
            case EnemyStatus.Pursuit:
                ExecutePursuit();
                break;
            case EnemyStatus.RunAway:
                ExecuteRunAway();
                break;
            default:
                Debug.LogError("Current state is invalid");
                break;
        }
    }

    private void ExecuteIdle()
    {

    }

    private void ExecutePursuit()
    {
        var vectorToPlayer = player.position - transform.position;
        transform.position += vectorToPlayer.normalized * (speed * Time.deltaTime);
    }

    private void ExecuteRunAway()
    {
        
    }

    private void LookAtPlayerWithTransform()
    {
        //Manera 1: Que mire directamente al personaje
        //transform.LookAt(player);

        //Manera 2: Igual al anterior, pero esta vez usando su transform.
        //transform.LookAt(player.transform);

        //Manera 3: Calcula el vector de la diferencia entre el que posee el enemigo y el jugador
        // Y asigna esta nueva rotación.
        // var vectorToPlayer = player.position - transform.position;
        // Quaternion newRotation = Quaternion.LookRotation(vectorToPlayer);
        // transform.rotation = newRotation;

        //Manera 4: Igual que el anterior, pero se define un tiempo en el que debe realizar el giro.
        var vectorToPlayer = player.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(vectorToPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }

}
