using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class piquisUtils
{
    static int jogo = 2;
    static int fMod = 1500;
    static float sMod = 1;
    static int d = 12;
    static Fase fase = Fase.FASE1;
    static int iterator = 0;

    public static int Jogo
    {
        get => jogo;
        set => jogo = value;
    }

    public static int FMod
    {
        get => fMod;
        set => fMod = value;
    }

    public static float SMod
    {
        get => sMod;
        set => sMod = value;
    }

    public static int D
    {
        get => d;
        set => d = value;
    }

    public static Fase _Fase
    {
        get => fase;
        set => fase = value;
    }

    public static void facilito()
    {
        jogo = 2;
        fMod = 1500;
        sMod = 2;
        d = 12;
        fase = Fase.FASE1;
    }
    
    public static void medio()
    {
        jogo = 2;
        fMod = 1500;
        sMod = 1;
        d = 12;
        fase = Fase.FASE2;
    }
    
    public static void difisil()
    {
        jogo = 2;
        fMod = 1500;
        sMod = 0.75f;
        d = 12;
		iterator = 1;
        fase = Fase.FASE3;
    }

    public static void loop()
    {
        iterator++;
        if (iterator % 3 == 0)
        {
            jogo++;
        }
        else
        {
            fMod = (int) (fMod*1.1f);
            sMod *= 0.95f;
        }
        if (d > 4)
        {
            d--;
        }
    }

}
