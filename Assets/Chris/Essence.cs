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
    public static int bonus;

    void Start()
    {
        essenceCount = 30;
        EssenceText.text = essenceCount.ToString();
    }

    void Update()
    {
        seconds += Time.deltaTime;

        if (seconds >= interval)
        {
            essenceCount = essenceCount + 1 + bonus;
            seconds = 0;
			EssenceText.text = essenceCount.ToString();
        }
    }
    
}
