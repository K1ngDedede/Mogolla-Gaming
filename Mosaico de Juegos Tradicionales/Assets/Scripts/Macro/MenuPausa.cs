using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool pausado = false;
    GameObject menuPausa;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        menuPausa = GameObject.FindGameObjectWithTag("panelPausa");
        menuPausa.SetActive(false);
        audioSource = GameObject.FindGameObjectWithTag("musica").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        audioSource.Pause();
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        pausado = true;
    }

    public void Reanudar()
    {
        audioSource.Play();
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        pausado = false;
    }

}
