using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoJacks : MonoBehaviour
{

    float posJacksMin = -8;
    float posJacksMax = 3;
    float posYJacks = -3.4f;
    int cantidadJacks = 10;
    bool victoria = false;
    GameObject[] jacks;
    string prefabLocation = "Microjuegos/Jackses/Prefabs/";

    Vector3 posMesa = new Vector3(0.035f, -2.96f, 0);
    GameObject mesa;

    GameObject bola;
    Bola bolaScript;

    GameObject mano;

    bool empezo = false;
    BackwardsTimer timerJuego;
    float duracionJuego = 20;

    public bool Victoria
    {
        get { return victoria; }
    }

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
    }

    // Update is called once per frame
    void Update()
    {
        bola = GameObject.FindGameObjectWithTag("Bola");
        bolaScript = bola.GetComponent<Bola>();
        
        if (!empezo && bolaScript.Soltado)
        {
            jacks = GameObject.FindGameObjectsWithTag("Jack");
            empezo = true;
            BloquearJacks(true, jacks);
            timerJuego.Run();
            
        }
        if(empezo && !bolaScript.Soltado)
        {
            jacks = GameObject.FindGameObjectsWithTag("Jack");
            BloquearJacks(false, jacks);
        }
        if (bolaScript.Soltado)
        {
            jacks = GameObject.FindGameObjectsWithTag("Jack");
            BloquearJacks(true, jacks);
        }
        if (bolaScript.SegundoRebote || timerJuego.Finished)
        {
            victoria = false;
            empezo = false;
            bolaScript.Detener();
            timerJuego.Stop();
            HUD.Perder();
            jacks = GameObject.FindGameObjectsWithTag("Jack");
            BloquearJacks(false, jacks);
        }
        if(HUD.jacksRecolectados == cantidadJacks && !bolaScript.Soltado && !bolaScript.SegundoRebote)
        {
            empezo = false;
            bolaScript.Detener();
            timerJuego.Stop();
            HUD.Ganar();
        }
        if (timerJuego.Running)
        {
            HUD.ActualizarTiempo(timerJuego.SecondsRemaining);
        }
        
    }

    private void BloquearJacks(bool bloqueo, GameObject[] jacks)
    {
        foreach (GameObject jack in jacks)
        {
            jack.GetComponent<Jack>().EnJuego = bloqueo;
        }
    }
}
