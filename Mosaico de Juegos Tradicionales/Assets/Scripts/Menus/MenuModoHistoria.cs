using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuModoHistoria : MonoBehaviour
{
    Button botonSegundaFase, botonTerceraFase;

    private void Start()
    {
        botonSegundaFase = GameObject.FindGameObjectWithTag("BotonSegundaFase").GetComponent<Button>();
        botonTerceraFase = GameObject.FindGameObjectWithTag("BotonTerceraFase").GetComponent<Button>();
        if(ConfigUtils.Fase == 1)
        {
            botonSegundaFase.interactable = false;
            botonTerceraFase.interactable = false;
        }
        else if(ConfigUtils.Fase == 2)
        {
            botonTerceraFase.interactable = false;
        }
    }
    public void EntrarFase1()
    {
        SceneManager.LoadScene("fase1");
    }

    public void EntrarFase2()
    {
        //SceneManager.LoadScene("");
    }

    public void EntrarFase3()
    {
        //SceneManager.LoadScene("");
    }

    public void Atras()
    {
        SceneManager.LoadScene("menu1");
    }
}
