using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private float onScreenDelay = 3f;
     private void Start()
    {
        Destroy(gameObject, onScreenDelay);
    }
}
