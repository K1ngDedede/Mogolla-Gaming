using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfigFase1Data
{

    static int numMicrojuegosJugados;
    static int vidasTotales;
    static int vidasRestantes;
    static Microjuego microjuegoActual;
    static List<Microjuego> microjuegosAJugar;
    static int duracionMicrojuegos;
    static int intentosTutorial;

    public int VidasTotales
    {
        get { return vidasTotales; }
    }

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

    public int IntentosTutorial
    {
        get { return intentosTutorial; }
        set { intentosTutorial = value; }
    }

    public ConfigFase1Data()
    {
        numMicrojuegosJugados = 0;
        vidasTotales = 4;
        vidasRestantes = vidasTotales;
        duracionMicrojuegos = 10;
        intentosTutorial = 1;


        //asignar dificultad de los juegos
        JacksesUtils.facil();
        TrompoUtils.facilito();




        //agregar microjuegos a jugar a la lista de microjuegos
        microjuegosAJugar = new List<Microjuego>();
        microjuegosAJugar.Add(Microjuego.Jackses);
        microjuegosAJugar.Add(Microjuego.Trompo);

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
