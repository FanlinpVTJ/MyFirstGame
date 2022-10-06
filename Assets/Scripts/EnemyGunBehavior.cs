using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class EnemyGunBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform gunPlace;

    [SerializeField]
    private Vector3 shootOffset;

    [SerializeField]
    private bool useShootOrigin;

    private float bulletSpeed = 20f;
    private int reloadTime = 1;
    private bool isReloading = true;

    [SerializeField]
    public EnemyBehavior playerDetectedEvent;

    void OnEnable()
    {
        playerDetectedEvent.PlayerDetected += EnemyFire;
    }
    void OnDisable()
    {
        playerDetectedEvent.PlayerDetected -= EnemyFire;
    }

    private void EnemyFire()
    {
        StartCoroutine(ReloadGun());
        Debug.Log("Стреляю");

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
