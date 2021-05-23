using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ManejadorFase3
{
    public static void RegistrarPerdidaMicrojuego(string microjuego)
    {
        ConfigFase3Utils.RegistrarPerdidaMicrojuego(microjuego);
    }

    public static void RegistrarVictoria()
    {
        ConfigFase3Utils.AcabaDePerder = false;
        ConfigFase3Utils.AumentarPuntaje();
    }


    public static void EmpezarMicrojuegosFase()
    {
        SceneManager.LoadScene("escenaIntermediaFase3");
    }

    private static void SiguienteMicroJuego()
    {
        SceneManager.LoadScene("escenaIntermediaFase3");
    }

    public static void PerderVida()
    {
        ConfigFase3Utils.AcabaDePerder = true;
        ConfigFase3Utils.PerderVida();
    }

    public static void AumentarMicrojuegosJugados()
    {
        ConfigFase3Utils.AumentarMicrojuegosJugados();
    }

    public static void RevisarFinFase()
    {
        //revisar si perdio la fase
        if (ConfigFase3Utils.VidasRestantes <= 0)
        {
            //persistir sesion
            ConfigFase3Utils.SesionFase3Terminada = true;
            //ManejadorPersistencia.PersistirSesionFase1();
            //cargar escena de derrota
            if (!ConfigFase3Utils.JugandoEnContinuacion)
            {
                SceneManager.LoadScene("derrotaFase3");
            }
            else
            {
                SceneManager.LoadScene("tablaClasificacion");
            }
            
        }

        //revisar si gano la fase
        else if (ConfigFase3Utils.NumMicrojuegosJugados == ConfigFase3Utils.MicrojuegosAJugar.Count)
        {
            
            //persistir sesion
            ConfigFase3Utils.SesionFase3Terminada = true;
            //ManejadorPersistencia.PersistirSesionFase1();
            SceneManager.LoadScene("victoriaFase3");
        }
        else
        {
            SiguienteMicroJuego();
        }
    }
}
