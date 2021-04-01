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

    int numeroBlancos = 3;
    string ubicacionPrefabs = "Microjuegos/Yermis/Prefabs/";


    // Start is called before the first frame update
    void Start()
    {
        //inicializar temporizador
        timer = gameObject.AddComponent<BackwardsTimer>();
        timer.Duration = duracion;

        disparosDisponibles = disparosTotales;
        HUDYermisAtaque.ActualizarDisparos(disparosTotales, disparosDisponibles);

        //Cargar blancos
        GameObject persona;
        for(int i = 0; i < numeroBlancos; i++)
        {
            persona = Resources.Load<GameObject>(ubicacionPrefabs + "Persona");
            Instantiate(persona);
        }

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
        RevisarPonchados();
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

    private void RevisarPonchados()
    {
        GameObject[] personas = GameObject.FindGameObjectsWithTag("personaYermis");
        int ponchados = 0;
        foreach(GameObject persona in personas)
        {
            if (persona.GetComponent<PersonaYermis>().Ponchado)
            {
                ponchados++;
            }
        }
        if(timer.Running && ponchados == numeroBlancos)
        {
            timer.Stop();
            Ganar();
        }
        if(disparosDisponibles == 0 && ponchados < numeroBlancos)
        {
            Perder();
        }
        if(timer.Finished && ponchados < numeroBlancos)
        {
            Perder();
        }
    }

    private void Ganar()
    {
        print("victoria");
    }

    private void Perder()
    {
        print("derrota");
    }
}
