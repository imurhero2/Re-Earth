using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public ObjectPlacement objectplacement;
    public GameObject treePrefab;
    public GameObject herbivorePrefab;
    public GameObject carnivorePrefab;
    public static int essenceCost;

    public void SelectTree()
    {
        objectplacement.objectToSpawn = treePrefab;
        essenceCost = 5;
    }

    public void SelectHerbivore()
    {
        objectplacement.objectToSpawn = herbivorePrefab;
        essenceCost = 20;
    }

    public void SelectCarnivore()
    {
        objectplacement.objectToSpawn = carnivorePrefab; ;
        essenceCost = 100;
    }
}