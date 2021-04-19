using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YermisAtaque : MonoBehaviour
{
    //Tiempo
    float duracion = 8;
    BackwardsTimer timer;

    int disparosTotales = YermisUtils.DisparosAtaque;
    int disparosDisponibles;

    int numeroBlancos = YermisUtils.NumeroBlancosAtaque;
    string ubicacionPrefabs = "Microjuegos/Yermis/Prefabs/";

    Fase fase = YermisUtils.Fase;
    // Start is called before the first frame update
    void Start()
    {
        //inicializar temporizador
        timer = gameObject.AddComponent<BackwardsTimer>();
        timer.Duration = duracion;

        disparosDisponibles = disparosTotales;
        HUDYermisAtaque.ActualizarDisparos(disparosTotales, disparosDisponibles);

        //Cargar blancos
        GameObject persona;
        for(int i = 0; i < numeroBlancos; i++)
        {
            persona = Resources.Load<GameObject>(ubicacionPrefabs + "Persona");
            Instantiate(persona);
        }

        //correr temporizador
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Running)
        {
            ActualizarTiempo();
        }
        if (!MenuPausa.pausado)
        {
            RevisarDisparo();
        }
        RevisarPonchados();
    }

    private void ActualizarTiempo()
    {
        HUDYermisAtaque.ActualizarTiempo(timer.SecondsRemaining);
    }

    private void RevisarDisparo()
    {
        if (Input.GetMouseButtonDown(0) && disparosDisponibles > 0)
        {
            GameObject.FindGameObjectWithTag("flechaRotatoria").GetComponent<FlechaMouse>().DispararBola();
            disparosDisponibles--;
            HUDYermisAtaque.ActualizarDisparos(disparosTotales, disparosDisponibles);
        }
    }

    private void RevisarPonchados()
    {
        GameObject[] personas = GameObject.FindGameObjectsWithTag("personaYermis");
        int ponchados = 0;
        foreach(GameObject persona in personas)
        {
            if (persona.GetComponent<PersonaYermis>().Ponchado)
            {
                ponchados++;
            }
        }
        if(timer.Running && ponchados == numeroBlancos)
        {
            timer.Stop();
            float segundosRestantes = timer.SecondsRemaining;
            if (segundosRestantes > 2)
            {
                FadeVolumen(2);
                Invoke("Ganar", 2);
            }
            else
            {
                Invoke("Ganar", segundosRestantes);
            }
        }
        if(timer.Finished && ponchados < numeroBlancos)
        {
            Perder();
        }
    }

    private void FadeVolumen(float duracionFade)
    {
        GameObject musica = GameObject.FindGameObjectWithTag("musica");
        StartCoroutine(FadeAudioSource.StartFadeVolumen(musica.GetComponent<AudioSource>(), duracionFade, 0));
    }

    private void Ganar()
    {
        GameObject musica = GameObject.FindGameObjectWithTag("musica");
        Destroy(musica);
        switch (fase)
        {
            case Fase.FASE1:
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
        GameObject musica = GameObject.FindGameObjectWithTag("musica");
        Destroy(musica);
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.RegistrarPerdidaMicrojuego("YermisAtaque");
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
