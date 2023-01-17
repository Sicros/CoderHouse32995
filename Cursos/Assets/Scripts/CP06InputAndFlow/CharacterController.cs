using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float damageToTake;
    [SerializeField] private float speed;
    [SerializeField] private bool isParalyzed;
    [SerializeField] private bool isGodMode;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootingPoint;

    void Start()
    {
        ReceiveDamage(damageToTake);
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector3 (horizontal, 0, vertical);
        // Debug.Log("Horizontal: " + horizontal + ", Vertical: "+ vertical);
        if (isGodMode || (health > 0 && !isParalyzed))
        {
            Move(direction);

            var shouldShoot = Input.GetKeyDown(KeyCode.Space);
            if (shouldShoot)
            {
                Shoot();
            }
        }
    }

    private void ReceiveDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            Debug.Log("Die");
        }
    }

    private void Move(Vector3 moveDirection)
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }
}
