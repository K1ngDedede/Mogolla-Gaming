using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfigFase1Data
{

    static int numMicrojuegosJugados = 0;
    static int vidasRestantes = 4;
    static Microjuego microjuegoActual;
    static List<Microjuego> microjuegosAJugar;
    static int duracionMicrojuegos = 10;

    public int NumMicroJuegosJugados
    {
        get { return numMicrojuegosJugados; }
        set { numMicrojuegosJugados = value; }
    }

    public int VidasRestantes
    {
        get { return vidasRestantes; }
        set { vidasRestantes = value; }
    }

    public Microjuego MicrojuegoActual
    {
        get { return microjuegoActual; }
        set { microjuegoActual = value; }
    }

    public List<Microjuego> MicrojuegosAJugar
    {
        get { return microjuegosAJugar; }
    }

    public int DuracionMicrojuegos
    {
        get { return duracionMicrojuegos; }
    }

    public ConfigFase1Data()
    {
        //asignar dificultad de los juegos


        microjuegosAJugar = new List<Microjuego>();
        try
        {
            //recuperar datos

        }catch(Exception e)
        {

        }
        finally
        {

        }
    }
    
}
