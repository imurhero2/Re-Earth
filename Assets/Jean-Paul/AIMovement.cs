using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed = 20f;
    public Transform planet;

    private Vector3 wayPoint = Vector3.zero;
    private Vector3 axis;
    private float radius = 100f;
    private bool moving = false;
    [Space]
    [Header("AI Values")]
    public float waypointMin = 1f;
    public float waypointMax = 3f;

    public float movementMin = 1f;
    public float movementMax = 3f;


    private void Start()
    {
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(waypointMin, waypointMax));
            // get a point on the sphere.
            wayPoint = Random.onUnitSphere * radius + planet.position;
            Wander();
            moving = true;
            yield return new WaitForSeconds(Random.Range(movementMin, movementMax));
            moving = false;
        }
    }

    private void Update()
    {
        // start each update looking to see if we need to move
        if ((transform.position - wayPoint).sqrMagnitude < 9)
        {
            Wander();
        }

        if (moving)
        {
            // do the rotation
            transform.RotateAround(planet.position, axis, speed * Time.deltaTime);
        }

        // just for reference...
        Debug.DrawLine(wayPoint, planet.position, Color.red);
    }

    private void Wander()
    {
        // so we know..
        var toShip = transform.position - planet.position;
        var toWayPoint = wayPoint - planet.position;

        // get the axis we are going to be rotating around
        axis = Vector3.Cross(toShip, toWayPoint);

        // now lets get the heading
        var forwardDirection = Vector3.Cross(axis, toShip);
        // lets debug the lines...
        Debug.DrawLine(transform.position, transform.position + forwardDirection, Color.yellow, 1);

        // now, lets look at that heading
        transform.LookAt(transform.position + forwardDirection, toShip);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AI Collision");
        if (other.gameObject.tag != "Planet")
        {
            moving = false;
        }
    }
}
