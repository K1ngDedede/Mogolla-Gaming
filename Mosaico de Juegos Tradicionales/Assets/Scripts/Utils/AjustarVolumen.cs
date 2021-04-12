using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AjustarVolumen : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    private void Start()
    {
        float volumen = PlayerPrefs.GetFloat("VolumenMusica", 0.75f);
        slider.value = volumen;
        mixer.SetFloat("VolMusica", Mathf.Log10(volumen) * 20);
    }

    

    public void AjustarNivel(float nivelSlider)
    {
        mixer.SetFloat("VolMusica", Mathf.Log10(nivelSlider) * 20);
        PlayerPrefs.SetFloat("VolumenMusica", nivelSlider);
    }
}
