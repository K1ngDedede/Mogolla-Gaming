using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDYermisDefensa : MonoBehaviour
{
    static Text textoTiempo;

    // Start is called before the first frame update
    void Awake()
    {
        textoTiempo = GameObject.FindGameObjectWithTag("TextoTimer").GetComponent<Text>();
    }

    public static void ActualizarTiempo(float tiempo)
    {
        textoTiempo.text = tiempo + "s";
    }

}
