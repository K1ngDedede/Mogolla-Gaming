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
    static System.Random rng = new System.Random();

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

    public static void RandomizarMicrojuegos()
    {
        int n = microjuegosAJugar.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Microjuego microjuego = microjuegosAJugar[k];
            microjuegosAJugar[k] = microjuegosAJugar[n];
            microjuegosAJugar[n] = microjuego;
        }
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
		FuchiUtils.facil();




        //agregar microjuegos a jugar a la lista de microjuegos
        microjuegosAJugar = new List<Microjuego>();
        microjuegosAJugar.Add(Microjuego.Jackses);
        microjuegosAJugar.Add(Microjuego.Trompo);
		microjuegosAJugar.Add(Microjuego.Fuchi);

        //randomizar lista de microjuegos
        RandomizarMicrojuegos();


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
