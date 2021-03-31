using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YermisAtaque : MonoBehaviour
{
    //Tiempo
    float duracion = 10;
    BackwardsTimer timer;

    int disparosTotales = 5;
    int disparosDisponibles;

    // Start is called before the first frame update
    void Start()
    {
        //inicializar temporizador
        timer = gameObject.AddComponent<BackwardsTimer>();
        timer.Duration = duracion;

        disparosDisponibles = disparosTotales;
        HUDYermisAtaque.ActualizarDisparos(disparosTotales, disparosDisponibles);

        //correr temporizador
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Running)
        {
            ActualizarTiempo();
        }
        RevisarDisparo();
        
    }

    private void ActualizarTiempo()
    {
        HUDYermisAtaque.ActualizarTiempo(timer.SecondsRemaining);
    }

    private void RevisarDisparo()
    {
        if (Input.GetMouseButtonDown(0) && disparosDisponibles > 0)
        {
            GameObject.FindGameObjectWithTag("flechaRotatoria").GetComponent<FlechaMouse>().DispararBola();
            disparosDisponibles--;
            HUDYermisAtaque.ActualizarDisparos(disparosTotales, disparosDisponibles);
        }
    }
}
