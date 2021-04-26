using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorFuerza : MonoBehaviour
{
    float fuerza;
    int multiplicador = 1;
    float multiplicadorFuerza = 5;
    float posXMinima = -1.7f;
    float posXMaxima = 1.7f;
    float incrementoX = RanaUtils.VelocidadBarraFuerza;
    Vector3 posInicial = new Vector3(0, -4.4f, 0);
    bool enMovimiento = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = posInicial;
    }

    // Update is called once per frame
    void Update()
    {
        if (enMovimiento)
        {
            Mover();
            RevisarDisparo();
        }
    }

    public void EmpezarMovimiento()
    {
        gameObject.transform.position = posInicial;
        enMovimiento = true;
    }

    private void RevisarDisparo()
    {
        if(Input.GetMouseButtonDown(0) && !MenuPausa.pausado) {
            Camera.main.GetComponent<Rana>().InvocarRevisarFinAros();
            enMovimiento = false;
            fuerza = Mathf.Log(multiplicadorFuerza * (gameObject.transform.position.x + posXMaxima)) * multiplicadorFuerza;          
            GameObject.FindGameObjectWithTag("flechaRotatoria").GetComponent<FlechaRana>().DispararAro(fuerza);
            GetComponent<SpriteRenderer>().enabled = false;
            foreach (GameObject barra in GameObject.FindGameObjectsWithTag("barraPaciencia"))
            {
                barra.GetComponent<SpriteRenderer>().enabled = false;
            }
            Invoke("SiguienteDisparo", 0.2f);
        }
    }

    private void SiguienteDisparo()
    {
        GameObject.FindGameObjectWithTag("flechaRotatoria").GetComponent<FlechaRana>().Rotando = true;
    }

    private void Mover()
    {
        Vector3 posActual = gameObject.transform.position;
        if(posActual.x >= posXMaxima || posActual.x <= posXMinima)
        {
            multiplicador *= -1;
        }
        posActual.x += multiplicador * incrementoX * Time.deltaTime;
        gameObject.transform.position = posActual;
    }
}
