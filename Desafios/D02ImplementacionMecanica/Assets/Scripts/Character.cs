using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.VersionControl;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void healCharacter(float heal)
    {
        health += heal;
    }

    private void damageCharacter(float damage)
    {
        health -= damage;
    }

    private void moveCharacter()
    {
        transform.position += direction * speed;
    }
}
