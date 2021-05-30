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
    string ubicacion = "Cutscene/Fase3/";
    Sprite cuatroVidas, tresVidas, dosVidas, unaVida;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        timerCambioEscena = Camera.main.gameObject.AddComponent<Timer>();
        timerCambioEscena.Duration = 5;
        timerCambioEscena.Run();
        cuatroVidas = Resources.Load<Sprite>(ubicacion + "Gradas1");
        tresVidas = Resources.Load<Sprite>(ubicacion + "Gradas2");
        dosVidas = Resources.Load<Sprite>(ubicacion + "Gradas3");
        unaVida = Resources.Load<Sprite>(ubicacion + "Gradas4");
        spriteRenderer = GameObject.FindGameObjectWithTag("barraPaciencia").GetComponent<SpriteRenderer>();
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


        switch (vidasRestantes)
        {
            case 3:
                spriteRenderer.sprite = tresVidas;
                break;
            case 2:
                spriteRenderer.sprite = dosVidas;
                break;
            case 1:
                spriteRenderer.sprite = unaVida;
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
