using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoJacks : MonoBehaviour
{

    float posJacksMin = -8;
    float posJacksMax = 3;
    float posYJacks = -3.4f;
    int cantidadJacks = JacksesUtils.NumeroJacks;
    GameObject[] jacks;
    string prefabLocation = "Microjuegos/Jackses/Prefabs/";

    Vector3 posMesa = new Vector3(0.035f, -2.96f, 0);
    GameObject mesa;

    GameObject bola;
    Bola bolaScript;

    GameObject mano;

    BackwardsTimer timerJuego;
    float duracionJuego = JacksesUtils.Duracion;

    bool tutorial = JacksesUtils.Tutorial;
    GameObject flechaTutorial;
    bool flechaInstanciada = false;

    Fase fase = JacksesUtils.Fase;


    // Start is called before the first frame update
    void Start()
    {
        jacks = new GameObject[cantidadJacks];
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

        mesa = Resources.Load<GameObject>(prefabLocation + "Mesa");
        Instantiate(mesa);
        mesa.transform.position = posMesa;
        mesa.transform.localScale = new Vector3(0.96f, 0.93f, 0);

        timerJuego = gameObject.AddComponent<BackwardsTimer>();
        timerJuego.Duration = duracionJuego;
        HUD.ActualizarTiempo(duracionJuego);
        timerJuego.Run();
    }

    // Update is called once per frame
    void Update()
    {
        jacks = GameObject.FindGameObjectsWithTag("Jack");
        bola = GameObject.FindGameObjectWithTag("Bola");
        if(bola != null)
        {
            bolaScript = bola.GetComponent<Bola>();
        }
        
        if (jacks.Length == 0)
        {
            bolaScript.Agarrable = true;
            if (!flechaInstanciada)
            {
                flechaInstanciada = true;
                flechaTutorial = Resources.Load<GameObject>(prefabLocation + "Flecha Tutorial");
                Instantiate(flechaTutorial);
            }
            
        }
        if (timerJuego.Running)
        {
            HUD.ActualizarTiempo(timerJuego.SecondsRemaining);
            if (bolaScript.Agarrada)
            {
                timerJuego.Stop();
                Destroy(bola);
                if (flechaInstanciada)
                {
                    Destroy(GameObject.FindGameObjectWithTag("flechaTutorial"));
                }
                Invoke("Ganar", timerJuego.SecondsRemaining);              
            }
        }
        if(timerJuego.Finished)
        {
            Perder();
        }
        
    }

    private void Ganar()
    {
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
        }
    }

    private void Perder()
    {
        timerJuego.Stop();
        switch (fase)
        {
            case Fase.FASE1:
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
        }
        
    }

}
