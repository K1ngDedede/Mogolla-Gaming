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
    static bool sesionFase1Terminada;
    static System.Random rng = new System.Random();
    static List<string> microjuegosPerdidos;
    static string fecha;

    public List<string> MicrojuegosPerdidos
    {
        get { return microjuegosPerdidos; }
    }

    public void RegistrarPerdidaMicrojuego(String microjuego)
    {
        microjuegosPerdidos.Add(microjuego);
    }

    public string Fecha
    {
        get { return fecha; }
    }

    public bool SesionFase1Terminada
    {
        get { return sesionFase1Terminada; }
        set { sesionFase1Terminada = value; }
    }

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
            int k = GenerarNumeroAleatorio(n);
            Microjuego microjuego = microjuegosAJugar[k];
            if(n == microjuegosAJugar.Count - 1)
            {
                microjuegosAJugar[k] = microjuegosAJugar[n];
                microjuegosAJugar[n] = microjuego;
            }
            else
            {
                while (microjuegosAJugar[n + 1] == microjuego)
                {
                    k = GenerarNumeroAleatorio(n);
                    microjuego = microjuegosAJugar[k];
                }
                microjuegosAJugar[k] = microjuegosAJugar[n];
                microjuegosAJugar[n] = microjuego;
            }
            
            
        }
    }

     private static int GenerarNumeroAleatorio(int max)
    {
        return rng.Next(max + 1);
    }

    public ConfigFase1Data()
    {
        numMicrojuegosJugados = 0;
        vidasTotales = 4;
        vidasRestantes = vidasTotales;
        duracionMicrojuegos = 10;
        intentosTutorial = 1;
        sesionFase1Terminada = false;
        microjuegosPerdidos = new List<string>();

        fecha = DateTime.Now.ToString().Replace(" ", "_");
        fecha = fecha.Replace("/", "-");
        fecha = fecha.Replace(":", "-");
        fecha = fecha.Replace(".", "");


        //asignar dificultad de los juegos
        JacksesUtils.facil();
        TrompoUtils.facilito();
		FuchiUtils.facil();
        YermisUtils.facil();



        //agregar microjuegos a jugar a la lista de microjuegos
        microjuegosAJugar = new List<Microjuego>();
        microjuegosAJugar.Add(Microjuego.Jackses);
        microjuegosAJugar.Add(Microjuego.Trompo);
		microjuegosAJugar.Add(Microjuego.Fuchi);
        microjuegosAJugar.Add(Microjuego.Jackses);
        microjuegosAJugar.Add(Microjuego.Trompo);
        microjuegosAJugar.Add(Microjuego.Fuchi);
        microjuegosAJugar.Add(Microjuego.Yermis);
        microjuegosAJugar.Add(Microjuego.Yermis);

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
