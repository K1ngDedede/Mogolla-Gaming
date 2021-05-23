using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrompoUtils
{
    static float torqueR = 0.3f;
    static float torqueP = 10;
    static int mov = 0;
    static bool teach = false;

    public static int Mov
    {
        get => mov;
        set => mov = value;
    }

    public static bool Teach
    {
        get => teach;
        set => teach = value;
    }

    static Fase fase = Fase.FASE1;

    public static float TorqueR
    {
        get => torqueR;
        set => torqueR = value;
    }

    public static float TorqueP
    {
        get => torqueP;
        set => torqueP = value;
    }

    public static Fase Fase
    {
        get => fase;
        set => fase = value;
    }

    public static void tutorial()
    {
        torqueR = 0f;
        torqueP = 0;
        mov = 0;
        teach = true;
    }
    
    public static void facilito()
    {
        torqueR = 0.3f;
        torqueP = 10;
        mov = 0;
        teach = false;
        fase = Fase.FASE1;
    }

    public static void medio()
    {
        torqueR = 0.4f;
        torqueP = 8;
        mov = 1;
        teach = false;
        fase = Fase.FASE2;
    }

    public static void difisil()
    {
        torqueR = 0.4f;
        torqueP = 8;
        mov = 2;
        teach = false;
        fase = Fase.FASE3;
    }

    public static void loop()
    {
        torqueR *= 1.2f;
        torqueP *= 0.8f;
        mov += 1;
    }

}
