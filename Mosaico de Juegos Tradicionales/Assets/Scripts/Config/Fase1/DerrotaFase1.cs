using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DerrotaFase1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reintentar()
    {
        SceneManager.LoadScene("fase1");
    }

    public void VolverAMenu()
    {
        SceneManager.LoadScene("menu1");
    }
}
