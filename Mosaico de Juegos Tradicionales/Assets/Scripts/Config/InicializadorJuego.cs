using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorJuego : MonoBehaviour
{
    private void Awake()
    {
        ConfigUtils.Inicializar();
    }
}
