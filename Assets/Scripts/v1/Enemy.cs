using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private string enemyName;
    [SerializeField] private Player player;
    [SerializeField] private Vector3 movement;
    public float damage;
    public float heal;

    // Awake is called before Start()
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        damage = 2;
        //La defensa del script01 menos el ataque de script02 y eso se lo resto a la vida de script01
        
        player.health -= damage - player.defense; //player.health = player.health - (damage - player.defense);

        //Curación a personaje

        player.health += heal; //player.health = player.health + heal;

        // Defensa resta de forma proporcional

        player.health /= damage / player.defense; //player.health = player.health / (damage / player.defense);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movement; // Esto hará que el objeto se muevo en la posición definida en el editor
    }
}
