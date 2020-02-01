using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float moveSpeed = 15;
    public Rigidbody myRigidbody;
    private Vector3 moveDir;

    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
}