using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscenaIntermediaFase2 : MonoBehaviour
{
    
    string nombreSiguienteMicrojuego;
    Text texto;
    string escenaACargar;
    Timer timerCambioEscena;
    string ubicacion = "Cutscene/Fase2/";

    private void Awake()
    {
        timerCambioEscena = Camera.main.gameObject.AddComponent<Timer>();
        timerCambioEscena.Duration = 5;
        timerCambioEscena.Run();
    }

    // Start is called before the first frame update
    void Start()
    {
        int vidasRestantes = ConfigFase2Utils.VidasRestantes;

        NombreMicrojuego siguienteMicrojuego = ConfigFase2Utils.MicrojuegosAJugar[ConfigFase2Utils.NumMicrojuegosJugados];
        DatosSiguienteMicrojuego(siguienteMicrojuego);
        texto = GameObject.FindGameObjectWithTag("TextoPirinola").GetComponent<Text>();
        texto.text = nombreSiguienteMicrojuego;

        GameObject[] chulos = GameObject.FindGameObjectsWithTag("chulo");
        Chulo chuloScript;

        switch (vidasRestantes)
        {
            case 2:
                chuloScript = chulos[2].GetComponent<Chulo>();
                if (ConfigFase2Utils.AcabaDePerder)
                {
                    chuloScript.Perder();
                }
                else
                {
                    chuloScript.CambiarAEquis();
                }
                break;
            case 1:
                if (ConfigFase2Utils.AcabaDePerder)
                {
                    chulos[1].GetComponent<Chulo>().Perder();
                    chulos[2].GetComponent<Chulo>().CambiarAEquis();
                }
                else
                {
                    chulos[1].GetComponent<Chulo>().CambiarAEquis();
                    chulos[2].GetComponent<Chulo>().CambiarAEquis();
                }
                break;
        }




        

    }

    // Update is called once per frame
    void Update()
    {

        if (timerCambioEscena.Finished)
        {
            SceneManager.LoadScene(escenaACargar);
        }
    }

    private void DatosSiguienteMicrojuego(NombreMicrojuego microjuego)
    {
        Microjuego siguienteMicrojuego = ConfigUtils.BuscarMicrojuego(microjuego);
        nombreSiguienteMicrojuego = siguienteMicrojuego.nombre;
        escenaACargar = siguienteMicrojuego.escena;
        ConfigUtils.MicrojuegoActual = siguienteMicrojuego;
    }
}
