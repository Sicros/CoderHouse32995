using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera firstPerson;
    [SerializeField] private CinemachineVirtualCamera thirdPerson;
    [SerializeField] private KeyCode changeCamKey;
    [SerializeField] private bool activeFirstPerson;

    void Start()
    {
        activeFirstPerson = ChangeCamera(activeFirstPerson, firstPerson, thirdPerson);
    }

    void Update()
    {
        if (Input.GetKeyDown(changeCamKey))
        {
            activeFirstPerson = ChangeCamera(activeFirstPerson, firstPerson, thirdPerson);
        }
    }

    private bool ChangeCamera(bool isFirstPerson, CinemachineVirtualCamera firstPersonCam, CinemachineVirtualCamera thirdPersonCam)
    {
        firstPersonCam.gameObject.SetActive(isFirstPerson);
        thirdPersonCam.gameObject.SetActive(!isFirstPerson);
        return !isFirstPerson;
    }
}
