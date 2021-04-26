using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RanaUtils
{
    static float incrementoAngulo = 120;
    static int numeroAros = 3;
    static float velocidadBarraFuerza = 2;
    static int duracion = 12;
    static int puntajeRequerido = 100;
    static Fase fase;

    public static Fase Fase
    {
        get { return fase; }
        set { fase = value; }
    }

    public static int PuntajeRequerido
    {
        get { return puntajeRequerido; }
    }

    public static int Duracion
    {
        get { return duracion; }
    }

    public static float VelocidadBarraFuerza
    {
        get { return velocidadBarraFuerza; }
    }

    public static float IncrementoAngulo
    {
        get { return incrementoAngulo; }
    }

    public static int NumeroAros
    {
        get { return numeroAros; }
    }

    public static void Facil()
    {
        incrementoAngulo = 120;
        numeroAros = 4;
        velocidadBarraFuerza = 2;
        puntajeRequerido = 70;
        fase = Fase.FASE1;
    }

    public static void Medio()
    {
        incrementoAngulo = 160;
        numeroAros = 3;
        velocidadBarraFuerza = 2;
        puntajeRequerido = 100;
        fase = Fase.FASE2;
    }

    public static void Dificil()
    {
        incrementoAngulo = 200;
        numeroAros = 3;
        velocidadBarraFuerza = 2;
        puntajeRequerido = 200;
        fase = Fase.FASE3;
    }
}
