using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigUtils
{
    static ConfigData configData;

    public static bool JuegoCargado
    {
        get { if (configData == null)
                {
                    return false;
                }
                else
                {
                    return configData.JuegoCargado;
                }
            }
        set { configData.JuegoCargado = value; }
    }

    public static bool PrimerIntentoFase
    {
        get { return configData.PrimerIntentoFase; }
        set { configData.PrimerIntentoFase = value; }
    }

    public static Microjuego MicrojuegoActual
    {
        get { return configData.MicrojuegoActual; }
        set { configData.MicrojuegoActual = value; }
    }

    public static string Fecha
    {
        get { return configData.Fecha; }
    }

    public static int Fase
    {
        get { return configData.Fase; }
        set { configData.Fase = value; }
    }

    public static List<Microjuego> Microjuegos 
    {
        get { return configData.Microjuegos; }
    }


    public static string Gamertag
    {
        get { return configData.Gamertag; }
        set { configData.Gamertag = value; }
    }

    public static int PuntuacionMaximaFase3
    {
        get { return configData.PuntuacionMaximaFase3; }
        set { configData.PuntuacionMaximaFase3 = value; }
    }

    public static Microjuego BuscarMicrojuego(NombreMicrojuego nombreMicrojuego)
    {
        Microjuego microjuegoRetorno = null;
        foreach(Microjuego microjuego in configData.Microjuegos)
        {
            if(microjuego.nombreMicrojuego == nombreMicrojuego)
            {
                microjuegoRetorno = microjuego;
            }
        }
        return microjuegoRetorno;
    }

    public static void Inicializar()
    {
        configData = new ConfigData();
    }
}
