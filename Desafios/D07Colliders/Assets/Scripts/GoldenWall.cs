using UnityEngine;

public class GoldenWall : MonoBehaviour
{
    // Tiempo que el personaje debe estar colisionando con el muro 
    // antes de cambiar su posición y rotación (solo en eje y).
    [SerializeField] private float timeToChangePosition;

    // Vector3 que indica cual es el punto central del rango en el que
    // se moverá el muro.
    [SerializeField] private Vector3 centerMovementWall;

    // Valor que representa el radio de movimiento del muro.
    [SerializeField] private float radiusMovementeWall;

    // Variable que almacena el tiempo en que el muro se moverá a una nueva posición.
    private float _currentTime;

    // Método de colisión que se activa al primer contacto con el muro.
    // Solo se considera aquella colisión con el personaje. Se define en que momento
    // cambiará de posición el muro (tiempo transcurrido más tiempo de espera
    // antes de moverse).
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent<HarryController>(out var harry))
        {
            _currentTime = Time.time + timeToChangePosition;
        }
    }

    // Método de colisión que se activa en cada frame, tras el primer contacto con el muro.
    // Si el objeto con el que colisiona es el personaje y ya se ha cumplido el tiempo de
    // espera definido desde el inspector, el muro cambiará a una posición y rotación nueva.
    private void OnCollisionStay(Collision other)
    {        
        if (other.collider.TryGetComponent<HarryController>(out var harry) && _currentTime <= Time.time)
        {
            // La nueva posición se cálcula de forma aleatoria para los ejes (X, Z) a partir del
            // punto central (centerMovementWall) y el radio del rango (radiusMovementWall), ambos
            // definidos desde el inspector.
            transform.position = centerMovementWall + new Vector3(
                Random.Range(-radiusMovementeWall, radiusMovementeWall),
                0,
                Random.Range(-radiusMovementeWall, radiusMovementeWall)
            );

            // La rotación solo cambia con respecto al eje Y, el cual se define en Euler Angles
            // que va de 0 a 360. Los otros ejes se mantienen de acuerdo a su valor original.
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                Random.Range(0, 360),
                transform.rotation.eulerAngles.z
            );

            // Se redefine el próximo momento de cambio. Esto se hace para evitar problemas
            // Si la nueva posición y rotación del objeto coinciden nuevamente con la
            // posición en la que se encuentra el personaje.
            _currentTime = Time.time + timeToChangePosition;
        }
    }
}
