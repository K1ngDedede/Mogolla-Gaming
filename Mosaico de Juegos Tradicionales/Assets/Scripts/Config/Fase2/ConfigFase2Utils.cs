using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigFase2Utils
{
    static ConfigFase2Data configFase2Data;

    public static bool AcabaDePerder
    {
        get { return configFase2Data.AcabaDePerder; }
        set { configFase2Data.AcabaDePerder = value; }
    }

    public static List<string> MicrojuegosPerdidos
    {
        get { return configFase2Data.MicrojuegosPerdidos; }
    }

    public static string Fecha
    {
        get { return configFase2Data.Fecha; }
    }

    public static bool SesionFase2Terminada
    {
        get { return configFase2Data.SesionFase2Terminada; }
        set { configFase2Data.SesionFase2Terminada = value; }
    }

    public static int VidasTotales
    {
        get { return configFase2Data.VidasTotales; }
    }

    public static int NumMicrojuegosJugados
    {
        get { return configFase2Data.NumMicroJuegosJugados; }
    }

    public static int VidasRestantes
    {
        get { return configFase2Data.VidasRestantes; }
    }

    public static NombreMicrojuego MicrojuegoActual
    {
        get { return configFase2Data.MicrojuegoActual; }
        set { configFase2Data.MicrojuegoActual = value; }
    }

    public static List<NombreMicrojuego> MicrojuegosAJugar
    {
        get { return configFase2Data.MicrojuegosAJugar; }
    }


    public static void RegistrarPerdidaMicrojuego(string microjuego)
    {
        configFase2Data.RegistrarPerdidaMicrojuego(microjuego);
    }

    public static void PerderVida()
    {
        configFase2Data.VidasRestantes -= 1;
    }

    public static void AumentarMicrojuegosJugados()
    {
        configFase2Data.NumMicroJuegosJugados += 1;
    }


    public static void Inicializar()
    {
        configFase2Data = new ConfigFase2Data();
    }



}
