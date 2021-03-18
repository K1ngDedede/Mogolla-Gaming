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

    private LeTimer n;

    private Text temptimer;

    private BGScroller bg;

    private sHand sh;

    private float prevs;

    private float torqueR = TrompoUtils.TorqueR;

    private float torqueP = TrompoUtils.TorqueP;

    protected Fase fase = TrompoUtils.Fase;

    protected bool teach = TrompoUtils.Teach;
    

    void Start()
    {
        vCond = 0;
        sapo = gameObject.GetComponent<Rigidbody2D>();
        sapo.centerOfMass = new Vector2(0, -2.2f);
        sapo.freezeRotation = false;
        gameObject.AddComponent(typeof(BackwardsTimer));
        n = GameObject.FindGameObjectWithTag("ttimer").GetComponent<LeTimer>();
        n.Duration = TrompoUtils.Duracion;
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

        prevs = Mathf.Sign(gameObject.transform.eulerAngles.z);
        n.Run();
    }


    void Update()
    {
        temptimer.text = n.SecondsRemaining().ToString();
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
            if (Input.GetMouseButton(0))
            {
                float xinput = Input.mousePosition.x - ((float) Screen.width / 2) < gameObject.transform.position.x
                    ? 0.05f
                    : -0.05f;
                sapo.AddTorque(xinput, ForceMode2D.Impulse);
            }
            //Condición de victoria
            if (n.Finished() && vCond == 0)
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
        Invoke("returnDef",n.SecondsRemaining());
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
    
}



