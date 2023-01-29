using UnityEngine;

public class Portal : MonoBehaviour
{
    // Float que define cual será el nuevo tamaña del personaje. Este es una
    // escala proporcional de la original que ya tiene.
    [SerializeField] private float rescaleSize;

    // Tiempo de espera antes de que el portal se reactive, una vez se haya hecho
    // contacto con él.
    [SerializeField] private float timeToActivatePortal;

    // Nombre del objeto hijo que activará el reescalamiento del personaje.
    [SerializeField] private string childPortal;

    // Identifica si el personaje ya ha sido reescalado. Por defecto es falso,
    // debido a que se asume que el personaje tiene su tamaño original,
    // al momento de iniciar el juego.
    private bool _isRescaled = false;

    // Tiempo que define el momento en que el portal se volverá a reactivar.
    // No confundir con timeToActivatePortal, debido a que este último corresponde
    // a los segundos entre cada espera, mientras que _currentTime es la hora exacta
    // en la que ocurre este evento.
    private float _currentTime;

    // En cada frame, independiente de la colisión que haya entre el personaje y el portal
    // se pregunta si el portal está desactivado y si ya se ha cumplido el tiempo de espera,
    // de ser así, se reactiva.
    private void Update()
    {
        if (!transform.Find(childPortal).gameObject.activeSelf && _currentTime <= Time.time)
        {
            transform.Find(childPortal).gameObject.SetActive(true);
        }
    }

    // Método que se activa al primer contacto entre el personaje y el portal,
    // el cual se encarga de reescalarlo a su nuevo tamaño.
    private void OnTriggerEnter(Collider other)
    {
        // Solo nos importa el contacto entre el personaje y el portal,
        // por lo que en esta condición si verifica que esto se cumpla.
        if (other.TryGetComponent<HarryController>(out var harry))
        {
            // Si el personaje ya ha sido reescalado, se devuelve a su tamaño original.
            if (_isRescaled)
            {
                harry.transform.localScale /= rescaleSize;
            }
            // Sino, se reescala de acuerdo al valor ingresado desde el inspector.
            else
            {
                harry.transform.localScale *= rescaleSize;
            }
            
            // Se desactiva el objeto hijo que contiene el trigger del reescalamiento.
            transform.Find(childPortal).gameObject.SetActive(false);

            // Hora en que el portal se volverá a reactiva (hora actual más el tiempo de espera).
            _currentTime = Time.time + timeToActivatePortal;

            // Se invierte el booleano que verifica si el personaje fue reescalado.
            _isRescaled = !_isRescaled;
        }
    }
}
