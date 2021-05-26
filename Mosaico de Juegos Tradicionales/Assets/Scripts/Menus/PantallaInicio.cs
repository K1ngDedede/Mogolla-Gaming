using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour
{
    GameObject panelInfo;
    private void Start()
    {
        panelInfo = GameObject.FindGameObjectWithTag("panelInfo");
        if (ConfigUtils.MostrarPanelInfo)
        {
            MostrarPopup();
        }
        else
        {
            CerrarPopup();
        }
    }

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

    public void CerrarPopup()
    {
        panelInfo.SetActive(false);
        ConfigUtils.MostrarPanelInfo = false;
    }

    public void MostrarPopup()
    {
        panelInfo.SetActive(true);
    }
}
