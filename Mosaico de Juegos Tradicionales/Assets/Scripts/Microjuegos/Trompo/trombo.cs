using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class trombo : MonoBehaviour
{

    private Rigidbody2D sapo;

    private int vCond;

    private float sapasso;

    private BackwardsTimer n;

    private Text temptimer;

    private BGScroller bg;

    private sHand sh;

    private float prevs;

    private float torqueR = TrompoUtils.TorqueR;

    private float torqueP = TrompoUtils.TorqueP;

    protected Fase fase = TrompoUtils.Fase;

    protected bool teach = TrompoUtils.Teach;
    
    protected Vector3 movTarget = Vector3.zero;

    protected int mov = TrompoUtils.Mov;

    protected Transform papa;
    

    void Start()
    {
        vCond = 0;
        sapo = gameObject.GetComponent<Rigidbody2D>();
        sapo.centerOfMass = new Vector2(0, -2.2f);
        sapo.freezeRotation = false;
        gameObject.AddComponent(typeof(BackwardsTimer));
        n = gameObject.AddComponent<BackwardsTimer>();
        n.Duration = 12;
        GameObject tt = GameObject.FindGameObjectWithTag("temptimer");
        temptimer = tt.GetComponent<Text>();
        temptimer.text = "lmao";
        GameObject bgObject = GameObject.FindGameObjectWithTag("bg");
        bg = bgObject.GetComponent<BGScroller>();
        if (teach)
        {
            //línea de guia
            GameObject vert = new GameObject("vert");
            vert.AddComponent(typeof(SpriteRenderer));
            vert.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Microjuegos/Trompo/Sprites/vert");
            vert.transform.position = new Vector3(0,-2,0);
            vert.transform.localScale = new Vector3(1, 2, 1);
            //las manos de fermin
            sh = gameObject.AddComponent(typeof(sHand)) as sHand;
            //impulso inicial
            sapo.AddTorque(0.18f, ForceMode2D.Impulse);
        }
        papa = transform.parent;
        movTarget = papa.position;
        switch (mov)
        {
            case 1:
                movTarget.x = 2.5f;
                break;
            case 2:
                movTarget.x = Random.Range(-2.5f, 2.5f);
                break;
            default:
                movTarget=Vector3.zero;
                break;
        }
        prevs = Mathf.Sign(gameObject.transform.eulerAngles.z);
        n.Run();
    }


    void Update()
    {
        temptimer.text = n.SecondsRemaining.ToString();
        if (vCond == 0)
        {
            if (!teach)
            {
                //Torque aleatorio
                sapasso = Random.Range(-torqueP, torqueP); 
            }
            else if(Mathf.Sign(gameObject.transform.rotation.z)!=prevs)
            {
                //Las manos de fermín
                sh.switchHand();
                prevs = Mathf.Sign(gameObject.transform.rotation.z);
            }
            if (sapasso >= -torqueR && sapasso <= torqueR)
            {
                sapo.AddTorque(sapasso, ForceMode2D.Impulse);
            }
            //Input del usuario
            if (Input.GetMouseButton(0) && !MenuPausa.pausado)
            {
                Vector3 p = Input.mousePosition;
                p.z = -Camera.main.transform.position.z;
                p = Camera.main.ScreenToWorldPoint(p);
                float xinput = p.x < transform.position.x
                    ? 0.05f
                    : -0.05f;
                sapo.AddTorque(xinput, ForceMode2D.Impulse);
            }
            //El trompo se mueve en dificultades avanzadas
            if (mov > 0)
            {
                if (Vector3.Distance(papa.position, movTarget) != 0)
                {
                    papa.position = Vector3.MoveTowards(papa.position, movTarget, Time.deltaTime*0.5f*mov);
                }
                else
                {
                    movTarget.x = mov == 1 ? -Math.Sign(movTarget.x) * 2.5f : Random.Range(0, -Math.Sign(movTarget.x) * 2.5f);
                }

                
            }
            //Condición de victoria
            if (n.Finished && vCond == 0)
            {
                returnVict();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        vCond = -1;
        n.Stop();
        //aplicar fondo de derrota
        bg.halt();
        //parar manos, si las hay
        if(teach) sh.halt();
        FadeMusica(2);
        Invoke("returnDef",3);
    }
    
    private void FadeMusica(int duracionFade)
    {
        GameObject musica = GameObject.FindGameObjectWithTag("musica");
        StartCoroutine(FadeAudioSource.StartFade(musica.GetComponent<AudioSource>(), duracionFade, 0));
    }

    protected void returnDef()
    {
        //Invocar al manejador de fase
        switch (fase)
        {
            case Fase.FASE1:
                if (teach)
                {
                    ConfigFase1Utils.AumentarIntentosTutorial();
                    ManejadorFase1.ReintentarTutorial();
                }
                else
                {
                    ManejadorFase1.RegistrarPerdidaMicrojuego("Trompo");   
                    ManejadorFase1.PerderVida();
                    ManejadorFase1.AumentarMicrojuegosJugados();
                    ManejadorFase1.RevisarFinFase();
                }
                
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

    protected void returnVict()
    {
        vCond = 1;
        sapo.freezeRotation = true;
        if (teach)
        {
            sh.halt();
            TrompoUtils.facilito();
            ManejadorFase1.ExplicacionPirinola();
        }
        else
        {
            
            //Invocar al manejador de fase
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
        
    }
    
}



