using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfigData
{
    const string NombreArchivoConfiguracion = "";

    static int fase = 2;
    static List<Microjuego> microjuegos;
    static Microjuego microjuegoActual;
    static string gamerTag = "Anon";
    static int puntuacionMaximaFase3 = 0;
    static bool juegoCargado = false;

    TextAsset juegosJson;

    //persistencia
    static string fecha;

    public Microjuego MicrojuegoActual
    {
        get { return microjuegoActual; }
        set { microjuegoActual = value; }
    }

    public List<Microjuego> Microjuegos
    {
        get { return microjuegos; }
    }

    
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

   

    public ConfigData()
    {
        fecha = DateTime.Now.ToString().Replace(" ","_");
        fecha = fecha.Replace("/", "-");
        fecha = fecha.Replace(":", "-");
        fecha = fecha.Replace(".", "");

        juegoCargado = true;
        microjuegos = new List<Microjuego>();
        juegosJson = Resources.Load<TextAsset>("Data/juegos");
        Microjuegos microjuegosJson = JsonUtility.FromJson<Microjuegos>(juegosJson.text);

        foreach (Microjuego microjuego in microjuegosJson.microjuegos)
        {
            microjuegos.Add(microjuego);
            foreach (NombreMicrojuego nombreMicrojuego in System.Enum.GetValues(typeof(NombreMicrojuego)))
            {
                if (nombreMicrojuego.ToString() == microjuego.nombre)
                {
                    microjuego.nombreMicrojuego = nombreMicrojuego;
                }
            }
        }
    }

}
