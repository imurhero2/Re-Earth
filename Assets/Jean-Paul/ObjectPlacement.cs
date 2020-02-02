﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacement : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform planet;
    public LayerMask planetLayer;
    public LayerMask defaultLayer;
   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Essence.essenceCount > 0)
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

                        // Spawn object
                        Instantiate(objectToSpawn, hit.point, toRotation);
                        Essence.essenceCount -= 1;
                       
                    }
                }
            }
        }
    }
}
