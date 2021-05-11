using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class EscenaDetalleMicrojuego : MonoBehaviour
{
    Microjuego microjuego;
    GameObject botonJueguelo, botonRealidad;
    // Start is called before the first frame update
    void Start()
    {
        microjuego = ConfigUtils.MicrojuegoActual;
        botonJueguelo = GameObject.FindGameObjectWithTag("botonJueguelo");
        botonRealidad = GameObject.FindGameObjectWithTag("botonRealidad");
        GameObject.FindGameObjectWithTag("textoJuego").GetComponent<Text>().text = microjuego.nombre;
        string descripcion = "";
        if(microjuego.nombresAlternativos != "")
        {
            descripcion = "Otros nombres: " + microjuego.nombresAlternativos+"\n";
        }
        descripcion += microjuego.descripcion;
        GameObject.FindGameObjectWithTag("descripcion").GetComponent<Text>().text = descripcion;
        CambiarInstruccionesRealidad();
        VideoPlayer videoPlayer = GameObject.FindGameObjectWithTag("videoPlayer").GetComponent<VideoPlayer>();
        videoPlayer.clip = Resources.Load<VideoClip>(microjuego.pathVideo);
        //image.preserveAspect = true;
    }

    public void CambiarInstruccionesRealidad()
    {
        GameObject.FindGameObjectWithTag("instrucciones").GetComponent<Text>().text = microjuego.instruccionesVidaReal;
        Color colorBotonJueguelo = botonJueguelo.GetComponent<Image>().color;
        colorBotonJueguelo.a = 0;
        botonJueguelo.GetComponent<Image>().color = colorBotonJueguelo;
        Color colorBotonRealidad = botonRealidad.GetComponent<Image>().color;
        colorBotonRealidad.a = 1;
        botonRealidad.GetComponent<Image>().color = colorBotonRealidad;

    }

    public void CambiarInstruccionesJueguelo()
    {
        GameObject.FindGameObjectWithTag("instrucciones").GetComponent<Text>().text = microjuego.instruccionesJuego;
        Color colorBotonJueguelo = botonJueguelo.GetComponent<Image>().color;
        colorBotonJueguelo.a = 1;
        botonJueguelo.GetComponent<Image>().color = colorBotonJueguelo;
        Color colorBotonRealidad = botonRealidad.GetComponent<Image>().color;
        colorBotonRealidad.a = 0;
        botonRealidad.GetComponent<Image>().color = colorBotonRealidad;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Regresar()
    {
        SceneManager.LoadScene("modoLibre");
    }

    public void Facil()
    {
        NombreMicrojuego nombreMicrojuego = ConfigUtils.MicrojuegoActual.nombreMicrojuego;
        switch (nombreMicrojuego)
        {
            case NombreMicrojuego.Jackses:
                JacksesUtils.Facil();
                JacksesUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Yermis:
                YermisUtils.Facil();
                YermisUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Olla:
                OllaUtils.facilito();
                break;
            case NombreMicrojuego.Trompo:
                TrompoUtils.facilito();
                TrompoUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Rana:
                RanaUtils.Facil();
                RanaUtils.Fase = Fase.MODOLIBRE;
                break;
			case NombreMicrojuego.Tejo:
                TejoUtils.Facil();
                TejoUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Coca:
                CocaUtils.Facil();
                CocaUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Piquis:
                piquisUtils.facilito();
                piquisUtils._Fase = Fase.MODOLIBRE;
                break;
            default:
                break;
        }
        SceneManager.LoadScene(ConfigUtils.MicrojuegoActual.escena);
    }

    public void Medio()
    {
        NombreMicrojuego nombreMicrojuego = ConfigUtils.MicrojuegoActual.nombreMicrojuego;
        switch (nombreMicrojuego)
        {
            case NombreMicrojuego.Jackses:
                JacksesUtils.Medio();
                JacksesUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Yermis:
                YermisUtils.Medio();
                YermisUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Olla:
                OllaUtils.medio();
                OllaUtils._Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Trompo:
                TrompoUtils.medio();
                TrompoUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Rana:
                RanaUtils.Medio();
                RanaUtils.Fase = Fase.MODOLIBRE;
                break;
			case NombreMicrojuego.Tejo:
                TejoUtils.Medio();
                TejoUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Coca:
                CocaUtils.Medio();
                CocaUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Piquis:
                piquisUtils.medio();
                piquisUtils._Fase = Fase.MODOLIBRE;
                break;
            default:
                break;
        }
        SceneManager.LoadScene(ConfigUtils.MicrojuegoActual.escena);
    }

    public void Dificil()
    {
        NombreMicrojuego nombreMicrojuego = ConfigUtils.MicrojuegoActual.nombreMicrojuego;
        switch (nombreMicrojuego)
        {
            case NombreMicrojuego.Jackses:
                JacksesUtils.Dificil();
                JacksesUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Yermis:
                YermisUtils.Dificil();
                YermisUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Olla:
                OllaUtils.difisil();
                OllaUtils._Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Trompo:
                TrompoUtils.difisil();
                TrompoUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Rana:
                RanaUtils.Dificil();
                RanaUtils.Fase = Fase.MODOLIBRE;
                break;
			case NombreMicrojuego.Tejo:
                TejoUtils.Dificil();
                TejoUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Coca:
                CocaUtils.Dificil();
                CocaUtils.Fase = Fase.MODOLIBRE;
                break;
            case NombreMicrojuego.Piquis:
                piquisUtils.difisil();
                piquisUtils._Fase = Fase.MODOLIBRE;
                break;
            default:
                break;
        }
        SceneManager.LoadScene(ConfigUtils.MicrojuegoActual.escena);
    }
}
