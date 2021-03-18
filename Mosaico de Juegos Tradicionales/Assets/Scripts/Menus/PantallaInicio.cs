using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
    }

    public void Empezar()
    {
        SceneManager.LoadScene("menu1");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("creditos");
    }
}
