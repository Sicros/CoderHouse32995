using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{
    // Variable que identifica a la cámara en primera persona.
    [SerializeField] private CinemachineVirtualCamera firstPerson;

    // Variable que identifica a la cámara en tercera persona.
    [SerializeField] private CinemachineVirtualCamera thirdPerson;

    // Botón con que el se alterna entre ambas cámaras.
    [SerializeField] private KeyCode changeCamKey;

    // Identifica si la cámara en tercera persona está activada (true) o desactivada (false).
    [SerializeField] private bool activeThirdPerson;

    // Se fija la cámara inicial dependiendo del valor que se le asigne a activeThirdPerson.
    // Si está activo, se usará la cámara en tercera persona, de lo contrario será en
    // primera persona.
    void Start()
    {
        activeThirdPerson = ChangeCamera(activeThirdPerson, firstPerson, thirdPerson);
    }

    // Similar a la acción realizada en el método de Start(), solo que esta vez es el usuario
    // quien debe presionar una tecla para hacer el cambio entre cámaras. La tecla se define
    // desde el inspector de Unity.
    void Update()
    {
        if (Input.GetKeyDown(changeCamKey))
        {
            activeThirdPerson = ChangeCamera(activeThirdPerson, firstPerson, thirdPerson);
        }
    }

    // Método que permite alternar entre dos cámaras. El primer parámetro indica si la cámara
    // a utilizar es en tercera persona (thirdPersonCam), si es true se activa esta y se
    // desactiva la otra (firstPersonCam), si es false ocurre lo contrario.
    // El método retorna el valor contrario al booleano ingresado.
    private bool ChangeCamera(bool isThirdPerson, CinemachineVirtualCamera firstPersonCam, CinemachineVirtualCamera thirdPersonCam)
    {
        thirdPersonCam.gameObject.SetActive(isThirdPerson);
        firstPersonCam.gameObject.SetActive(!isThirdPerson);
        return !isThirdPerson;
    }
}
