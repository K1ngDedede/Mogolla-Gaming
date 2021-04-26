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

    private string DarNombreMicrojuego(NombreMicrojuego nombreMicrojuego)
    {
        string nombre="";
        switch (nombreMicrojuego)
        {
            case NombreMicrojuego.Fuchi:
                nombre = "Fuchi";
                break;
            case NombreMicrojuego.Jackses:
                nombre = "Jacks";
                break;
            case NombreMicrojuego.Olla:
                nombre = "La Olla";
                break;
            case NombreMicrojuego.Trompo:
                nombre = "Trompo";
                break;
            case NombreMicrojuego.Yermis:
                nombre = "Yermis";
                break;
            case NombreMicrojuego.Rana:
                nombre = "Rana";
                break;
        }
        return nombre;
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
                if (DarNombreMicrojuego(nombreMicrojuego) == microjuego.nombre)
                {
                    microjuego.nombreMicrojuego = nombreMicrojuego;
                }
            }
        }
    }

}
