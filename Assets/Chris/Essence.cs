using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Essence : MonoBehaviour
{
    public Text EssenceText;
    public static int essenceCount;
    private float seconds;
    private float interval = 1F;

    void Start()
    {
        essenceCount = 0;
        EssenceText.text = "Essence: " + essenceCount.ToString();
    }

    void Update()
    {
        seconds += Time.deltaTime;

        if (seconds >= interval)
        {
            essenceCount++;
            seconds = 0;
        }

        EssenceText.text = "Essence: " + essenceCount.ToString();
    }
    
}
