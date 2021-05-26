using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoriaFase3 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int vidas = ConfigFase3Utils.VidasRestantes;
        string plural = "vidas";
        string quedan = "quedan";
        if (vidas == 1)
        {
            plural = "vida";
            quedan = "queda";
        }
        string texto = "Le " + quedan + " " + vidas + " " + plural + ".";
        GameObject.FindGameObjectWithTag("botonJueguelo").GetComponent<Text>().text = texto;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continuarFase3()
    {
        ConfigFase3Utils.JugandoEnContinuacion = true;
        SceneManager.LoadScene("escenaIntermediaFase3");
    }

    public void VolverAMenu()
    {
        SceneManager.LoadScene("menu0");
    }
}
