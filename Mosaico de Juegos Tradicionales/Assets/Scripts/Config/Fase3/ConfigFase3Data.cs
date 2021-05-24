using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfigFase3Data
{
    static int numMicrojuegosJugados;
    static int vidasTotales;
    static int vidasRestantes;
    static NombreMicrojuego microjuegoActual;
    static List<NombreMicrojuego> microjuegosAJugar;
    static List<NombreMicrojuego> poolMicrojuegos;
    static bool sesionFase3Terminada;
    static System.Random rng = new System.Random();
    static List<string> microjuegosPerdidos;
    static string fecha;
    static bool acabaDePerder;
    static bool jugandoEnContinuacion;
    static int puntaje;

    public int Puntaje
    {
        get { return puntaje; }
        set { puntaje = value; }
    }

    public bool JugandoEnContinuacion
    {
        get { return jugandoEnContinuacion; }
        set { jugandoEnContinuacion = value; }
    }

    public bool AcabaDePerder
    {
        get { return acabaDePerder; }
        set { acabaDePerder = value; }
    }

    public List<string> MicrojuegosPerdidos
    {
        get { return microjuegosPerdidos; }
    }

    public void RegistrarPerdidaMicrojuego(string microjuego)
    {
        microjuegosPerdidos.Add(microjuego);
    }

    public string Fecha
    {
        get { return fecha; }
    }

    public bool SesionFase3Terminada
    {
        get { return sesionFase3Terminada; }
        set { sesionFase3Terminada = value; }
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

    public NombreMicrojuego MicrojuegoActual
    {
        get { return microjuegoActual; }
        set { microjuegoActual = value; }
    }

    public List<NombreMicrojuego> MicrojuegosAJugar
    {
        get { return microjuegosAJugar; }
    }

    public NombreMicrojuego SiguienteMicrojuegoAleatorio()
    {
        int pos = GenerarNumeroAleatorio(poolMicrojuegos.Count - 1);
        return poolMicrojuegos[pos];
    }


    public static void RandomizarMicrojuegos()
    {
        int n = microjuegosAJugar.Count;
        while (n > 1)
        {
            n--;
            int k = GenerarNumeroAleatorio(n);
            NombreMicrojuego microjuego = microjuegosAJugar[k];
            if (n == microjuegosAJugar.Count - 1)
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

    public ConfigFase3Data()
    {
        puntaje = 0;
        numMicrojuegosJugados = 0;
        vidasTotales = 4;
        vidasRestantes = vidasTotales;
        sesionFase3Terminada = false;
        microjuegosPerdidos = new List<string>();
        jugandoEnContinuacion = false;

        fecha = DateTime.Now.ToString().Replace(" ", "_");
        fecha = fecha.Replace("/", "-");
        fecha = fecha.Replace(":", "-");
        fecha = fecha.Replace(".", "");


        //asignar dificultad de los juegos
        JacksesUtils.Dificil();
        CocaUtils.Dificil();
        RanaUtils.Dificil();
        YermisUtils.Dificil();
        TrompoUtils.difisil();
        OllaUtils.difisil();
        piquisUtils.difisil();
        TejoUtils.Dificil();
        FuchiUtils.dificil();


        //agregar microjuegos a jugar a la lista de microjuegos
        microjuegosAJugar = new List<NombreMicrojuego>();
        microjuegosAJugar.Add(NombreMicrojuego.Jackses);
        microjuegosAJugar.Add(NombreMicrojuego.Yermis);
        microjuegosAJugar.Add(NombreMicrojuego.Rana);
        microjuegosAJugar.Add(NombreMicrojuego.Coca);
        microjuegosAJugar.Add(NombreMicrojuego.Trompo);
        microjuegosAJugar.Add(NombreMicrojuego.Olla);
        microjuegosAJugar.Add(NombreMicrojuego.Piquis);
        microjuegosAJugar.Add(NombreMicrojuego.Fuchi);
        microjuegosAJugar.Add(NombreMicrojuego.Tejo);

        //agregar microjuegos al pool
        poolMicrojuegos = new List<NombreMicrojuego>();
        poolMicrojuegos.Add(NombreMicrojuego.Coca);
        poolMicrojuegos.Add(NombreMicrojuego.Fuchi);
        poolMicrojuegos.Add(NombreMicrojuego.Jackses);
        poolMicrojuegos.Add(NombreMicrojuego.Olla);
        poolMicrojuegos.Add(NombreMicrojuego.Piquis);
        poolMicrojuegos.Add(NombreMicrojuego.Rana);
        poolMicrojuegos.Add(NombreMicrojuego.Tejo);
        poolMicrojuegos.Add(NombreMicrojuego.Trompo);
        poolMicrojuegos.Add(NombreMicrojuego.Yermis);

        //randomizar lista de microjuegos
        RandomizarMicrojuegos();

        ConfigUtils.MicrojuegoActual = ConfigUtils.BuscarMicrojuego(microjuegosAJugar.ToArray()[0]);



    }
}
