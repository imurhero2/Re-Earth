using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFinder : MonoBehaviour
{
    public static GameObject planet;

    private void Awake()
    {
        planet = this.gameObject;
    }
}