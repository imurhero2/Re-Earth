using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public Rigidbody rb;

    //public float speed = 4;
    private Transform planetTransform;
    private float gravity = 100;
    private float distanceToGround;
    private Vector3 groundNormal;
    private bool onGround;

    private void Start()
    {
        rb.freezeRotation = true;
        planetTransform = PlanetFinder.planet.transform;
    }

    private void Update()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            distanceToGround = hit.distance;
            groundNormal = hit.normal;

            if (distanceToGround <= 0.2f)
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }

        // Gravity and Rotation
        Vector3 gravDirection = (transform.position - planetTransform.position).normalized;

        if (onGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        transform.rotation = toRotation;
    }
}
