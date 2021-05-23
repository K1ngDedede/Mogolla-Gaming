using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigFase3Utils
{
    static ConfigFase3Data configFase3Data;

    public static int Puntaje
    {
        get { return configFase3Data.Puntaje; }
    }

    public static void AumentarPuntaje()
    {
        configFase3Data.Puntaje++;
    }

    public static bool JugandoEnContinuacion
    {
        get { return configFase3Data.JugandoEnContinuacion; }
        set { configFase3Data.JugandoEnContinuacion = value; }
    }

    public static bool AcabaDePerder
    {
        get { return configFase3Data.AcabaDePerder; }
        set { configFase3Data.AcabaDePerder = value; }
    }

    public static List<string> MicrojuegosPerdidos
    {
        get { return configFase3Data.MicrojuegosPerdidos; }
    }

    public static string Fecha
    {
        get { return configFase3Data.Fecha; }
    }

    public static bool SesionFase3Terminada
    {
        get { return configFase3Data.SesionFase3Terminada; }
        set { configFase3Data.SesionFase3Terminada = value; }
    }

    public static int VidasTotales
    {
        get { return configFase3Data.VidasTotales; }
    }

    public static int NumMicrojuegosJugados
    {
        get { return configFase3Data.NumMicroJuegosJugados; }
    }

    public static int VidasRestantes
    {
        get { return configFase3Data.VidasRestantes; }
    }

    public static NombreMicrojuego MicrojuegoActual
    {
        get { return configFase3Data.MicrojuegoActual; }
        set { configFase3Data.MicrojuegoActual = value; }
    }

    public static List<NombreMicrojuego> MicrojuegosAJugar
    {
        get { return configFase3Data.MicrojuegosAJugar; }
    }


    public static void RegistrarPerdidaMicrojuego(string microjuego)
    {
        configFase3Data.RegistrarPerdidaMicrojuego(microjuego);
    }

    public static void PerderVida()
    {
        configFase3Data.VidasRestantes -= 1;
    }

    public static void AumentarMicrojuegosJugados()
    {
        configFase3Data.NumMicroJuegosJugados += 1;
    }

    public static NombreMicrojuego SiguienteMicrojuegoAleatorio()
    {
        return configFase3Data.SiguienteMicrojuegoAleatorio();
    }

    public static void Inicializar()
    {
        configFase3Data = new ConfigFase3Data();
    }
}
