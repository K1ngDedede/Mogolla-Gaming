﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscenaDetalleMicrojuego : MonoBehaviour
{
    Microjuego microjuego = ConfigUtils.MicrojuegoActual;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("textoJuego").GetComponent<Text>().text = microjuego.nombre;
        string descripcion = "";
        if(microjuego.nombresAlternativos != "")
        {
            descripcion = "Otros nombres: " + microjuego.nombresAlternativos+"\n";
        }
        descripcion += microjuego.descripcion;
        GameObject.FindGameObjectWithTag("descripcion").GetComponent<Text>().text = descripcion;
        GameObject.FindGameObjectWithTag("instrucciones").GetComponent<Text>().text = microjuego.instrucciones;
        Image image = GameObject.FindGameObjectWithTag("imagenMicrojuego").GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>(microjuego.pathImagen);
        image.preserveAspect = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Regresar()
    {
        SceneManager.LoadScene("modoLibre");
    }

    public void Facil()
    {
        NombreMicrojuego nombreMicrojuego = ConfigUtils.MicrojuegoActual.nombreMicrojuego;
        switch (nombreMicrojuego)
        {
            case NombreMicrojuego.Jackses:
                JacksesUtils.Facil();
                JacksesUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Yermis:
                YermisUtils.Facil();
                YermisUtils.Fase = Fase.MODOLIBRE;
                break;
            default:
                break;
        }
        SceneManager.LoadScene(ConfigUtils.MicrojuegoActual.escena);
    }

    public void Medio()
    {
        NombreMicrojuego nombreMicrojuego = ConfigUtils.MicrojuegoActual.nombreMicrojuego;
        switch (nombreMicrojuego)
        {
            case NombreMicrojuego.Jackses:
                JacksesUtils.Medio();
                JacksesUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Yermis:
                YermisUtils.Medio();
                YermisUtils.Fase = Fase.MODOLIBRE;
                break;
            default:
                break;
        }
        SceneManager.LoadScene(ConfigUtils.MicrojuegoActual.escena);
    }

    public void Dificil()
    {
        NombreMicrojuego nombreMicrojuego = ConfigUtils.MicrojuegoActual.nombreMicrojuego;
        switch (nombreMicrojuego)
        {
            case NombreMicrojuego.Jackses:
                JacksesUtils.Dificil();
                JacksesUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Yermis:
                YermisUtils.Dificil();
                YermisUtils.Fase = Fase.MODOLIBRE;
                break;
            default:
                break;
        }
        SceneManager.LoadScene(ConfigUtils.MicrojuegoActual.escena);
    }
}