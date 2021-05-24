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
        GameObject.FindGameObjectWithTag("botonJueguelo").GetComponent<Text>().text = "Le quedan " + ConfigFase3Utils.VidasRestantes + " vidas, puede continuar";
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
