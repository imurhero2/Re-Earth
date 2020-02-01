using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject planet;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - planet.transform.position;
    }

    
    void LateUpdate()
    {
        transform.position = planet.transform.position + offset;

        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
