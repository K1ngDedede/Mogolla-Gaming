using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJugar : MonoBehaviour
{
    public void EntrarModoHistoria()
    {
        SceneManager.LoadScene("menuModoHistoria");
    }

    public void EntrarModoLibre()
    {
       
    }

    public void Atras()
    {
        SceneManager.LoadScene("menu0");
    }
}
