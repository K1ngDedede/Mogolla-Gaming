using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JacksesUtils
{
    // Start is called before the first frame update
    static int numeroJacks = 5;
    static int duracion = 10;
    static bool tutorial = false;

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

    public static void facil()
    {
        numeroJacks = 5;
        duracion = 10;
        tutorial = true;
    }

    public static void dificil()
    {
        numeroJacks = 10;
        duracion = 10;
        tutorial = false;
    }

}
