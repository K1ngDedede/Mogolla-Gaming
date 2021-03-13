using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ManejadorFase1
{
    public static void EmpezarMicrojuegosFase()
    {
        SceneManager.LoadScene("escenaIntermediaFase1");
    }

    private static void SiguienteMicroJuego()
    {
        SceneManager.LoadScene("escenaIntermediaFase1");
    }

    public static void PerderVida()
    {
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
            ManejadorPersistencia.PersistirSesionFase1();
            //cargar escena de derrota
            SceneManager.LoadScene("menu1");
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
            ManejadorPersistencia.PersistirSesionFase1();

            SceneManager.LoadScene("menu1");
        }
        else
        {
            SiguienteMicroJuego();
        }
    }

    
}
