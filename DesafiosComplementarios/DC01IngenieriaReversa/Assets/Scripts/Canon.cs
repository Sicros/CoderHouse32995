using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private KeyCode oneShootKeyCode;
    [SerializeField] private KeyCode twoShootKeyCode;
    [SerializeField] private KeyCode threeShootKeyCode;
    [SerializeField] private KeyCode fourShootKeyCode;

    public GameObject bullet;

    public Transform pointOfShoot;

    public Bullet bulletData;

    private void Update()
    {
        if (Input.GetKeyDown(oneShootKeyCode))
        {
            OneShoot();
        }

        if (Input.GetKeyDown(twoShootKeyCode))
        {
            TwoShoot();
        }

        if (Input.GetKeyDown(threeShootKeyCode))
        {
            ThreeShoot();
        }

        if (Input.GetKeyDown(fourShootKeyCode))
        {
            FourShoot();
        }
    }

    private void OneShoot()
    {
        Debug.Log("One Shoot");
        Instantiate(bullet, pointOfShoot);
    }

    private void TwoShoot()
    {
        Debug.Log("Two Shoots!");
        GameObject firstShoot = Instantiate(bullet, pointOfShoot);
        float radius = MaxThreeValues(
            firstShoot.transform.localScale.x,
            firstShoot.transform.localScale.y,
            firstShoot.transform.localScale.z
        );
        Debug.Log("" + radius);
        //yield return new WaitForSeconds(radius / bulletData.speed);
        //yield return new WaitForSecondsRealtime(2f);
        Instantiate(bullet, pointOfShoot);


        //float speed = bulletData.speed;
    }

    private void ThreeShoot()
    {
        Debug.Log("Three Shoots!!");
        Instantiate(bullet, pointOfShoot);
        
    }

    private void FourShoot()
    {
        Debug.Log("Four Shoots!!!");
        Instantiate(bullet, pointOfShoot);
    }

    private float MaxThreeValues(float x, float y, float z)
    {
        if (x >= y)
        {
            if (x >= z)
            {
                return x;
            }
            else
            {
                return z;
            }
        }
        else
        {
            if (y >= z)
            {
                return y;
            }
            else
            {
                return z;
            }
        }
    }
}
