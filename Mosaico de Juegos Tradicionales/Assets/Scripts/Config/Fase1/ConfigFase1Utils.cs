using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigFase1Utils
{
    static ConfigFase1Data configFase1Data;

    public static bool AcabaDePerder
    {
        get { return configFase1Data.AcabaDePerder; }
        set { configFase1Data.AcabaDePerder = value; }
    }


    public static List<string> MicrojuegosPerdidos
    {
        get { return configFase1Data.MicrojuegosPerdidos; }
    }

    public static string Fecha
    {
        get { return configFase1Data.Fecha; }
    }

    public static bool SesionFase1Terminada
    {
        get { return configFase1Data.SesionFase1Terminada; }
        set { configFase1Data.SesionFase1Terminada = value; }
    }

    public static int VidasTotales
    {
        get { return configFase1Data.VidasTotales; }
    }

    public static int IntentosTutorial
    {
        get { return configFase1Data.IntentosTutorial; }
    }

    public static int NumMicrojuegosJugados
    {
        get { return configFase1Data.NumMicroJuegosJugados; }
    }

    public static int VidasRestantes
    {
        get { return configFase1Data.VidasRestantes; }
    }

    public static NombreMicrojuego MicrojuegoActual
    {
        get { return configFase1Data.MicrojuegoActual; }
        set { configFase1Data.MicrojuegoActual = value; }
    }

    public static List<NombreMicrojuego> MicrojuegosAJugar
    {
        get { return configFase1Data.MicrojuegosAJugar; }
    }


    public static void RegistrarPerdidaMicrojuego(string microjuego)
    {
        configFase1Data.RegistrarPerdidaMicrojuego(microjuego);
    }

    public static void PerderVida()
    {
        configFase1Data.VidasRestantes -= 1;
    }

    public static void AumentarMicrojuegosJugados()
    {
        configFase1Data.NumMicroJuegosJugados += 1;
    }


    public static void Inicializar()
    {
        configFase1Data = new ConfigFase1Data();
    }

    public static void AumentarIntentosTutorial()
    {
        configFase1Data.IntentosTutorial += 1;
    }

   
}
