using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ManejadorFase1
{
    public static void RegistrarPerdidaMicrojuego(string microjuego)
    {
        ConfigFase1Utils.RegistrarPerdidaMicrojuego(microjuego);
    }

    public static void RegistrarVictoria()
    {
        ConfigFase1Utils.AcabaDePerder = false;
    }

    public static void EmpezarTutorial()
    {
        TrompoUtils.tutorial();
        SceneManager.LoadScene("Trompo");
    }

    public static void ReintentarTutorial()
    {
        ManejadorPersistencia.PersistirSesionFase1();
        SceneManager.LoadScene("Trompo");
    }

    public static void ExplicacionPirinola()
    {
        SceneManager.LoadScene("explicacionPirinola");
    }

    public static void EmpezarMicrojuegosFase()
    {
        ManejadorPersistencia.PersistirSesionFase1();
        SceneManager.LoadScene("escenaIntermediaFase1");
    }

    private static void SiguienteMicroJuego()
    {
        SceneManager.LoadScene("escenaIntermediaFase1");
    }

    public static void PerderVida()
    {
        ConfigFase1Utils.AcabaDePerder = true;
        ConfigFase1Utils.PerderVida();
    }

    public static void AumentarMicrojuegosJugados()
    {
        ConfigFase1Utils.AumentarMicrojuegosJugados();
    }

    public static void RevisarFinFase()
    {
        //revisar si perdio la fase
        if(ConfigFase1Utils.VidasRestantes <= 0)
        {
            //persistir sesion
            ConfigFase1Utils.SesionFase1Terminada = true;
            ManejadorPersistencia.PersistirSesionFase1();
            //cargar escena de derrota
            SceneManager.LoadScene("derrotaFase1");
        }

        //revisar si gano la fase
        else if(ConfigFase1Utils.NumMicrojuegosJugados == ConfigFase1Utils.MicrojuegosAJugar.Count)
        {
            //cargar escena de victoria
            if(ConfigUtils.Fase == 1)
            {
                ConfigUtils.Fase = 2;
            }
            //persistir sesion
            ConfigFase1Utils.SesionFase1Terminada = true;
            ManejadorPersistencia.PersistirSesionFase1();
            SceneManager.LoadScene("victoriaFase1");
        }
        else
        {
            ManejadorPersistencia.PersistirSesionFase1();
            SiguienteMicroJuego();
        }
    }

    
}
