using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrompoUtils
{
    static float torqueR = 0.3f;
    static float torqueP = 10;
    static int duracion = 10;
    static bool mov = false;
    static bool teach = false;

    public static bool Mov => mov;

    public static bool Teach => teach;

    static Fase fase = Fase.FASE1;

    public static float TorqueR => torqueR;

    public static float TorqueP => torqueP;

    public static int Duracion => duracion;

    public static Fase Fase => fase;

    public static void tutorial()
    {
        torqueR = 0f;
        torqueP = 0;
        duracion = 12;
        mov = false;
        teach = true;
    }
    
    public static void facilito()
    {
        torqueR = 0.3f;
        torqueP = 10;
        duracion = 12;
        mov = false;
        teach = false;
        fase = Fase.FASE1;
    }

    public static void dificil()
    {
        torqueR = 0.4f;
        torqueP = 8;
        duracion = 10;
        mov = true;
        teach = false;
    }

}
