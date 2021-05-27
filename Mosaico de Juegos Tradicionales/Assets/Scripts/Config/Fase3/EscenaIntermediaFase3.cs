using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscenaIntermediaFase3 : MonoBehaviour
{
    string nombreSiguienteMicrojuego;
    Text texto;
    Text textoPuntaje;
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
        int vidasRestantes = ConfigFase3Utils.VidasRestantes;
        NombreMicrojuego siguienteMicrojuego;
        if (!ConfigFase3Utils.JugandoEnContinuacion)
        {
            siguienteMicrojuego = ConfigFase3Utils.MicrojuegosAJugar[ConfigFase3Utils.NumMicrojuegosJugados];
        }
        else
        {
            siguienteMicrojuego = ConfigFase3Utils.SiguienteMicrojuegoAleatorio();
        }
        
        DatosSiguienteMicrojuego(siguienteMicrojuego);
        texto = GameObject.FindGameObjectWithTag("TextoPirinola").GetComponent<Text>();
        texto.text = nombreSiguienteMicrojuego;

        texto = GameObject.FindGameObjectWithTag("textoPuntaje").GetComponent<Text>();
        texto.text = (ConfigFase3Utils.Puntaje+1)+"";

        //GameObject[] chulos = GameObject.FindGameObjectsWithTag("chulo");
        //Chulo chuloScript;

        //switch (vidasRestantes)
        //{
        //    case 2:
        //        chuloScript = chulos[0].GetComponent<Chulo>();
        //        if (ConfigFase2Utils.AcabaDePerder)
        //        {
        //            chuloScript.Perder();
        //        }
        //        else
        //        {
        //            chuloScript.CambiarAEquis();
        //        }
        //        break;
        //    case 1:
        //        if (ConfigFase2Utils.AcabaDePerder)
        //        {
        //            chulos[2].GetComponent<Chulo>().Perder();
        //            chulos[0].GetComponent<Chulo>().CambiarAEquis();
        //        }
        //        else
        //        {
        //            chulos[2].GetComponent<Chulo>().CambiarAEquis();
        //            chulos[0].GetComponent<Chulo>().CambiarAEquis();
        //        }
        //        break;
        //}






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
