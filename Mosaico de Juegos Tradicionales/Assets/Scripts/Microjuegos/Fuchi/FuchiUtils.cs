using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FuchiUtils 
{
	public static float thrust = 13.0f;
    public static int counter = 0;
    //static float rot = 0.0f;
	public static float x0 = -3.0f;
	public static float x1 = 3.0f;
	public static float y0 = 1.5f;
	public static float y1 = 5.0f;
    static int duracion = 10;
    static bool tutorial = false;
    static Fase fase = Fase.FASE1;
    static float tiempoRestante = 0;

    public static float TiempoRestante
    {
        set { tiempoRestante = value; }
        get { return tiempoRestante; }
    }


    public static int Duracion
    {
        get { return duracion; }
    }

    public static bool Tutorial
    {
        get { return tutorial; }
    }

    public static Fase Fase
    {
        get { return fase; }
    }

    public static void facil()
    {
        duracion = 12;
        tutorial = true;
        fase = Fase.FASE1;
        tiempoRestante = 0;
		thrust = 13.0f;
		x0 = -3.0f;
		x1 = 3.0f;
		y0 = 1.5f;
		y1 = 5.0f;
    }

    public static void dificil()
    {
        duracion = 10;
        tutorial = false;
		thrust = 20.0f;
		x0 = -3.0f;
		x1 = 3.0f;
		y0 = 1.5f;
		y1 = 5.0f;
    }
}
