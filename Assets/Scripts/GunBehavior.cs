using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

// TODO: это не поведение пули, это поведение оружия
// А вот пули - это твои шарики, на которых лежит BulletDestroy,
// который мы в итоге переименуем в Bullet
// public class Weapon
public class GunBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform gunPlace;

    [SerializeField]
    private Vector3 shootOffset;

    [SerializeField]
    private bool useShootOrigin;

    public float bulletSpeed = 100f;

    private int reloadTime = 1;
    private bool isReloading = true;

    

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && isReloading)
        {
           StartCoroutine(ReloadGun());

            if (useShootOrigin)
            {
                FireBulletFromShootOrigin();
                Debug.Log("useShootOrigin");
            }
            else
            {
                //FireBulletFromOffset();
                FireWithQuaternions();
            }
        }
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
                gunPlace.position, gunPlace.rotation) as GameObject;

        Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
        bulletRB.velocity = gunPlace.forward * bulletSpeed;
    }

    private void FireWithQuaternions()
    {
        var rotatedOffset = transform.rotation * shootOffset;
        var shootOrigin = transform.position + rotatedOffset;
        GameObject newBullet = Instantiate(bullet, shootOrigin, transform.rotation) as GameObject;

        Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
        bulletRB.velocity = transform.forward * bulletSpeed;
        
    }

    IEnumerator ReloadGun()
    {
        isReloading = false;
       
        yield return new WaitForSeconds(reloadTime);
        isReloading = true;
    }
}
