using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionHolder : MonoBehaviour
{

    public Slider music;
    public Slider sfx;

    void Start()
    {

        music.value = PlayerPrefs.GetFloat("mVol");
        sfx.value = PlayerPrefs.GetFloat("sVol");
    }

    void Update()
    {
        PlayerPrefs.SetFloat("mVol", music.value);
        PlayerPrefs.SetFloat("sVol", sfx.value);

    }

}
