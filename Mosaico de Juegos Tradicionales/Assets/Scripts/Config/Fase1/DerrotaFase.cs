using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DerrotaFase : MonoBehaviour
{
    [SerializeField]
    string escenaFase;
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
        ConfigUtils.PrimerIntentoFase = false;
        SceneManager.LoadScene(escenaFase);
    }

    public void VolverAMenu()
    {
        ConfigUtils.PrimerIntentoFase = true;
        SceneManager.LoadScene("menu1");
    }
}
