using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JacksesUtils
{
    // Start is called before the first frame update
    static int numeroJacks = 5;
    static int duracion = 12;
    static bool tutorial = false;
    static Fase fase = Fase.FASE1;
    static float tiempoRestante = 0;
    static float escalaGravedad = 0.6f;

    public static float EscalaGravedad
    {
        get { return escalaGravedad; }
    }

    public static float TiempoRestante
    {
        set { tiempoRestante = value; }
        get { return tiempoRestante; }
    }

    public static int NumeroJacks
    {
        get { return numeroJacks; }
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
        numeroJacks = 5;
        duracion = 12;
        tutorial = true;
        fase = Fase.FASE1;
        tiempoRestante = 0;
        escalaGravedad = 0.6f;
    }

    public static void dificil()
    {
        numeroJacks = 10;
        duracion = 12;
        tutorial = false;
    }

}
