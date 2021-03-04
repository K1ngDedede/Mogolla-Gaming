using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuModoHistoria : MonoBehaviour
{
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
