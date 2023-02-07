using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameras : MonoBehaviour
{
    [SerializeField] private Camera walkingCamera;
    [SerializeField] private Camera aimCamera;
    public int aimKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(aimKey))
        {
            
        }
    }
}
