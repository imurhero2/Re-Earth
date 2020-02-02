using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public ObjectPlacement objectplacement;
	public GameObject flowerPrefab;
	public GameObject plantPrefab;
    public GameObject bunnyPrefab;
    public GameObject sheepPrefab;
    public GameObject foxPrefab;
    public GameObject bearPrefab;
    public GameObject dinosaurPrefab;
    public GameObject birchTreePrefab;
    public GameObject cedarTreePrefab;
    public GameObject rockPrefab;
    public GameObject bushPrefab;
    public static int essenceCost;

    public void SelectFlower()
    {
		objectplacement.objectsToSpawn.Clear();
        objectplacement.objectsToSpawn.Add(flowerPrefab);
        essenceCost = 5;
    }

	public void SelectPlant()
	{
		objectplacement.objectsToSpawn.Clear();
		objectplacement.objectsToSpawn.Add(flowerPrefab);
		objectplacement.objectsToSpawn.Add(plantPrefab);
		essenceCost = 5;
	}

	public void SelectHerbivore()
    {
		objectplacement.objectsToSpawn.Clear();
		objectplacement.objectsToSpawn.Add(bunnyPrefab);
		objectplacement.objectsToSpawn.Add(sheepPrefab);
		essenceCost = 20;
    }

    public void SelectCarnivore()
    {
		objectplacement.objectsToSpawn.Clear();
		objectplacement.objectsToSpawn.Add(foxPrefab);
		objectplacement.objectsToSpawn.Add(bearPrefab);
		essenceCost = 100;
    }

	public void SelectDinosaur()
	{
		objectplacement.objectsToSpawn.Clear();
		objectplacement.objectsToSpawn.Add(dinosaurPrefab);
		essenceCost = 1000;
	}

	public void SelectTree()
	{
		objectplacement.objectsToSpawn.Clear();
		objectplacement.objectsToSpawn.Add(birchTreePrefab);
		objectplacement.objectsToSpawn.Add(cedarTreePrefab);
	}

	public void SelectRock()
	{
		objectplacement.objectsToSpawn.Clear();
		objectplacement.objectsToSpawn.Add(rockPrefab);
	}

	public void SelectBush()
	{
		objectplacement.objectsToSpawn.Clear();
		objectplacement.objectsToSpawn.Add(bushPrefab);
	}
}