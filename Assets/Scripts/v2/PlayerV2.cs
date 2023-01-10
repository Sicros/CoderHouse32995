using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    public int age;
    public float health;
    public float damage;
    public float defense;
    public double physicsFall;
    public bool useRayTracing;
    public Vector2 xz;
    public Vector3 myPosition;
    [SerializeField] private string characterName;

    void Awake()
    {
    }

    void Start()
    {
        SetName("UnNombre");
    }

    void Update()
    {
        
    }

    public string GetName ()
    {
        return characterName;
    }

    private void SetName (string newName)
    {
        characterName = newName;
    }

    private void SetName (string newName, int userNumber)
    {
        characterName = newName + userNumber;
    }
}
