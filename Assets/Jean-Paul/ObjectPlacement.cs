using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacement : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;
    public Transform planet;
    public LayerMask planetLayer;
    public LayerMask defaultLayer;
   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			if (Time.timeScale == 1)
			{
				if (Essence.essenceCount > SpawnManager.essenceCost)
				{
					// get raycast hit based on mouse position.
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;


					if (Physics.Raycast(ray, out hit, planetLayer))
					{
						Debug.DrawLine(ray.origin, hit.point);
						if (Physics.OverlapSphere(hit.point, 3, defaultLayer).Length < 1)
						{
							// Calculate appropriate rotation based on planet.
							Quaternion toRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
							var objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
							// Spawn object
							Instantiate(objectToSpawn, hit.point, toRotation);
							Essence.essenceCount -= SpawnManager.essenceCost;
						}
					}
				}
			}
        }
    }
}
