using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscenaIntermediaFase1 : MonoBehaviour
{
    string ubicacionAbuela = "Cutscene/";
    string nombreSiguienteMicrojuego;
    Text textoPirinola;
    string escenaACargar;
    Timer timerCambioEscena;

    //datos de la barra medidora
    Color alto = new Color(0.65098f, 0.690196f, 0.141176f), medio = new Color(0.97254f, 0.952941f, 0.6196f), bajo = new Color(0.333333f, 0.22745f, 0.196078f);

    // Start is called before the first frame update
    void Start()
    {
        int vidasRestantes = ConfigFase1Utils.VidasRestantes;

        NombreMicrojuego siguienteMicrojuego = ConfigFase1Utils.MicrojuegosAJugar[ConfigFase1Utils.NumMicrojuegosJugados];
        DatosSiguienteMicrojuego(siguienteMicrojuego);
        textoPirinola = GameObject.FindGameObjectWithTag("TextoPirinola").GetComponent<Text>();
        textoPirinola.text = nombreSiguienteMicrojuego;

        //Barra medidora de paciencia
        GameObject barraPaciencia = GameObject.FindGameObjectWithTag("barraPaciencia");
        SpriteRenderer rendererBarra = barraPaciencia.GetComponent<SpriteRenderer>();
        Animation animation = barraPaciencia.GetComponent<Animation>();
        

        //Apariencia abuela
        GameObject abuela = GameObject.FindGameObjectWithTag("abuela");
        Sprite spriteAbuela;
        SpriteRenderer spriteRendererAbuela = abuela.GetComponent<SpriteRenderer>(); ;
        Vector3 posBarra;
        Vector3 escalaBarra;
        switch (vidasRestantes)
        {
            case 4:
                spriteAbuela = Resources.Load<Sprite>(ubicacionAbuela + "AbuelitaFeliz");
                //rendererBarra.color = alto;
                //posBarra = new Vector3(0, 2.761f, 0);
                //escalaBarra = new Vector3(1.395553f, 0.2241068f, 0);
                
                break;
            case 3:
                spriteAbuela = Resources.Load<Sprite>(ubicacionAbuela + "AbuelitaSeria");
                //rendererBarra.color = medio;
                //posBarra = new Vector3(-0.919f, 2.761f, 0);
                //escalaBarra = new Vector3(1.036599f, 0.2241068f, 0);
                animation.Play("3vidas");
                break;
            case 2:
                spriteAbuela = Resources.Load<Sprite>(ubicacionAbuela + "AbuelitaSeria");
                //rendererBarra.color = medio;
                //posBarra = new Vector3(-1.775f, 2.761f, 0);
                //escalaBarra = new Vector3(0.7022681f, 0.2241068f, 0);
                animation.Play("2vidas");
                break;
            default:
                spriteAbuela = Resources.Load<Sprite>(ubicacionAbuela + "AbuelitaSeria");
                //rendererBarra.color = bajo;
                //posBarra = new Vector3(-2.667f, 2.761f, 0);
                //escalaBarra = new Vector3(0.3537103f, 0.2241068f, 0);
                animation.Play("1vida");
                break;

        }
       
        spriteRendererAbuela.sprite = spriteAbuela;
        //barraPaciencia.transform.position = posBarra;
        //barraPaciencia.transform.localScale = escalaBarra;

        timerCambioEscena = Camera.main.gameObject.AddComponent<Timer>();
        timerCambioEscena.Duration = 5;
        timerCambioEscena.Run();

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
