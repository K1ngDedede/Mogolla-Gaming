using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volumen : MonoBehaviour
{
    public AudioMixer mixer;
    private void Start()
    {
        float volumen = PlayerPrefs.GetFloat("VolumenMusica", 0.75f);
        mixer.SetFloat("VolMusica", Mathf.Log10(volumen) * 20);
    }

}
