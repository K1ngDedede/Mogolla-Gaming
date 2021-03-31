using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaYermis : MonoBehaviour
{
    float incrementoAngulo = 80;
    float anguloActual = 90, anguloMaximo = 180, anguloMinimo = 0;
    int multiplicador = 1;
    Vector3 rotacion;
    bool rotando = true;

    // Start is called before the first frame update
    void Start()
    {
        rotacion = new Vector3(0, 0, anguloActual);
        gameObject.transform.Rotate(rotacion);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotando)
        {
            if (anguloActual > anguloMaximo)
            {
                multiplicador = -1;
            }
            if (anguloActual < anguloMinimo)
            {
                multiplicador = 1;
            }
            anguloActual += multiplicador * incrementoAngulo * Time.deltaTime;
            rotacion = new Vector3(0, 0, anguloActual);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, anguloActual);
            if (Input.GetMouseButtonDown(0))
            {

                DispararBola();
            }
        }
        
    }

    public void DispararBola()
    {
        rotando = false;
        Camera.main.GetComponent<TorreTapas>().BolaDisparada = true;
        GameObject bolaYermis = Resources.Load<GameObject>("Microjuegos/Yermis/Prefabs/BolaYermis");
        Instantiate(bolaYermis);
        bolaYermis.transform.position = new Vector3(0, -4.5f, 0);
        
        bolaYermis = GameObject.FindGameObjectWithTag("bolaYermis");
        BolaYermis bolaScript = bolaYermis.GetComponent<BolaYermis>();
        bolaScript.Disparar(rotacion);
    }
}
