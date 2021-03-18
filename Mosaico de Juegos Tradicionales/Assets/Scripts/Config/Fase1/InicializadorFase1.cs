using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorFase1 : MonoBehaviour
{
    public void EmpezarTutorial()
    {
        ConfigFase1Utils.Inicializar();
        if (ConfigUtils.Fase > 1)
        {
            ManejadorFase1.EmpezarMicrojuegosFase();
        }
        else
        {
            ManejadorFase1.EmpezarTutorial();
        }
    }
}
