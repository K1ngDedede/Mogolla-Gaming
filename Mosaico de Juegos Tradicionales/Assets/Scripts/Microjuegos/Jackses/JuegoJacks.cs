using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JuegoJacks : MonoBehaviour
{

    float posJacksMin = -8;
    float posJacksMax = 3;
    float posYJacks = -3.4f;
    int cantidadJacks = JacksesUtils.NumeroJacks;
    int jacksRecolectados = 0;
    string prefabLocation = "Microjuegos/Jackses/Prefabs/";

    Vector3 posMesa = new Vector3(0.035f, -2.96f, 0);
    GameObject mesa;

    GameObject bola;

    GameObject mano;

    BackwardsTimer timerJuego;
    float duracionJuego = JacksesUtils.Duracion;

    bool tutorial = JacksesUtils.Tutorial;
    GameObject flechaTutorial;

    Fase fase = JacksesUtils.Fase;


    // Start is called before the first frame update
    void Start()
    {
        EventManagerJackses.AgregarListenerPerderSegundoRebote(InvocarPerder);
        EventManagerJackses.AgregarListenerRevisarVictoria(RevisarVictoria);
        EventManagerJackses.AgregarListenerAgarrarJack(AgarrarJack);

        Cursor.visible = false;
        //sapwnear jacks
        for(int i = 0; i < cantidadJacks; i++)
        {
            float posX = Random.Range(posJacksMin, posJacksMax);
            GameObject jackPrefab = Resources.Load<GameObject>(prefabLocation+"Jack");
            Instantiate(jackPrefab);
            jackPrefab.transform.position = new Vector3(posX, posYJacks, 0);
        }
        

        bola = Resources.Load<GameObject>(prefabLocation + "Bola");
        Instantiate(bola);

        mano = Resources.Load<GameObject>(prefabLocation + "Mano");
        Instantiate(mano);

        if (tutorial)
        {
            flechaTutorial = Resources.Load<GameObject>(prefabLocation + "FlechaTutorial");
            Instantiate(flechaTutorial);
        }
        

        mesa = Resources.Load<GameObject>(prefabLocation + "Mesa");
        Instantiate(mesa);
        mesa.transform.position = posMesa;
        mesa.transform.localScale = new Vector3(0.96f, 0.93f, 0);

        timerJuego = gameObject.AddComponent<BackwardsTimer>();
        //timerJuego = GameObject.FindGameObjectWithTag("ttimer").GetComponent<LeTimer>();
        timerJuego.Duration = duracionJuego;
        HUD.ActualizarTiempo(duracionJuego);
        timerJuego.Run();
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarTiempo();
        if(timerJuego.Finished)
        {
            Perder();
        }
        
    }

    public void RevisarRecoleccion()
    {
        if(jacksRecolectados == cantidadJacks && tutorial)
        {
            GameObject.FindGameObjectWithTag("flechaTutorial").GetComponent<FlechaTutorial>().Habilitar();
        }
    }

    private void RevisarVictoria()
    {
        DeshabilitarJacks();
        float segundosRestantes = timerJuego.SecondsRemaining;
        if(jacksRecolectados == cantidadJacks)
        {
            timerJuego.Stop();
            if (segundosRestantes > 2)
            {
                FadeVolumen(2);
                Invoke("Ganar", 2);
                for (int i = 0; i < 2; i++)
                {
                    Invoke("SpawnPolvora", i);
                }
            }
            else
            {
                Invoke("Ganar", segundosRestantes);
            }
        }
        else
        {
            InvocarPerder();
        }
    }

    private void ActualizarTiempo()
    {
        HUD.ActualizarTiempo(timerJuego.SecondsRemaining);
    }

    private void AgarrarJack()
    {
        jacksRecolectados++;
        RevisarRecoleccion();
    }

    private void DeshabilitarJacks()
    {
        foreach (GameObject jack in GameObject.FindGameObjectsWithTag("Jack"))
        {
            jack.GetComponent<Jack>().DeshabilitarJack();
        }
    }

    private void InvocarPerder()
    {
        DeshabilitarJacks();
        Destroy(GameObject.FindGameObjectWithTag("flechaTutorial"));
        GameObject bola = GameObject.FindGameObjectWithTag("Bola");
        Color color = bola.GetComponent<SpriteRenderer>().color;
        color.a = 0.5f;
        bola.GetComponent<SpriteRenderer>().color = color;
        timerJuego.Stop();
        FadeMusica(2);
        Invoke("Perder", 3);
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


    private void SpawnPolvora()
    {
        GameObject polvora = Resources.Load<GameObject>(prefabLocation + "Polvora");
        float posX = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
        float posY = Random.Range(ScreenUtils.ScreenBottom, ScreenUtils.ScreenTop);
        polvora.transform.position = new Vector3(posX, posY, 0);
        Instantiate(polvora);
    }

    private void Ganar()
    {
        Cursor.visible = true;
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                ManejadorFase1.RegistrarVictoria();
                break;
            case Fase.FASE2:
                ManejadorFase2.AumentarMicrojuegosJugados();
                ManejadorFase2.RevisarFinFase();
                ManejadorFase2.RegistrarVictoria();
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
        Cursor.visible = true;
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.RegistrarPerdidaMicrojuego("Jackses");
                ManejadorFase1.PerderVida();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                break;
            case Fase.FASE2:
                ManejadorFase2.RegistrarPerdidaMicrojuego("Jackses");
                ManejadorFase2.PerderVida();
                ManejadorFase2.AumentarMicrojuegosJugados();
                ManejadorFase2.RevisarFinFase();
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
