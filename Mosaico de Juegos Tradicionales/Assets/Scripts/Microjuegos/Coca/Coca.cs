using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coca : MonoBehaviour
{
    int duracion = CocaUtils.Duracion;
    BackwardsTimer timer;
    Fase fase = CocaUtils.Fase;
    bool fade = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<BackwardsTimer>();
        timer.Duration = duracion;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Running)
        {
            float secondsRemaining = timer.SecondsRemaining;
            HUD.ActualizarTiempo(secondsRemaining);
            if (secondsRemaining <= 2 && !fade)
            {
                fade = true;
                FadeVolumen(secondsRemaining);
            }
        }
        if (timer.Finished)
        {
            Perder();
        }
    }

    public void Encholar()
    {
        float segundosRestantes = timer.SecondsRemaining;
        timer.Stop();
        if (segundosRestantes > 3)
        {
            FadeVolumen(2);
            Invoke("Ganar", 3);
        }
        else
        {
            Invoke("Ganar", segundosRestantes);
        }
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
                ManejadorFase2.AumentarMicrojuegosJugados();
                ManejadorFase2.RevisarFinFase();
                ManejadorFase2.RegistrarVictoria();
                break;
            case Fase.FASE3:
                CocaUtils.AumentarDificultad();
                ManejadorFase3.AumentarMicrojuegosJugados();
                ManejadorFase3.RevisarFinFase();
                ManejadorFase3.RegistrarVictoria();
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
                ManejadorFase1.RegistrarPerdidaMicrojuego("Coca");
                ManejadorFase1.PerderVida();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                break;
            case Fase.FASE2:
                ManejadorFase2.RegistrarPerdidaMicrojuego("Coca");
                ManejadorFase2.PerderVida();
                ManejadorFase2.AumentarMicrojuegosJugados();
                ManejadorFase2.RevisarFinFase();
                break;
            case Fase.FASE3:
                ManejadorFase3.RegistrarPerdidaMicrojuego("Coca");
                ManejadorFase3.PerderVida();
                ManejadorFase3.AumentarMicrojuegosJugados();
                ManejadorFase3.RevisarFinFase();
                break;
            case Fase.MODOLIBRE:
                ManejadorModoLibre.Perder();
                break;
        }
    }
}
