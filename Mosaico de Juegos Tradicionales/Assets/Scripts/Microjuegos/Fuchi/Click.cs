﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Click : MonoBehaviour
{

    float thrust = FuchiUtils.thrust;
    int counter = FuchiUtils.counter;
	//private LeTimer n;
	private BackwardsTimer n;
	private Text temptimer;
    //private float rot = 0.0f;
	float x0 = FuchiUtils.x0;
	float x1 = FuchiUtils.x1;
	float y0 = FuchiUtils.y0;
	float y1 = FuchiUtils.y1;
	Fase fase = FuchiUtils.Fase;
	float startingTime = FuchiUtils.startingTime;
	float currentTime = FuchiUtils.currentTime;

	bool fuchiHabilitado = true;
    bool juegoGanado = false;

	//Texto toques
	Text textoToques;
	int toquesMinimos = 6;
	
	void Start(){
		//texto toques
		textoToques = GameObject.FindGameObjectWithTag("textoToques").GetComponent<Text>();
		textoToques.text = "Toques: " + counter + "/" + toquesMinimos;
        GameControlScript.disabled = true;
        GameControlScript.disabled2 = false;
		GameControlScript.disabled = true;
		//n = GameObject.FindGameObjectWithTag("ttimer").GetComponent<LeTimer>();
		n = gameObject.AddComponent<BackwardsTimer>();
		n.Duration = FuchiUtils.startingTime;
		//currentTime = startingTime;
		GameObject tt = GameObject.FindGameObjectWithTag("RelojitoTimer");
        temptimer = tt.GetComponent<Text>();
		n.Run();
		
	}
	
    void Update()
	{
		//temptimer.text = n.SecondsRemaining().ToString()+"s";
		GameObject tt = GameObject.FindGameObjectWithTag("RelojitoTimer");
		temptimer = tt.GetComponent<Text>();
		temptimer.text = n.SecondsRemaining.ToString()+"s";
		//currentTime -= 1*Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && fuchiHabilitado && !MenuPausa.pausado)
        {
			GameControlScript.disabled2 = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
			
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                counter++;
				textoToques = GameObject.FindGameObjectWithTag("textoToques").GetComponent<Text>();
				textoToques.text = "Toques: " + counter + "/" + toquesMinimos;
				if (counter >= toquesMinimos && !juegoGanado)
                {
                    juegoGanado = true;
					//Debug.Log(currentTime);
					GameControlScript.disabled = false;
					Debug.Log("GameControlScript.disabled");
					Invoke("Ganar",2);
                    FadeVolumen(2);
					Debug.Log("Victoria");
					//
					//}
					
                }
                float x = Random.Range(x0, x1);
                float y = Random.Range(y0, y1);
				hit.collider.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
                hit.collider.attachedRigidbody.AddForce(new Vector2(x, y).normalized * thrust, ForceMode2D.Impulse);
                hit.collider.attachedRigidbody.angularVelocity = Random.Range(-350.5f, 350.0f);
            }
        }
        if (n.Finished && counter< toquesMinimos)
        {
			Perder();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Abajo" && GameControlScript.disabled == true)
        {

			//GameControlScript.disabled2 = false;
			fuchiHabilitado = false;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            this.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
			n.Stop();
			//if(currentTime <= 0f){
			//Perder();
			//Invoke("Perder",n.SecondsRemaining());
			//Invoke("Perder",n.SecondsRemaining);
			FadeMusica(2);
			Invoke("Perder", 3);
			Debug.Log("Fin");
			//}
			
        }
    }
	
	private void Ganar()
    {
        Cursor.visible = true;
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
                FuchiUtils.IncrementarDificultad();
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
        GameObject musica = GameObject.FindGameObjectWithTag("musica");
        Destroy(musica);
        Cursor.visible = true;
        //timerJuego.Stop();
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.RegistrarPerdidaMicrojuego("Fuchi");
                ManejadorFase1.PerderVida();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                break;
            case Fase.FASE2:
                ManejadorFase2.RegistrarPerdidaMicrojuego("Fuchi");
                ManejadorFase2.PerderVida();
                ManejadorFase2.AumentarMicrojuegosJugados();
                ManejadorFase2.RevisarFinFase();
                break;
            case Fase.FASE3:
                ManejadorFase3.RegistrarPerdidaMicrojuego("Fuchi");
                ManejadorFase3.PerderVida();
                ManejadorFase3.AumentarMicrojuegosJugados();
                ManejadorFase3.RevisarFinFase();
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