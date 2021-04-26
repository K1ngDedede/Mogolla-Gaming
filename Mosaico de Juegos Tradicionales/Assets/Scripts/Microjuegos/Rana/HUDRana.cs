using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDRana : MonoBehaviour
{
    static Text textoTiempo;
    static Text textoPuntaje;
    static int puntaje = 0;
    static int puntajeRequerido = RanaUtils.PuntajeRequerido;

    // Start is called before the first frame update
    void Awake()
    {
        textoTiempo = GameObject.FindGameObjectWithTag("TextoTimer").GetComponent<Text>();
        textoPuntaje = GameObject.FindGameObjectWithTag("textoPuntaje").GetComponent<Text>();
        textoPuntaje.text = "Puntaje: " + puntaje + "/" + puntajeRequerido;
    }

    public static void ActualizarTiempo(float tiempo)
    {
        textoTiempo.text = tiempo + "s";
    }

    public static void ActualizarPuntaje(int puntajeAdicional)
    {
        puntaje += puntajeAdicional;
        textoPuntaje.text = "Puntaje: " + puntaje + "/" + puntajeRequerido;
    }
}
