using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Runtime.InteropServices;

public class EscenaDetalleMicrojuego : MonoBehaviour
{
    Microjuego microjuego;
    GameObject botonInstrucciones;
    bool mostrandoRealidad = true;
    Sprite botonRealidad, botonJueguelo;
    string ubicacionSprites = "Misc/UI/";
    Text instruccionesText;

    public void OpenLinkJSPlugin(string link)
    {
        #if !UNITY_EDITOR
        openWindow("http://unity3d.com");
        #endif
    }

    [DllImport("__Internal")]
    private static extern void openWindow(string url);
    // Start is called before the first frame update
    void Start()
    {
        botonRealidad = Resources.Load<Sprite>(ubicacionSprites + "realidad");
        botonJueguelo = Resources.Load<Sprite>(ubicacionSprites + "iJueguelo");
        instruccionesText = GameObject.FindGameObjectWithTag("instrucciones").GetComponent<Text>();
        microjuego = ConfigUtils.MicrojuegoActual;
        instruccionesText.text = microjuego.instruccionesVidaReal;
        botonInstrucciones = GameObject.FindGameObjectWithTag("botonJueguelo");
        GameObject.FindGameObjectWithTag("textoJuego").GetComponent<Text>().text = microjuego.nombre;
        string descripcion = "";
        if(microjuego.nombresAlternativos != "")
        {
            descripcion = "Otros nombres: " + microjuego.nombresAlternativos+"\n";
        }
        descripcion += microjuego.descripcion;
        GameObject.FindGameObjectWithTag("descripcion").GetComponent<Text>().text = descripcion;
        Image imagenJuego = GameObject.FindGameObjectWithTag("imagenMicrojuego").GetComponent<Image>();
        Sprite imagen = Resources.Load<Sprite>(microjuego.pathImagen);
        imagenJuego.sprite = imagen;
        imagenJuego.preserveAspect = true;
    }

    public void CambiarInstrucciones()
    {
        if (mostrandoRealidad)
        {
            botonInstrucciones.GetComponent<Image>().sprite = botonJueguelo;
            instruccionesText.text = microjuego.instruccionesJuego;
        }
        else
        {
            botonInstrucciones.GetComponent<Image>().sprite = botonRealidad;
            instruccionesText.text = microjuego.instruccionesVidaReal;
        }
        mostrandoRealidad = !mostrandoRealidad;
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
                OllaUtils._Fase = Fase.MODOLIBRE;
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
            case NombreMicrojuego.Fuchi:
                FuchiUtils.facil();
                FuchiUtils.Fase = Fase.MODOLIBRE;
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
            case NombreMicrojuego.Fuchi:
                FuchiUtils.dificil();
                FuchiUtils.Fase = Fase.MODOLIBRE;
                break;
            default:
                break;
        }
        SceneManager.LoadScene(ConfigUtils.MicrojuegoActual.escena);
    }

    public void AbrirEnlace()
    {
        //OpenURLInExternalWindow(microjuego.urlVideo);
        openWindow(microjuego.urlVideo);
    }
}
