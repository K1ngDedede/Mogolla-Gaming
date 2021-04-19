using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class YermisUtils
{
    static float incrementoAnguloFlecha = 80;
    static int numeroBolasDefensa = 5;
    static float minFuerzaBolasDefensa = 5;
    static float maxFuerzaBolasDefensa = 10;
    static float anguloDisparoDefensa = 45;
    static int disparosAtaque = 5;
    static int numeroBlancosAtaque = 3;
    static Fase fase = Fase.FASE1;

    public static float IncrementoAnguloFlecha
    {
        get { return incrementoAnguloFlecha; }
    }

    public static float MinFuerzaBolasDefensa
    {
        get { return minFuerzaBolasDefensa; }
    }

    public static float MaxFuerzaBolasAtaque
    {
        get { return maxFuerzaBolasDefensa; }
    }

    public static float AnguloDisparoDefensa
    {
        get { return anguloDisparoDefensa; }
    }

    public static int NumeroBolasDefensa
    {
        get { return numeroBolasDefensa; }
    }

    public static int DisparosAtaque
    {
        get { return disparosAtaque; }
    }

    public static int NumeroBlancosAtaque
    {
        get { return numeroBlancosAtaque; }
    }

    public static Fase Fase
    {
        get { return fase; }
        set { fase = value; }
    }

    public static void Facil()
    {
        incrementoAnguloFlecha = 80;
        numeroBolasDefensa = 5;
        minFuerzaBolasDefensa = 5;
        maxFuerzaBolasDefensa = 10;
        anguloDisparoDefensa = 45;
        disparosAtaque = 5;
        numeroBlancosAtaque = 3;
        fase = Fase.FASE1;
    }

    public static void Medio()
    {
        incrementoAnguloFlecha = 120;
        numeroBolasDefensa = 8;
        minFuerzaBolasDefensa = 5;
        maxFuerzaBolasDefensa = 10;
        anguloDisparoDefensa = 45;
        disparosAtaque = 5;
        numeroBlancosAtaque = 4;
        fase = Fase.FASE2;
    }

    public static void Dificil()
    {
        incrementoAnguloFlecha = 160;
        numeroBolasDefensa = 10;
        minFuerzaBolasDefensa = 5;
        maxFuerzaBolasDefensa = 15;
        anguloDisparoDefensa = 45;
        disparosAtaque = 6;
        numeroBlancosAtaque = 6;
        fase = Fase.FASE3;
    }
}
