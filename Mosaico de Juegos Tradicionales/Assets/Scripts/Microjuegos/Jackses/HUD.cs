using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    
    static Text textoJacks;

    static Text textoTiempo;

    static string prefijoTexto = "Yaquis: ";

    public static int jacksRecolectados = 0;
    // Start is called before the first frame update
    void Awake()
    {
        textoJacks = GameObject.FindGameObjectWithTag("TextoJacks").GetComponent<Text>();
        textoJacks.text = prefijoTexto + jacksRecolectados;

        textoTiempo = GameObject.FindGameObjectWithTag("TextoTimer").GetComponent<Text>();
    }

    public static void ActualizarTiempo(float tiempo)
    {
        textoTiempo.text = tiempo + "s";
    }

    public static void IncrementarJacks()
    {
        jacksRecolectados++;
        textoJacks.text = prefijoTexto + jacksRecolectados;
    }

    public static void Perder()
    {
        textoJacks.text = "Derrota";
    }

    public static void Ganar()
    {
        textoJacks.text = "Victoria";
    }
}
