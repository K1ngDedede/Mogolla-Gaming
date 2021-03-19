using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escritor : MonoBehaviour
{
    Text txt;
    string contenido;

    [SerializeField]
    float tiempoAparicion;

    [SerializeField]
    float duracionCaracter;

    private void Awake()
    {
        txt = GetComponent<Text>();
        contenido = txt.text;
        txt.text = "";
        Invoke("llamarEscribir", tiempoAparicion);
    }

    private void llamarEscribir()
    {
        StartCoroutine("Escribir");
    }

    IEnumerator Escribir()
    {
        foreach(char c in contenido)
        {
            txt.text += c;
            yield return new WaitForSeconds(duracionCaracter);
        }
    }
}
