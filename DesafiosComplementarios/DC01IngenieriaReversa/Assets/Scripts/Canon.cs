using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    // Definición de variables que identifica a cada tecla para disparar
    // Estas se definen desde el inspector
    [SerializeField] private KeyCode oneShootKeyCode;
    [SerializeField] private KeyCode twoShootKeyCode;
    [SerializeField] private KeyCode threeShootKeyCode;
    [SerializeField] private KeyCode fourShootKeyCode;

    // Clase de la bala. Corresponde al objeto instanciado
    public GameObject bullet;

    // Define la posición desde la cual la bala es disparada.
    // En este caso, se utiliza un objeto vacío del cañón llamado "PointOfShoot".
    public Transform pointOfShoot;

    // Por defecto, al disparar más de una bala, el tiempo de espera corresponde
    // a la velocidad y radio de la bala. Esta variable permite sumar
    // un valor adicional al tiempo si se desea que el intervalo sea mayor.
    public float additionalWaitingTime;

    // Variable que define una corutina, que espera un tiempo definido por el usuario
    // e instancia un nuevo objeto
    private IEnumerator coroutine;

    // Utilizado para almacenar el componente de la bala relacionado al script de
    // Bullet, el que es utilizado para obtener su velocidad (speed).
    private Bullet bulletData;

    // Se define un caso para cada tecla. Las teclas se definen en el inspector de Unity.
    private void Update()
    {
        if (Input.GetKeyDown(oneShootKeyCode))
        {
            MultipleShoots(1);
        }

        if (Input.GetKeyDown(twoShootKeyCode))
        {
            MultipleShoots(2);
        }

        if (Input.GetKeyDown(threeShootKeyCode))
        {
            MultipleShoots(3);
        }

        if (Input.GetKeyDown(fourShootKeyCode))
        {
            MultipleShoots(4);
        }
    }

    // Método que permite realizar múltiples disparos (instanciar más de una bala).
    // Recibe como parámetro el número de objetos que se desea instanciar. Por
    // defecto siempre instancia uno. Este parámetro corresponde a "numberOfShoots".
    private void MultipleShoots(int numberOfShoots = 1)
    {
        Debug.Log("Shoot number: 1");

        // Se almacenan los datos del objeto instanciado
        GameObject firstShoot = Instantiate(bullet, pointOfShoot);

        // Extracción del componente "Bullet" del objeto generado
        bulletData = firstShoot.GetComponent<Bullet>();

        // Cálculo del tiempo de espera entre cada bala. Por defecto se considera
        // el radio de la bala y su velocidad, para que se instancie una bala tras otra
        // sin toparse. A esto se le puede sumar un tiempo adicional (additionalWaitingTime).
        float waitingTime = (
            Mathf.Max(
                firstShoot.transform.localScale.x,
                firstShoot.transform.localScale.y,
                firstShoot.transform.localScale.z
            ) / bulletData.speed
        ) + additionalWaitingTime;

        // Se verifica que este tiempo no sea menor a 0. De ser así se le asigna 0.
        if (waitingTime < 0)
        {
            waitingTime = 0;
        }

        // En caso de que el número de balas sea 2 o más se entra en este ciclo.
        // Llama a la función "Wandering" que espera el tiempo calculado (WaitingTime)
        // y vuelve a instanciar una bala.
        for (int i = 2; i <= numberOfShoots; i++)
        {
            Debug.Log("Shoot number: " + i);
            coroutine = Wandering(waitingTime * (i - 1));
            StartCoroutine(coroutine);
        };
    }

    // Función que instancia una nueva bala, pero antes espera un tiempo
    // entregado por el usuario, correspondiente al parámetro "timer".
    private IEnumerator Wandering (float timer)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(bullet, pointOfShoot);
    }
}
