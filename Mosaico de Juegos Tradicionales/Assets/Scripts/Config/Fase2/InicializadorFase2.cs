using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorFase2 : MonoBehaviour
{
    public void IniciarFase2()
    {
        ConfigFase2Utils.Inicializar();
        ManejadorFase2.EmpezarMicrojuegosFase();
    }
}
