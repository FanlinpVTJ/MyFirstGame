using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Vector3 camOffset = new Vector3(0f, 3f, -5f);

    //private Vector3 camOffset = new Vector3(1, 1, 1);
    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player_Body").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);
        this.transform.LookAt(target);
    }
}
