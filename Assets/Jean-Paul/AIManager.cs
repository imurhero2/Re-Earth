using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public float hungerRate = 1;
    public float hungerTime = 10;
    public float maxHungerTime = 30;
    public bool needsFood = false;
    public string foodSource;

    public float currentHunger;

    void Start()
    {
        GetFoodSource();
        StartCoroutine(GrowHunger());
    }

    private void GetFoodSource()
    {
        switch (this.tag)
        {
            case "Herbivore":
                foodSource = "Plant";
                break;
            case "Carnivore":
                foodSource = "Herbivore";
                break;
            default:
                break;
        }
    }

    IEnumerator GrowHunger()
    {
        while (true)
        {
            yield return new WaitForSeconds(hungerRate);
            currentHunger++;

            if (currentHunger > hungerTime)
            {
                needsFood = true;
            }
            else
            {
                needsFood = false;
            }

            if (currentHunger > maxHungerTime)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
