using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorFase1 : MonoBehaviour
{
    private void Awake()
    {
        ConfigFase1Utils.Inicializar();
        ManejadorFase1.EmpezarMicrojuegosFase();
    }
}
