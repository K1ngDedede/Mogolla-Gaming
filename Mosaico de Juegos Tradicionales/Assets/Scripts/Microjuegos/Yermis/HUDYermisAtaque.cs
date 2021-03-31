using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDYermisAtaque : MonoBehaviour
{
    static Text textoTiempo;
    static Text textoDisparos;

    // Start is called before the first frame update
    void Awake()
    {
        textoDisparos = GameObject.FindGameObjectWithTag("textoDisparos").GetComponent<Text>();
        textoTiempo = GameObject.FindGameObjectWithTag("TextoTimer").GetComponent<Text>();
    }

    public static void ActualizarTiempo(float tiempo)
    {
        textoTiempo.text = tiempo + "s";
    }

    public static void ActualizarDisparos(int disparosTotales, int disparosDisponibles)
    {
        textoDisparos.text = "Lanzamientos: " + disparosDisponibles + "/" + disparosTotales;
    }
}
