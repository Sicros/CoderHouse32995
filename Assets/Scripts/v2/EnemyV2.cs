using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour
{

    [SerializeField] private string enemyName;
    [SerializeField] private PlayerV2 player;
    [SerializeField] private Vector3 movement;
    public float damage;
    public float heal;

    private void Awake()
    {
    }

    void Start()
    {
        //Imprimir mensajes en logs
        //Debug.Log(player.GetName());
        //Debug.LogWarning(player.GetName());
        //Debug.LogError(player.GetName());

        //Revisar que una condición se cumpla
        //bool playerIsMichael = enemyName == "Michael";
        //Debug.Log(playerIsMichael);
        //Debug.Assert(playerIsMichael);

        //Debug.Log("Esto si se imprime");
        //Debug.Break();
        //Debug.Log("Esto no se imprimirá");

        int valor1 = 1 + 3;
        valor1 /= 2;
        string basePepe = "Pepe";

    }

    void Update()
    {
        transform.position += movement;
    }
}
