using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TejoUtils 
{
	public static float x1 = 1.1f;
	public static float x2 = -1.1f;
	public static float y1 = 1.5f;
	public static float y2 = -0.2f;
    public static int counter = 5;
	public static float currentTime = 0f;
	public static float startingTime = 16f;
    static bool tutorial = false;
    static Fase fase = Fase.FASE1;
    static float tiempoRestante = 0;

    public static float TiempoRestante
    {
        set { tiempoRestante = value; }
        get { return tiempoRestante; }
    }


    public static float Duracion
    {
        get { return startingTime; }
    }

    public static bool Tutorial
    {
        get { return tutorial; }
    }

    public static Fase Fase
    {
        get { return fase; }
        set { fase = value; }
    }

    public static void Facil()
    {
		//objectToDisable.SetActive(true);
		counter = 5;
		currentTime = 0f;
        startingTime = 16f;
        tutorial = true;
        fase = Fase.FASE1;
        tiempoRestante = 0;
		x1 = 1.3f;
		x2 = -1.3f;
		y1 = 1.7f;
		y2 = -0.3f;
    }
	
	public static void Medio()
    {
		//objectToDisable.SetActive(true);
		counter = 3;
		currentTime = 0f;
        startingTime = 16f;
        tutorial = false;
        fase = Fase.FASE2;
        tiempoRestante = 0;
		x1 = 1.2f;
		x2 = -1.2f;
		y1 = 1f;
		y2 = 0.3f;
    }

    public static void Dificil()
    {
		//objectToDisable.SetActive(true);
		counter = 2;
		currentTime = 0f;
        startingTime = 16f;
        tutorial = false;
        fase = Fase.FASE3;
        tiempoRestante = 0;
		x1 = 0.4f;
		x2 = -0.4f;
		y1 = 1.6f;
		y2 = 0.5f;
		
    }

    public static void IncrementarDificultad()
    {
		currentTime = 0f;
		if(startingTime > 6){
        startingTime--;
		}
        tutorial = false;
        fase = Fase.FASE3;
        tiempoRestante = 0;
		x1 = 0.4f;
		x2 = -0.4f;
		y1 = 1.6f;
		y2 = 0.5f;
    }
}
