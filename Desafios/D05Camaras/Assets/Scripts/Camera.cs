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

    // Identifica si la cámara en primera persona está activa (true) o desactivada (false).
    [SerializeField] private bool activeFirstPerson;

    // Se fija la cámara inicial dependiendo del valor que se le asigne a activeFirstPerson.
    // Si está activo, se usará la cámara en primera persona, de lo contrario será en
    // tercera persona.
    void Start()
    {
        activeFirstPerson = ChangeCamera(activeFirstPerson, firstPerson, thirdPerson);
    }

    // Similar a la acción realizar en el método de Start(), solo que esta vez es el usuario
    // quien debe presionar una tecla para hacer el cambio entre cámaras. La tecla se define
    // desde el inspector de Unity.
    void Update()
    {
        if (Input.GetKeyDown(changeCamKey))
        {
            activeFirstPerson = ChangeCamera(activeFirstPerson, firstPerson, thirdPerson);
        }
    }

    // Método que permite alternar entre dos cámaras. El primer parámetro indica si la cámara
    // a utilizar es en primera persona (firstPersonCam), si es true se activa esta y se
    // desactiva la otra (thirdPersonCam), si es false ocurre lo contrario.
    // El método retorna el valor contrario al booleano ingresado.
    private bool ChangeCamera(bool isFirstPerson, CinemachineVirtualCamera firstPersonCam, CinemachineVirtualCamera thirdPersonCam)
    {
        firstPersonCam.gameObject.SetActive(isFirstPerson);
        thirdPersonCam.gameObject.SetActive(!isFirstPerson);
        return !isFirstPerson;
    }
}
