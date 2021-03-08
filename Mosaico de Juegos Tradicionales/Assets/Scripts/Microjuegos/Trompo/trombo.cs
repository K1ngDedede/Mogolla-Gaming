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

    private BackwardsTimer n;

    private Text temptimer;

    private BGScroller bg;

    private float torqueR = TrompoUtils.TorqueR;

    private float torqueP = TrompoUtils.TorqueP;

    protected Fase fase = TrompoUtils.Fase;

    void Start()
    {
        vCond = 0;
        sapo = gameObject.GetComponent<Rigidbody2D>();
        sapo.centerOfMass = new Vector2(0, -2.2f);
        sapo.freezeRotation = false;
        gameObject.AddComponent(typeof(BackwardsTimer));
        n = gameObject.GetComponent<BackwardsTimer>();
        n.Duration = TrompoUtils.Duracion;
        GameObject tt = GameObject.FindGameObjectWithTag("temptimer");
        temptimer = tt.GetComponent<Text>();
        temptimer.text = "10";
        GameObject bgObject = GameObject.FindGameObjectWithTag("bg");
        bg = bgObject.GetComponent<BGScroller>();
        n.Run();
    }


    void Update()
    {
        temptimer.text = n.SecondsRemaining.ToString();
        if (vCond == 0)
        {
            //Torque aleatorio
            float sapasso = Random.Range(-torqueP, torqueP);
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
        Invoke("returnDef",3);
    }

    protected void returnDef()
    {
        //Invocar al manejador de fase
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

    protected void returnVict()
    {
        vCond = 1;
        sapo.freezeRotation = true;
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



