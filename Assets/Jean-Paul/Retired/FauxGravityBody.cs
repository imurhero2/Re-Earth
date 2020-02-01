using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{
    public FauxGravityAttractor attractor;
    public Rigidbody myRigidbody;
    private Transform myTransform;

    void Start()
    {
        myRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        myRigidbody.useGravity = false;
        myTransform = transform;
    }

    void Update()
    {
        attractor.Attract(myTransform, myRigidbody);
    }
}