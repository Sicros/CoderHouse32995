using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera1;
    [SerializeField] private CinemachineVirtualCamera camera2;

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.J))
        {
            TurnOnCamera(camera1, camera2);
        }

        if (Input.GetKey(KeyCode.K))
        {
            TurnOnCamera(camera2, camera1);
        }
    }

    private void TurnOnCamera(CinemachineVirtualCamera camToTurnOn, CinemachineVirtualCamera camToTurnOff)
    {
        // Opcion1: apagar y prender el gameObject
        camToTurnOn.gameObject.SetActive(true);
        camToTurnOff.gameObject.SetActive(false);

        // Opcion2: apagar y prender el componente
    }
}
