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
    Timer timer, timerCambioEscena;
    // Start is called before the first frame update
    void Start()
    {
        Microjuego siguienteMicrojuego = ConfigFase1Utils.MicrojuegosAJugar[ConfigFase1Utils.NumMicrojuegosJugados];
        DatosSiguienteMicrojuego(siguienteMicrojuego);
        textoPirinola = GameObject.FindGameObjectWithTag("TextoPirinola").GetComponent<Text>();
        textoPirinola.text = "";

        //Apariencia abuela
        GameObject abuela = GameObject.FindGameObjectWithTag("abuela");
        Sprite spriteAbuela;
        SpriteRenderer spriteRendererAbuela = abuela.GetComponent<SpriteRenderer>(); ;
        if(ConfigFase1Utils.VidasRestantes == ConfigFase1Utils.VidasTotales)
        {
            spriteAbuela = Resources.Load<Sprite>(ubicacionAbuela + "AbuelitaFeliz");
        }
        else
        {
            spriteAbuela = Resources.Load<Sprite>(ubicacionAbuela + "AbuelitaSeria");
        }
        spriteRendererAbuela.sprite = spriteAbuela;

        //Animacion
        timer = Camera.main.gameObject.AddComponent<Timer>();
        timer.Duration = 3;
        timer.Run();

        timerCambioEscena = Camera.main.gameObject.AddComponent<Timer>();
        timerCambioEscena.Duration = 5;
        timerCambioEscena.Run();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            textoPirinola = GameObject.FindGameObjectWithTag("TextoPirinola").GetComponent<Text>();
            textoPirinola.text = nombreSiguienteMicrojuego;
        }
        if (timerCambioEscena.Finished)
        {
            SceneManager.LoadScene(escenaACargar);
        }
    }

    private void DatosSiguienteMicrojuego(Microjuego microjuego)
    {
        if (microjuego == Microjuego.Jackses)
        {
            nombreSiguienteMicrojuego = "Jackses";
            escenaACargar = "jackses";
        }
        else if (microjuego == Microjuego.Trompo)
        {
            nombreSiguienteMicrojuego = "Trompo";
            escenaACargar = "Trompo";
        }
        else if (microjuego == Microjuego.Fuchi)
        {
            nombreSiguienteMicrojuego = "Fuchi";
			escenaACargar = "Fuchi";
            //cargar escena de fuchi
        }
    }
}
