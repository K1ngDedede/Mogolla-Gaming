using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;

public static class ManejadorPersistencia
{
    static string endpoint = "https://proyecto-de-grado-7e7d3-default-rtdb.firebaseio.com/";
    //static string endpointAuth = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyAGVYtptYjUzEB1yAbgMXq_6Fwsv63qItc";
    //static string endpointLogin = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithCustomToken?key=AIzaSyAGVYtptYjUzEB1yAbgMXq_6Fwsv63qItc";
    static string idToken;


    //private static void RegistrarAnonimo()
    //{
    //    RestClient.Post(endpointAuth, null).Then(response=> {
    //        string responseText = response.Text;
    //        responseText = responseText.Replace("}", "");
    //        responseText = responseText.Replace("{", "");
    //        idToken = responseText;
    //    });
    //}

    private static void Login()
    {
        
    }

    public static void PersistirSesionJuego()
    {
        //RegistrarAnonimo();
        RestClient.Put(endpoint + "sesiones_prueba/" + ConfigUtils.Fecha + "/.json", new Sesion { fecha = ConfigUtils.Fecha}).Then(response =>
        {
  
        });
    }
    
    public static void PersistirSesionFase1()
    {
        
        RestClient.Put(endpoint + "sesiones_prueba/" + ConfigUtils.Fecha+"/statsF1/"+ ConfigFase1Utils.Fecha +"/.json", new SesionFase1 {vidasRestantes = ConfigFase1Utils.VidasRestantes, 
            juegosPerdidos = ConfigFase1Utils.VidasTotales - ConfigFase1Utils.VidasRestantes, 
            tiempoRestanteJackses = JacksesUtils.TiempoRestante, 
            intentosTutorial = ConfigFase1Utils.IntentosTutorial,
            faseTerminada = ConfigFase1Utils.SesionFase1Terminada,
            microjuegosPerdidos = ConfigFase1Utils.MicrojuegosPerdidos.ToArray()}).Then(response => {
            });
    }

}
