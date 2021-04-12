using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelPausa : MonoBehaviour
{
    
    GameObject menuPausa;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        menuPausa = GameObject.FindGameObjectWithTag("panelPausa");
        audioSource = GameObject.FindGameObjectWithTag("musica").GetComponent<AudioSource>();
    }


    public void Reanudar()
    {
        audioSource.Play();
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        MenuPausa.pausado = false;
    }
    public void RegresarMenuPrincipal()
    {
        Time.timeScale = 1;
        MenuPausa.pausado = false;
        SceneManager.LoadScene("menu0");
    }
}
