using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OllaUtils
{
    static int jogadores = 8;
    static float speedMax = 2f;
    static float speedBol = 3f;
    private static Fase fase = Fase.FASE2;

    public static int Jogadores
    {
        get => jogadores;
        set => jogadores = value;
    }

    public static float SpeedMax
    {
        get => speedMax;
        set => speedMax = value;
    }

    public static float SpeedBol
    {
        get => speedBol;
        set => speedBol = value;
    }

    public static Fase _Fase
    {
        get => fase;
        set => fase = value;
    }

    public static void facilito()
    {
        jogadores = 8;
        speedMax = 1f;
        speedBol = 2f;
        fase = Fase.MODOLIBRE;
    }
    
    public static void medio()
    {
        jogadores = 8;
        speedMax = 2f;
        speedBol = 3f;
        fase = Fase.FASE2;
    }
    
    public static void difisil()
    {
        jogadores = 12;
        speedMax = 3f;
        speedBol = 3.5f;
        fase = Fase.FASE3;
    }

    public static void loop()
    {
        speedMax *= 1.3f;
        speedBol *= 1.2f;
    }

}
