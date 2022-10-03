using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float jumpVelocity;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private float distanceToGround = 1;

    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rigidBody;
    private BoxCollider boxCollider;
    
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        verticalInput = Input.GetAxis("Vertical") * moveSpeed;
        horizontalInput = Input.GetAxis("Horizontal") * rotateSpeed;
    }
    private void FixedUpdate()
    {

        Vector3 rotation = Vector3.up * horizontalInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        rigidBody.MovePosition(rigidBody.position + transform.forward * verticalInput * Time.fixedDeltaTime);
        rigidBody.MoveRotation(rigidBody.rotation * angleRot);
    }

    private void Jump()
    {
        rigidBody.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        Debug.Log("Нажал епта");
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(boxCollider.bounds.center.x,
        boxCollider.bounds.min.y, boxCollider.bounds.center.z);

        bool grounded = Physics.CheckCapsule(boxCollider.bounds.
        center, capsuleBottom, distanceToGround, groundLayer,
        QueryTriggerInteraction.Ignore);

        return grounded;
    }
}
