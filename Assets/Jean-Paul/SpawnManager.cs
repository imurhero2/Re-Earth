using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public ObjectPlacement objectplacement;
    public GameObject treePrefab;
    public GameObject herbivorePrefab;
    public GameObject carnivorePrefab;

    public void SelectTree()
    {
        objectplacement.objectToSpawn = treePrefab;
    }

    public void SelectHerbivore()
    {
        objectplacement.objectToSpawn = herbivorePrefab;
    }

    public void SelectCarnivore()
    {
        objectplacement.objectToSpawn = carnivorePrefab; ;
    }
}