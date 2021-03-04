using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JacksesUtils
{
    // Start is called before the first frame update
    static int numeroJacks = 5;
    static int duracion = 10;

    public static int NumeroJacks
    {
        get { return numeroJacks; }
    }

    public static int Duracion
    {
        get { return duracion; }
    }

    public static void facil()
    {
        numeroJacks = 5;
        duracion = 10;
    }

    public static void dificil()
    {
        numeroJacks = 10;
        duracion = 10;
    }

}
