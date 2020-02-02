using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public AIManager aiManager;
    public float speed = 20f;
    public LayerMask defaultLayer;
    private Transform planet;
    private GameObject foodTarget;

    public static Vector3 wayPoint = Vector3.zero;
    private Vector3 axis;
    private readonly float radius = 100f;
    private bool moving = false;
    [Space]
    [Header("AI Values")]
    public float waypointMin = 1f;
    public float waypointMax = 3f;

    public float movementMin = 1f;
    public float movementMax = 3f;

    public float foodSearchRadius = 30f;

	private void Start()
    {
        planet = PlanetFinder.planet.transform;
        StartCoroutine(WanderMovement());
    }

    IEnumerator WanderMovement()
    {
        while (true)
        {
        yield return new WaitForSeconds(Random.Range(waypointMin, waypointMax));
			if (aiManager.needsFood)
			{
				var collisions = Physics.OverlapSphere(transform.position, foodSearchRadius, defaultLayer);
				if (collisions.Length > 1)
				{
					for (int i = 0; i < collisions.Length; i++)
					{
						if (aiManager.foodSource == "Everything")
						{
							if (collisions[i].tag == "Herbivore" || collisions[i].tag == "Carnivore" || collisions[i].tag == "Plant" || collisions[i].tag == "Obstacle")
							{
								wayPoint = collisions[i].transform.position;
								foodTarget = collisions[i].gameObject;
							}
						}
						else if (collisions[i].tag == aiManager.foodSource)
						{
							wayPoint = collisions[i].transform.position;
							foodTarget = collisions[i].gameObject;
						}
					}
				}
			}
			else
			{
				wayPoint = Random.onUnitSphere * radius + planet.position;
			}
            Wander();
            moving = true;
            if (!aiManager.needsFood)
            {
                yield return new WaitForSeconds(Random.Range(movementMin, movementMax));
                moving = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (foodTarget != null)
        {
            if (Vector3.Distance(transform.position, foodTarget.transform.position) < 10)
            {
                if (foodTarget.tag == "Herbivore")
                {
                    Essence.essenceCount += 30;
                }
                else if(foodTarget.tag == "Plant")
                {
                    Essence.essenceCount += 10;
                }
                Destroy(foodTarget);
                aiManager.currentHunger = 0;
                aiManager.needsFood = false;
                moving = false;
               
            }
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
        if (other.gameObject.tag != "Planet")
        {
            moving = false;
        }
    }
}
