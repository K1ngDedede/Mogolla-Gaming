using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ManejadorFase2
{
    public static void RegistrarPerdidaMicrojuego(string microjuego)
    {
        ConfigFase2Utils.RegistrarPerdidaMicrojuego(microjuego);
    }

    public static void RegistrarVictoria()
    {
        ConfigFase2Utils.AcabaDePerder = false;
    }


    public static void EmpezarMicrojuegosFase()
    {
        SceneManager.LoadScene("escenaIntermediaFase2");
    }

    private static void SiguienteMicroJuego()
    {
        SceneManager.LoadScene("escenaIntermediaFase2");
    }

    public static void PerderVida()
    {
        ConfigFase2Utils.AcabaDePerder = true;
        ConfigFase2Utils.PerderVida();
    }

    public static void AumentarMicrojuegosJugados()
    {
        ConfigFase2Utils.AumentarMicrojuegosJugados();
    }

    public static void RevisarFinFase()
    {
        //revisar si perdio la fase
        if (ConfigFase2Utils.VidasRestantes <= 0)
        {
            //persistir sesion
            ConfigFase2Utils.SesionFase2Terminada = true;
            //ManejadorPersistencia.PersistirSesionFase1();
            //cargar escena de derrota
            SceneManager.LoadScene("derrotaFase2");
        }

        //revisar si gano la fase
        else if (ConfigFase2Utils.NumMicrojuegosJugados == ConfigFase2Utils.MicrojuegosAJugar.Count)
        {
            //cargar escena de victoria
            if (ConfigUtils.Fase == 2)
            {
                ConfigUtils.Fase = 3;
            }
            //persistir sesion
            ConfigFase2Utils.SesionFase2Terminada = true;
            //ManejadorPersistencia.PersistirSesionFase1();
            SceneManager.LoadScene("victoriaFase2");
        }
        else
        {
            //ManejadorPersistencia.PersistirSesionFase1();
            SiguienteMicroJuego();
        }
    }
}
