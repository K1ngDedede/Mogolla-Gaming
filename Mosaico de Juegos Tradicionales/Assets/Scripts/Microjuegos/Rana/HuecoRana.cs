using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuecoRana : MonoBehaviour
{
    float rangoVelocidad = 8;
    float escalaApropiada = 0.5f;
    float errorEscala = 0.2f;
    int puntaje;

    [SerializeField]
    Vector2 posicionEntrada;

    [SerializeField]
    TipoHueco tipoHueco;
    // Start is called before the first frame update
    void Start()
    {
        switch (tipoHueco) 
        {
            case TipoHueco.BASE:
                puntaje = 30;
                break;
            case TipoHueco.PARED:
                puntaje = 20;
                break;
            case TipoHueco.RANA1:
                puntaje = 100;
                break;
            case TipoHueco.RANA2:
                puntaje = 70;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject aroRana = collision.gameObject;
        Rigidbody2D rb2d = aroRana.GetComponent<Rigidbody2D>();
        Vector2 velocidad = rb2d.velocity;
        float escala = aroRana.transform.localScale.x;
        if(velocidad.magnitude<rangoVelocidad && velocidad.magnitude > -rangoVelocidad && escala>escalaApropiada-errorEscala && escala<escalaApropiada+errorEscala)
        {
            AroRana aroRanaScript = aroRana.GetComponent<AroRana>();
            aroRanaScript.EntrarHueco(posicionEntrada);
            HUDRana.ActualizarPuntaje(puntaje);
            Camera.main.GetComponent<Rana>().AumentarPuntaje(puntaje);
        }
        
    }
}
