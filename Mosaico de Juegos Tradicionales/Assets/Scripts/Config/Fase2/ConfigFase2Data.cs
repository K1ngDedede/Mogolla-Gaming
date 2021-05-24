using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfigFase2Data
{
    static int numMicrojuegosJugados;
    static int vidasTotales;
    static int vidasRestantes;
    static NombreMicrojuego microjuegoActual;
    static List<NombreMicrojuego> microjuegosAJugar;
    static bool sesionFase2Terminada;
    static System.Random rng = new System.Random();
    static List<string> microjuegosPerdidos;
    static string fecha;
    static bool acabaDePerder;

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

    public bool SesionFase2Terminada
    {
        get { return sesionFase2Terminada; }
        set { sesionFase2Terminada = value; }
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

    public ConfigFase2Data()
    {
        numMicrojuegosJugados = 0;
        vidasTotales = 3;
        vidasRestantes = vidasTotales;
        sesionFase2Terminada = false;
        microjuegosPerdidos = new List<string>();

        fecha = DateTime.Now.ToString().Replace(" ", "_");
        fecha = fecha.Replace("/", "-");
        fecha = fecha.Replace(":", "-");
        fecha = fecha.Replace(".", "");


        //asignar dificultad de los juegos
        JacksesUtils.Medio();
        CocaUtils.Medio();
        RanaUtils.Medio();
        //YermisUtils.Medio();
        OllaUtils.medio();
        TrompoUtils.medio();
        piquisUtils.medio();
        FuchiUtils.medio();

        //agregar microjuegos a jugar a la lista de microjuegos
        microjuegosAJugar = new List<NombreMicrojuego>();
        microjuegosAJugar.Add(NombreMicrojuego.Jackses);
        microjuegosAJugar.Add(NombreMicrojuego.Olla);
        microjuegosAJugar.Add(NombreMicrojuego.Rana);
        microjuegosAJugar.Add(NombreMicrojuego.Coca);
        microjuegosAJugar.Add(NombreMicrojuego.Trompo);
        microjuegosAJugar.Add(NombreMicrojuego.Piquis);
        microjuegosAJugar.Add(NombreMicrojuego.Fuchi);

        //randomizar lista de microjuegos
        RandomizarMicrojuegos();

        ConfigUtils.MicrojuegoActual = ConfigUtils.BuscarMicrojuego(microjuegosAJugar.ToArray()[0]);



    }
}
