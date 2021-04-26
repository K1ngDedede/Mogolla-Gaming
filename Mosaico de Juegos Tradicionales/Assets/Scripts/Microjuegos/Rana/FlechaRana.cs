using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaRana : MonoBehaviour
{

    float incrementoAngulo = RanaUtils.IncrementoAngulo;
    float anguloActual = 90, anguloMaximo = 180, anguloMinimo = 0;
    int multiplicador = 1;
    Vector3 rotacion;
    bool rotando = true;
    int numeroAros = RanaUtils.NumeroAros;
    int numeroDisparos = 0;
    // Start is called before the first frame update
    void Start()
    {
        rotacion = new Vector3(0, 0, anguloActual);
        gameObject.transform.Rotate(rotacion);
        foreach(GameObject barra in GameObject.FindGameObjectsWithTag("barraPaciencia"))
        {
            barra.GetComponent<SpriteRenderer>().enabled = false;
        }
        GameObject.FindGameObjectWithTag("flechas").GetComponent<SpriteRenderer>().enabled = false;
    }

    public bool Rotando
    {
        set { rotando = value; }
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
            
                if (Input.GetMouseButtonDown(0) && numeroDisparos<numeroAros && !MenuPausa.pausado)
                {
                    Camera.main.GetComponent<Rana>().RevisarDisparo();
                    rotando = false;
                    foreach (GameObject barra in GameObject.FindGameObjectsWithTag("barraPaciencia"))
                    {
                        barra.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    GameObject.FindGameObjectWithTag("flechas").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.FindGameObjectWithTag("flechas").GetComponent<IndicadorFuerza>().EmpezarMovimiento();
                    numeroDisparos ++;
                }

        }
    }


    public void DispararAro(float fuerza)
    {
        GameObject aroRana = Resources.Load<GameObject>("Microjuegos/Rana/Prefabs/AroRana");
        aroRana.transform.position = new Vector3(0, -4.5f, 0);
        Instantiate(aroRana);


        GameObject[] arosRana = GameObject.FindGameObjectsWithTag("aroRana");
        aroRana = arosRana[arosRana.Length - 1];
        AroRana ranaScript = aroRana.GetComponent<AroRana>();
        ranaScript.Disparar(rotacion, fuerza);
    }
}
