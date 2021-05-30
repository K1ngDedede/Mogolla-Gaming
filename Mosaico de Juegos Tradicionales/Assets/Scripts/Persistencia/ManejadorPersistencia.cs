using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;

public static class ManejadorPersistencia
{
    static string endpoint = "https://proyecto-de-grado-7e7d3-default-rtdb.firebaseio.com/";


    private static void Login()
    {
        
    }

    public static void PersistirSesionJuego()
    {
        //RegistrarAnonimo();
        RestClient.Put(endpoint + "sesiones_version_final/" + ConfigUtils.Fecha + "/.json", new Sesion { fecha = ConfigUtils.Fecha}).Then(response =>
        {
  
        });
    }
    
    public static void PersistirSesionFase1()
    {
        
        RestClient.Put(endpoint + "sesiones_version_final/" + ConfigUtils.Fecha+"/statsF1/"+ ConfigFase1Utils.Fecha +"/.json", new SesionFase1 {vidasRestantes = ConfigFase1Utils.VidasRestantes, 
            juegosPerdidos = ConfigFase1Utils.VidasTotales - ConfigFase1Utils.VidasRestantes, 
            tiempoRestanteJackses = JacksesUtils.TiempoRestante, 
            intentosTutorial = ConfigFase1Utils.IntentosTutorial,
            faseTerminada = ConfigFase1Utils.SesionFase1Terminada,
            microjuegosPerdidos = ConfigFase1Utils.MicrojuegosPerdidos.ToArray()}).Then(response => {
            });
    }

}
