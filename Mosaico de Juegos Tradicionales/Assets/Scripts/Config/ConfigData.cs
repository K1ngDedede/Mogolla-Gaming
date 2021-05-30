using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfigData
{

    static int fase = 1;
    static List<Microjuego> microjuegos;
    static Microjuego microjuegoActual;
    static bool juegoCargado = false;
    static bool primerIntentoFase = true;
    static bool mostrarPanelInfo = true;

    TextAsset juegosJson;

    //persistencia
    static string fecha;

    public bool MostrarPanelInfo
    {
        get { return mostrarPanelInfo; }
        set { mostrarPanelInfo = value; }
    }

    public bool PrimerIntentoFase
    {
        get { return primerIntentoFase; }
        set { primerIntentoFase = value; }
    }

    public Microjuego MicrojuegoActual
    {
        get  { return microjuegoActual;}
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
			case NombreMicrojuego.Tejo:
                nombre = "Tejo";
                break;
            case NombreMicrojuego.Coca:
                nombre = "Coca";
                break;
            case NombreMicrojuego.Piquis:
                nombre = "Piquis";
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
        microjuegoActual = new Microjuego();
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
