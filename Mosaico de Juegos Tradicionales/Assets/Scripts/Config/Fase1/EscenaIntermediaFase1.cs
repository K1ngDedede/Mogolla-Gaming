﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscenaIntermediaFase1 : MonoBehaviour
{

    string nombreSiguienteMicrojuego;
    Text textoPirinola;
    string escenaACargar;
    // Start is called before the first frame update
    void Start()
    {
        Microjuego siguienteMicrojuego = ConfigFase1Utils.MicrojuegosAJugar[ConfigFase1Utils.NumMicrojuegosJugados];
        DatosSiguienteMicrojuego(siguienteMicrojuego);
        textoPirinola = GameObject.FindGameObjectWithTag("TextoPirinola").GetComponent<Text>();
        textoPirinola.text = nombreSiguienteMicrojuego;


        //Animacion

        //cuando termine la animacion se carga la escena
        SceneManager.LoadScene(escenaACargar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DatosSiguienteMicrojuego(Microjuego microjuego)
    {
        if (microjuego == Microjuego.Jackses)
        {
            nombreSiguienteMicrojuego = "Jackses";
            escenaACargar = "jackses";
        }
        else if (microjuego == Microjuego.Trompo)
        {
            nombreSiguienteMicrojuego = "Trompo";
            //cargar escena de trompo
        }
        else if (microjuego == Microjuego.Fuchi)
        {
            nombreSiguienteMicrojuego = "Fuchi";
            //cargar escena de fuchi
        }
    }
}
