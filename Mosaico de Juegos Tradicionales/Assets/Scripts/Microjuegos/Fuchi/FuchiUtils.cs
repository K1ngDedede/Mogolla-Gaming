using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FuchiUtils 
{
	public static float thrust = 12.0f;
    public static int counter = 0;
	public static float currentTime = 0f;
	public static float startingTime = 12f;
	//GameObject objectToDisable = GameControlScript.objectToDisable;
    //static float rot = 0.0f;
	public static float x0 = -3.0f;
	public static float x1 = 3.0f;
	public static float y0 = 1.5f;
	public static float y1 = 5.0f;
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

    public static void facil()
    {
		//objectToDisable.SetActive(true);
		counter = 0;
		currentTime = 0f;
        startingTime = 11f;
        tutorial = true;
        fase = Fase.FASE1;
        tiempoRestante = 0;
		thrust = 12.0f;
		x0 = -3.0f;
		x1 = 3.0f;
		y0 = 1.5f;
		y1 = 5.0f;
        fase = Fase.FASE1;
    }

    public static void medio()
    {
        fase = Fase.FASE2;
    }

    public static void IncrementarDificultad()
    {

    }

    public static void dificil()
    {
		//objectToDisable.SetActive(true);
		counter = 0;
		currentTime = 0f;
        startingTime = 8;
        tutorial = false;
		thrust = 15.0f;
		x0 = -3.0f;
		x1 = 3.0f;
		y0 = 1.5f;
		y1 = 5.0f;
        fase = Fase.FASE3;
    }
}
