using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaFinalModoLibre : MonoBehaviour
{
    public void SeleccionarDificultad()
    {
        SceneManager.LoadScene("detalleMicrojuego");
    }

    public void Volver()
    {
        SceneManager.LoadScene("modoLibre");
    }

    public void Reintentar()
    {
        SceneManager.LoadScene(ConfigUtils.MicrojuegoActual.escena);
    }
}
