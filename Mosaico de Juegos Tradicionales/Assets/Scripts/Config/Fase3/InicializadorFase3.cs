using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorFase3 : MonoBehaviour
{
    public void IniciarFase3()
    {
        ConfigFase3Utils.Inicializar();
        ManejadorFase3.EmpezarMicrojuegosFase();
    }
}
