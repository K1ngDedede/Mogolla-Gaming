using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CocaUtils
{
    static int duracion = 12;
    static Fase fase = Fase.FASE1;
    static float longSegmentoCuerda = 0.3f;
    static Vector2 gravedad = new Vector2(0f, -1f);
    static float fuerzaX = 2;
    static float fuerzaY = 0.5f;

    public static float FuerzaX
    {
        get { return fuerzaX; }
    }

    public static float FuerzaY
    {
        get { return fuerzaY; }
    }

    public static Vector2 Gravedad
    {
        get { return gravedad; }
    }

    public static float LongSegmentoCuerda
    {
        get { return longSegmentoCuerda; }
    }

    public static Fase Fase
    {
        set { fase = value; }
        get { return fase; }
    }

    public static int Duracion
    {
        get { return duracion; }
        set { duracion = value; }
    }

    public static void Facil()
    {
        fuerzaX = 2;
        fuerzaY = 0.5f;
        duracion = 12;
        longSegmentoCuerda = 0.3f;
        gravedad = new Vector2(0f, -1f);
        fase = Fase.FASE1;
    }

    public static void Medio()
    {
        duracion = 10;
        fuerzaX = 3;
        fuerzaY = 1f;
        longSegmentoCuerda = 0.4f;
        gravedad = new Vector2(0f, -3f);
        fase = Fase.FASE2;
    }

    public static void Dificil()
    {
        duracion = 8;
        fuerzaX = 4;
        fuerzaY = 2f;
        longSegmentoCuerda = 0.5f;
        gravedad = new Vector2(0f, -6f);
        fase = Fase.FASE3;
    }

    public static void AumentarDificultad()
    {
        if (duracion > 4)
        {
            duracion -= 1;
        }
        fuerzaX += fuerzaX * 0.2f;
        fuerzaY += fuerzaY * 0.2f;
        gravedad.y += gravedad.y * 0.2f;
    }

}
