using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManage : MonoBehaviour
{
    public ObjectPlacement objectplacement;
    public GameObject treePrefab;
    public GameObject animalPrefab;

    public void SelectTree()
    {
        objectplacement.objectToSpawn = treePrefab;
    }

    public void SelectAnimal()
    {
        objectplacement.objectToSpawn = animalPrefab;
    }
}
