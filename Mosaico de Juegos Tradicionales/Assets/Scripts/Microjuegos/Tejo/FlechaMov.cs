using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaMov : MonoBehaviour
{
    float incrementoAngulo = YermisUtils.IncrementoAnguloFlecha;
    float anguloActual = 0, anguloMaximo = 90, anguloMinimo = -90;
    int multiplicador = 1;
    Vector3 rotacion;
    bool rotando = true;
    public GameObject o;
    public GameObject tejo;
    GameObject tejoClone;
    GameObject pbClone;
    PowerBar powerBar;

    // Start is called before the first frame update
    void Start()
    {
        rotacion = new Vector3(0, 0, anguloActual);
        gameObject.transform.Rotate(rotacion);
        powerBar = o.GetComponent<PowerBar>();
        powerBar.setFlecha(transform.gameObject);
        tejoClone = Instantiate(tejo, new Vector3(0, -3, 0), Quaternion.identity);
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
            if (!MenuPausa.pausado)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    powerBar.startPowerBar(anguloActual, tejoClone);
                    rotando = false;
                }
            }
        }
        
    }

    public void DispararBola()
    {
        rotando = false;
        Camera.main.GetComponent<TorreTapas>().BolaDisparada = true;
        GameObject bolaYermis = Resources.Load<GameObject>("Microjuegos/Yermis/Prefabs/BolaYermis");
        bolaYermis.transform.position = new Vector3(0, -4.5f, 0);
        Instantiate(bolaYermis);
        
        
        bolaYermis = GameObject.FindGameObjectWithTag("bolaYermis");
        BolaYermis bolaScript = bolaYermis.GetComponent<BolaYermis>();
        bolaScript.Disparar(rotacion);
    }

    public void Res()
    {
        tejoClone = Instantiate(tejo, new Vector3(0, -3, 0), Quaternion.identity);
        rotando = true;
    }
}
