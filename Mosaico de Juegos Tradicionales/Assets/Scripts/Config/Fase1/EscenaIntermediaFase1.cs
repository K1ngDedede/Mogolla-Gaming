using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscenaIntermediaFase1 : MonoBehaviour
{
    string ubicacionAbuela = "Cutscene/Fase1/";
    string nombreSiguienteMicrojuego;
    Text textoPirinola;
    Text textoAbuela;
    string escenaACargar;
    Timer timerCambioEscena;
    string[] dialogos = new string[]{"Ya me va a sacar la piedra...", "Se me está agotando la paciencia...", "No importa, siga intentando" };
    string dialogo;
    float duracionCaracter = 0.1f;

    //datos de la barra medidora
    Color alto = new Color(0.65098f, 0.690196f, 0.141176f), medio = new Color(0.97254f, 0.952941f, 0.6196f), bajo = new Color(0.333333f, 0.22745f, 0.196078f);

    private void Awake()
    {
        timerCambioEscena = Camera.main.gameObject.AddComponent<Timer>();
        timerCambioEscena.Duration = 5;
        timerCambioEscena.Run();
    }

    // Start is called before the first frame update
    void Start()
    {
        int vidasRestantes = ConfigFase1Utils.VidasRestantes;
        NombreMicrojuego siguienteMicrojuego = ConfigFase1Utils.MicrojuegosAJugar[ConfigFase1Utils.NumMicrojuegosJugados];
        DatosSiguienteMicrojuego(siguienteMicrojuego);
        textoPirinola = GameObject.FindGameObjectWithTag("TextoPirinola").GetComponent<Text>();
        textoPirinola.text = nombreSiguienteMicrojuego;
        textoAbuela = GameObject.FindGameObjectWithTag("textoJuego").GetComponent<Text>();
        if (vidasRestantes < 4)
        {
            dialogo = dialogos[vidasRestantes - 1];
            if (ConfigFase1Utils.AcabaDePerder)
            {
                StartCoroutine("Escribir");
            }
        }
        

        //Barra medidora de paciencia
        GameObject barraPaciencia = GameObject.FindGameObjectWithTag("barraPaciencia");
        SpriteRenderer rendererBarra = barraPaciencia.GetComponent<SpriteRenderer>();
        Animation animation = barraPaciencia.GetComponent<Animation>();
        

        //Apariencia abuela
        GameObject abuela = GameObject.FindGameObjectWithTag("abuela");
        Sprite spriteAbuela;
        SpriteRenderer spriteRendererAbuela = abuela.GetComponent<SpriteRenderer>();
        Vector3 escalaBarra = Vector3.zero;
        switch (vidasRestantes)
        {
            case 4:
                spriteAbuela = Resources.Load<Sprite>(ubicacionAbuela + "AbuelitaFeliz");
                break;
            case 3:
                spriteAbuela = Resources.Load<Sprite>(ubicacionAbuela + "AbuelitaSeria");
                if (ConfigFase1Utils.AcabaDePerder)
                {
                    animation.Play("3vidas");
                }
                else
                {
                    rendererBarra.color = medio;
                    escalaBarra = new Vector3(1.045294f, 0.2241068f, 1);
                }

                break;
            case 2:
                if (ConfigFase1Utils.AcabaDePerder)
                {
                    animation.Play("2vidas");
                }
                else
                {
                    rendererBarra.color = medio;
                    escalaBarra = new Vector3(0.6890782f, 0.2241068f, 0);
                }
                spriteAbuela = Resources.Load<Sprite>(ubicacionAbuela + "AbuelitaSeria");
                break;
            default:
                if (ConfigFase1Utils.AcabaDePerder)
                {
                    animation.Play("1vida");
                }
                else
                {
                    rendererBarra.color = bajo;
                    escalaBarra = new Vector3(0.3427572f, 0.2241068f, 0);
                }
                spriteAbuela = Resources.Load<Sprite>(ubicacionAbuela + "AbuelitaSeria");
                break;

        }
       
        spriteRendererAbuela.sprite = spriteAbuela;
        if(escalaBarra != Vector3.zero)
        {
            barraPaciencia.transform.localScale = escalaBarra;
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

    IEnumerator Escribir()
    {
        foreach (char c in dialogo)
        {
            textoAbuela.text += c;
            yield return new WaitForSeconds(duracionCaracter);
        }
    }
}
