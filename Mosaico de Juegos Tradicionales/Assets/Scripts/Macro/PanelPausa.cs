using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelPausa : MonoBehaviour
{
    
    GameObject menuPausa;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        menuPausa = GameObject.FindGameObjectWithTag("panelPausa");
        audioSource = GameObject.FindGameObjectWithTag("musica").GetComponent<AudioSource>();
        Microjuego microjuego = ConfigUtils.MicrojuegoActual;
        GameObject.FindGameObjectWithTag("descripcion").GetComponent<Text>().text = microjuego.descripcion;
        GameObject.FindGameObjectWithTag("instrucciones").GetComponent<Text>().text += microjuego.instruccionesJuego;
        GameObject.FindGameObjectWithTag("textoJuego").GetComponent<Text>().text = microjuego.nombre;
    }


    public void Reanudar()
    {
        Cursor.visible = true;
        audioSource.Play();
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        MenuPausa.pausado = false;
    }
    public void RegresarMenuPrincipal()
    {
        Cursor.visible = true;
        NombreMicrojuego nombreMicrojuego = ConfigUtils.MicrojuegoActual.nombreMicrojuego;
        if (nombreMicrojuego == NombreMicrojuego.Fuchi || nombreMicrojuego == NombreMicrojuego.Jackses)
        {
            Cursor.visible = true;
        }
        Time.timeScale = 1;
        MenuPausa.pausado = false;
        SceneManager.LoadScene("menu0");
    }
}
