﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfigFase1Data
{

    static int numMicrojuegosJugados;
    static int vidasRestantes;
    static Microjuego microjuegoActual;
    static List<Microjuego> microjuegosAJugar;
    static int duracionMicrojuegos;

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
        numMicrojuegosJugados = 0;
        vidasRestantes = 4;
        duracionMicrojuegos = 10;


        //asignar dificultad de los juegos
        JacksesUtils.dificil();





        //agregar microjuegos a jugar a la lista de microjuegos
        microjuegosAJugar = new List<Microjuego>();
        microjuegosAJugar.Add(Microjuego.Jackses);

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