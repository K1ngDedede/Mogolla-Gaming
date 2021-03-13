using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorJuego : MonoBehaviour
{
    private void Awake()
    {
        if (!ConfigUtils.JuegoCargado)
        {
            ConfigUtils.Inicializar();
            ManejadorPersistencia.PersistirSesionJuego();
        }
        
    }
    
}
