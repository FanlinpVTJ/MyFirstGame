using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform shootOrigin;

    [SerializeField]
    private Vector3 shootOffset;

    [SerializeField]
    private bool useShootOrigin;

    public float bulletSpeed = 100f;
    
   
    private void Update()
    {
                     
        if (Input.GetMouseButtonDown(0))
        {
            if(useShootOrigin)
            {
                FireBulletFromShootOrigin();
            }
            else
            {
                //FireBulletFromOffset();
                FireWithQuaternions();
            }
        }
        
    }

    private void FixedUpdate()
    {
        
    }

    private void FireBulletFromOffset()
    {
        var shootRelativeOffset = transform.right * shootOffset.x + transform.up * shootOffset.y + transform.forward * shootOffset.z;
        var shootOrigin = transform.position + shootRelativeOffset;
        GameObject newBullet = Instantiate(bullet, shootOrigin, transform.rotation) as GameObject;

        Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
        bulletRB.velocity = transform.forward * bulletSpeed;
    }

    private void FireBulletFromShootOrigin()
    {
        GameObject newBullet = Instantiate(bullet,
                shootOrigin.position, shootOrigin.rotation) as GameObject;

        Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
        bulletRB.velocity = shootOrigin.forward * bulletSpeed;
    }

    private void FireWithQuaternions()
    {
        var rotatedOffset = transform.rotation * shootOffset;
        var shootOrigin = transform.position + rotatedOffset;
        GameObject newBullet = Instantiate(bullet, shootOrigin, transform.rotation) as GameObject;

        Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
        bulletRB.velocity = transform.forward * bulletSpeed;

    }

}
