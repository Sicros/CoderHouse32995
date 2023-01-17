using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    // Punto desde el que se dispara la bala. También es utilizado para modificar el tamaño global
    // de cada bala instanciada. Se le asigna la escala del objeto y para el resto de cálculos
    // se trabaja con la escala del pointOfShoot en lugar de la bala.
    [SerializeField] Transform pointOfShoot;

    // Referencia al prefab de bala asignado en el inspector
    [SerializeField] private Bullet bullet;

    // Tecla con la cual se duplica el tamaño de las balas. Se puede modificar desde el inspector.
    [SerializeField] private KeyCode duplicateSizeKey;

    // Indica si se desea considerar la escala de la bala como parte del tiempo de espera
    // para instanciar una nueva
    [SerializeField] private bool useScaleTimer;

    // Define un tiempo adicional al ya utilizado por la escala para esperar a instanciar una
    // nueva bala.
    [SerializeField] float additionalWaitingTime;

    // Variable definida para almacenar las nuevas balas que son instanciadas en el juego.
    private Bullet _bulletShot;

    // Corresponde al tiempo total de juego más el tiempo de espera cálculado.
    // Es utilizado para definir en que momento se destruye cada bala instanciada.
    private float _shootingTimeInner;
    
    // La clase de Bullet define el tamaño que tendrán las balas y, dado que se utilizará
    // el pointOfShoot para reescalar todos los elementos, se hereda la escala de la bala
    // a este transform. También se inicia el tiempo en el que se disparará la siguiente bala.
    private void Start()
    {
        pointOfShoot.transform.localScale = bullet.transform.localScale;
        _shootingTimeInner = getWaitingTime(bullet);
    }

    // En cada frame se pregunta si el tiempo de disparo está por debajo del tiempo de juego,
    // de ser así, se dispara una nueva. También se permite presionar una tecla para duplicar
    // la escala de pointOfShoot, lo que afecta también a todas las balas existentes.
    private void Update()
    {
        if (_shootingTimeInner <= Time.time)
        {
            Shoot();
        }

        if (Input.GetKeyDown(duplicateSizeKey)){
            pointOfShoot.transform.localScale *= 2;
        }
    }

    // Método de disparo. Instancia una bala, reescala su tamaño a (1,1,1), esto porque
    // es hija de pointOfShoot, por lo que se escala es acorde a la escala de su padre.
    // También se reinicia el contado para disparar la bala siguiente.
    private void Shoot()
    {
        _bulletShot = Instantiate(bullet, pointOfShoot);
        _bulletShot.transform.localScale = new Vector3 (1,1,1);
        _shootingTimeInner = getWaitingTime(_bulletShot) + Time.time;
    }

    // Método para calcular el tiempo de disparo entre cada bala. Se hace en relación
    // a la escala y velocidad de la bala (si useScalaTimer es verdadero) y le suma
    // el tiempo adicional (additionalWaitingTime).
    private float getWaitingTime(Bullet bulletShot)
    {
        if (useScaleTimer)
        {
            return (
                Mathf.Max(
                    pointOfShoot.transform.localScale.x,
                    pointOfShoot.transform.localScale.y,
                    pointOfShoot.transform.localScale.z
                ) / bulletShot.speed
            ) + additionalWaitingTime;
        }
        else
        {
            return additionalWaitingTime;
        }
    }
}
