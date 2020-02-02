using UnityEngine;

public class Billboard : MonoBehaviour
{
	private Transform planetTransform;

	private void Awake()
	{
		planetTransform = PlanetFinder.planet.transform;
	}
	void Update()
    {
		Vector3 gravDirection = (transform.position - planetTransform.position).normalized;
		transform.LookAt(Camera.main.transform.position, gravDirection);
    }
}
