using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigUtils
{
    static ConfigData configData;

    public static string Fecha
    {
        get { return configData.Fecha; }
    }

    public static int Fase
    {
        get { return configData.Fase; }
        set { configData.Fase = value; }
    }

    public static List<Microjuego> MicrojuegosDesbloqueados
    {
        get { return configData.MicrojuegosDesbloqueados; }
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

    public static void DesbloquearMicrojuego(Microjuego microjuego)
    {
        configData.DesbloquearMicrojuego(microjuego);
    }

    public static void Inicializar()
    {
        configData = new ConfigData();
    }
}
