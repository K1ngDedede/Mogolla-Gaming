using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuModoLibre : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolverAMenuPrincipal()
    {
        SceneManager.LoadScene("menu1");
    }

    public static void ActualizarTitulo(string texto)
    {
        GameObject.FindGameObjectWithTag("textoJuego").GetComponent<Text>().text = texto;
    }

}
