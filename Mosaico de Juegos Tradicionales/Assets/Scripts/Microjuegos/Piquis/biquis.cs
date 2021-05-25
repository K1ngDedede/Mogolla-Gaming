using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class biquis : MonoBehaviour
{
    protected const string sPath = "Microjuegos/Piquis/Sprites/";
    protected const string pPath = "Microjuegos/Piquis/Prefabs/";
    protected int jogo = piquisUtils.Jogo;
    protected int fMod = piquisUtils.FMod;
    protected int d = piquisUtils.D;
    protected Fase fase = piquisUtils._Fase;
    protected GameObject[] binguas;
    protected Sprite[] handS;
    protected SpriteRenderer sapasso;
    protected GameObject bate;
    protected Rigidbody2D lmao;
    protected Vector3 p;
    protected BackwardsTimer letimer;
    protected Text temptimer;
    protected int state;
    protected bool hFlag;

    void Start()
    {
        transform.position = new Vector3(3.6f,0.4f,0);
        binguas = new GameObject[jogo];
        GameObject biqui = Resources.Load<GameObject>(pPath + "piqui");
        binguas[0] = Instantiate(biqui);
        float xSigma = Random.Range(-4f, 0f);
        float ySigma = Random.Range(3f, -3f);
        binguas[0].transform.position = new Vector3(xSigma, ySigma, 0);
        for (int sapo = 1; sapo < jogo; sapo++)
        {
            binguas[sapo] = Instantiate(biqui);
            xSigma = Random.Range(-7f, binguas[sapo-1].transform.position.x-1.5f);
            ySigma = Random.Range(binguas[sapo-1].transform.position.y+1.2f, binguas[sapo-1].transform.position.x-1.2f);
            binguas[sapo].transform.position = new Vector3(xSigma, ySigma, 0);
        }

        handS = new Sprite[2];
        handS[0] = Resources.Load<Sprite>(sPath + "manoBate0");
        handS[1] = Resources.Load<Sprite>(sPath + "manoBate1");
        bate = new GameObject();
        bate.transform.localScale = new Vector3(0.8f, 0.8f, 0);
        bate.transform.localPosition = new Vector3(0, 0, -1);
        sapasso = bate.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        sapasso.sprite = handS[0];
        sapasso.sortingOrder = jogo+1;
        
        letimer = gameObject.AddComponent(typeof(BackwardsTimer)) as BackwardsTimer;
        letimer.Duration = d;
        GameObject tt = GameObject.FindGameObjectWithTag("temptimer");
        temptimer = tt.GetComponent<Text>();
        temptimer.text = "lmao";
        lmao = gameObject.GetComponent<Rigidbody2D>();
        letimer.Run();
        hFlag = false;
        state = 0;
    }
    
    void Update()
    {
        temptimer.text = letimer.SecondsRemaining.ToString();
        //la mano apunta al cursor
        boundHand();
        //c dispara
        if (Input.GetMouseButtonDown(0) && state==0 && !MenuPausa.pausado)
        {
            Vector3 sP = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 d = (Vector3)(Input.mousePosition-sP);
            d.Normalize();
            state++;
            hFlag = true;
            sapasso.sprite = handS[1];
            lmao.AddForce((d)*fMod,ForceMode2D.Force);
        }
        //Se gana cuando todas las piquis hayan colisionado
        if (state == jogo + 2 && letimer.Running)
        {
            letimer.Stop();
            returnVic();
        }
        //Se pierde si se acaba el tiempo
        else if (letimer.Finished && state>=0)
        {
            returnDef();
        }
        //fiche como arreglo el bug de las potas
        if (!hFlag && state > 0)
        {
            state = 0;
        }
    }
    
    private void boundHand()
    {
        if (state == 0 && !MenuPausa.pausado)
        {
            p = Input.mousePosition;
            p.z = -Camera.main.transform.position.z;
            p = Camera.main.ScreenToWorldPoint(p);
            bate.transform.position = p;
            float r = 3f;
            float d = Vector3.Distance(transform.position, bate.transform.position);
        
            Vector3 chain = bate.transform.position - transform.position;
            chain *= r / d;
            bate.transform.position = transform.position - chain;

        
            bate.transform.right = transform.position - bate.transform.position;
            bate.transform.Rotate(Vector3.forward, -90);
        }
    }

    public void colDetection()
    {
        state++;
    }
    
    private void FadeVolumen(float duracionFade)
    {
        GameObject musica = GameObject.FindGameObjectWithTag("musica");
        StartCoroutine(FadeAudioSource.StartFadeVolumen(musica.GetComponent<AudioSource>(), duracionFade, 0));
    }

    private void returnDef()
    {
        state = -1;
        print("perdió");
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.RegistrarPerdidaMicrojuego("Piquis");
                ManejadorFase1.PerderVida();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                break;
            case Fase.FASE2:
                ManejadorFase2.RegistrarPerdidaMicrojuego("Piquis");
                ManejadorFase2.PerderVida();
                ManejadorFase2.AumentarMicrojuegosJugados();
                ManejadorFase2.RevisarFinFase();
                break;
            case Fase.FASE3:
                ManejadorFase3.RegistrarPerdidaMicrojuego("Piquis");
                ManejadorFase3.PerderVida();
                ManejadorFase3.AumentarMicrojuegosJugados();
                ManejadorFase3.RevisarFinFase();
                break;
            case Fase.MODOLIBRE:
                ManejadorModoLibre.Perder();
                break;
        }
    }

    private void returnVic()
    {
       print("victoria"); 
       //hacer diciente la victoria aca
       
       FadeVolumen(3);
       Invoke("returnVic2", 3);
    }
    
    private void returnVic2()
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
                piquisUtils.loop();
                ManejadorFase3.AumentarMicrojuegosJugados();
                ManejadorFase3.RevisarFinFase();
                ManejadorFase3.RegistrarVictoria();
                break;
            case Fase.MODOLIBRE:
                ManejadorModoLibre.Ganar();
                break;
        }
    }
}
