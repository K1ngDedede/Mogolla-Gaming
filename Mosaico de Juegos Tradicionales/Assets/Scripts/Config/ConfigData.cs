using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfigData
{
    const string NombreArchivoConfiguracion = "";

    static int fase = 2;
    static List<Microjuego> microjuegosDesbloqueados;
    static string gamerTag = "Anon";
    static int puntuacionMaximaFase3 = 0;
    static bool juegoCargado = false;

    //persistencia
    static string fecha;

    
    public bool JuegoCargado
    {
        get { return juegoCargado; }
        set { juegoCargado = value; }
    }

    public string Fecha
    {
        get { return fecha; }
    }

    public int Fase
    {
        get { return fase; }
        set { fase = value; }
    }

    public List<Microjuego> MicrojuegosDesbloqueados
    {
        get { return microjuegosDesbloqueados; }
    }

    public string Gamertag
    {
        get { return gamerTag; }
        set { gamerTag = value; }
    }

    public int PuntuacionMaximaFase3
    {
        get { return puntuacionMaximaFase3; }
        set { puntuacionMaximaFase3 = value; }
    }

    public void DesbloquearMicrojuego(Microjuego microjuego)
    {
        if (!microjuegosDesbloqueados.Contains(microjuego))
        {
            microjuegosDesbloqueados.Add(microjuego);
        }
    }

    public ConfigData()
    {
        fecha = DateTime.Now.ToString().Replace(" ","_");
        fecha = fecha.Replace("/", "-");
        fecha = fecha.Replace(":", "-");
        fecha = fecha.Replace(".", "");
        microjuegosDesbloqueados = new List<Microjuego>();

        juegoCargado = true;

    
        

        try
        {
            //Recuperar datos
        }
        catch(Exception e)
        {

        }
        finally
        {

        }
    }

}
