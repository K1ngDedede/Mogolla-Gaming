using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rana : MonoBehaviour
{
    
    BackwardsTimer timer;
    int duracion = RanaUtils.Duracion;

    int numeroAros = RanaUtils.NumeroAros;
    Vector2 posInicialAros = new Vector2(-8, -4);
    float offsetAros = 0.8f;
    string pathPrefabs = "Microjuegos/Rana/Sprites/";
    List<GameObject> aros = new List<GameObject>();
    string tagAros = "Bola";

    int disparos = 0;
    int puntaje = 0;
    int puntajeRequerido = RanaUtils.PuntajeRequerido;

    Fase fase = RanaUtils.Fase;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerarAros();
        timer = gameObject.AddComponent<BackwardsTimer>();
        timer.Duration = duracion;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarReloj();
        RevisarFinTimer();
        if (timer.Finished)
        {
            RevisarVictoria();
        }
    }

    private void RevisarVictoria()
    {
        if(puntaje >= puntajeRequerido)
        {
            Ganar();
        }
    }

    private void RevisarFinTimer()
    {
        if(timer.Finished && puntaje < puntajeRequerido)
        {
            Perder();
        }
    }

    public void InvocarRevisarFinAros()
    {
        if (timer.SecondsRemaining > 2 && disparos == numeroAros)
        {
            Invoke("RevisarFinAros", 2);
        }
    }

    private void RevisarFinAros()
    {
        float segundos = timer.SecondsRemaining;
        timer.Stop();
        if (puntaje < puntajeRequerido)
        {
            FadeMusica(2);
            Invoke("Perder", 3);
        }
        else
        {
            FadeVolumen(2);
            Invoke("Ganar", 3);
        }
    }

    public void AumentarPuntaje(int aumentoPuntaje)
    {
        puntaje += aumentoPuntaje;
    }

    private void ActualizarReloj()
    {
        if (timer.Running)
        {
            HUDRana.ActualizarTiempo(timer.SecondsRemaining);
        }
    }

    public void RevisarDisparo() 
    {
            disparos++;
            Destroy(GameObject.FindGameObjectWithTag(tagAros));
    }

    private void GenerarAros()
    {
        Sprite spriteAro;
        GameObject aro;
        for (int i = 0; i < numeroAros; i++)
        {
            aro = new GameObject();
            spriteAro = Resources.Load<Sprite>(pathPrefabs + "aroRana");
            aro.AddComponent<SpriteRenderer>();
            aro.GetComponent<SpriteRenderer>().sprite = spriteAro;
            aro.GetComponent<SpriteRenderer>().sortingOrder = i;
            aro.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            aro.transform.position = posInicialAros;
            aro.tag = tagAros;
            posInicialAros.x += offsetAros;
            //Instantiate(aro);
            aros.Add(aro);
        }
    }

    private void FadeMusica(float duracionFade)
    {
        GameObject musica = GameObject.FindGameObjectWithTag("musica");
        StartCoroutine(FadeAudioSource.StartFade(musica.GetComponent<AudioSource>(), duracionFade, 0));
    }

    private void FadeVolumen(float duracionFade)
    {
        GameObject musica = GameObject.FindGameObjectWithTag("musica");
        StartCoroutine(FadeAudioSource.StartFadeVolumen(musica.GetComponent<AudioSource>(), duracionFade, 0));
    }

    private void Ganar()
    {
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.RegistrarVictoria();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                break;
            case Fase.FASE2:
                //llamar manejador de fase 2
                break;
            case Fase.FASE3:
                //llamar manejador de fase 3
                break;
            case Fase.MODOLIBRE:
                ManejadorModoLibre.Ganar();
                break;
        }
    }

    private void Perder()
    {
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.RegistrarPerdidaMicrojuego("Rana");
                ManejadorFase1.PerderVida();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                break;
            case Fase.FASE2:
                //llamar manejador de fase 2
                break;
            case Fase.FASE3:
                //llamar manejador de fase 3
                break;
            case Fase.MODOLIBRE:
                ManejadorModoLibre.Perder();
                break;
        }
    }
}
