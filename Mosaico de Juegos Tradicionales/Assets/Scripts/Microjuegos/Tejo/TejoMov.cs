﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TejoMov : MonoBehaviour
{
    bool thrown;
    float diffInSeconds;
    float dateTime1;
    PowerBar bar;
	public static bool gana = false;
	public bool pierde = false;
	int counter = TejoUtils.counter;
	float x1 = TejoUtils.x1;
	float x2 = TejoUtils.x2;
	float y1 = TejoUtils.y1;
	float y2 = TejoUtils.y2;
	Fase fase = TejoUtils.Fase;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void setBar(GameObject go)
    {
        bar = go.GetComponent<PowerBar>();
    }

    public void Throw(float degree, float thrust)
    {
        Vector2 dir = (Quaternion.Euler(0, 0, degree) * Vector2.up);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().AddForce(dir * (thrust * 0.215f), ForceMode2D.Impulse);
        thrown = true;
        dateTime1 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		
        if (thrown && !MenuPausa.pausado)
        {
            transform.localScale = transform.localScale * 0.997f;
            diffInSeconds = (Time.time - dateTime1);
            if (diffInSeconds >= 1.5)
            {
                thrown = false;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                Vector3 pos = transform.position;
                if (pos.x < x1 && pos.x > x2 && pos.y < y1 && pos.y > y2)
                {
					ganaTejo(); 
					Debug.Log("Mecha");
					PowerBar.gana = true;
					GameControl.disabled = false;
                    Invoke("Ganar", PowerBar.n.SecondsRemaining);
                }
                else
                {
                    Destroy(GetComponent<Rigidbody2D>());
                    Destroy(GetComponent<CircleCollider2D>());
                    bar.Res();
                }
            }
        }
		if(PowerBar.n.Finished && PowerBar.gana == false && PowerBar.countT == 0)
        {
			PowerBar.countT++;
			Perder();
			
        }
    }
	
	private void ganaTejo(){
		gana = true;
	}
	private void Ganar()
    {
        switch (fase)
        {
            case Fase.FASE1:
				ManejadorFase1.RegistrarVictoria();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
				Cursor.visible = true;
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
        //timerJuego.Stop();
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
}
