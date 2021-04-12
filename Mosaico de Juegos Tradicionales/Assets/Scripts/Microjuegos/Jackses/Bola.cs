using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    Rigidbody2D rb2d;
    float escalaGravedad = JacksesUtils.EscalaGravedad;
    bool soltada = false;
    bool agarrable = false;
    int numeroRebotes = 0;

    //Eventos
    BolaSoltadaEventActivado bolaSoltadaEventActivado;
    PerderSegundoReboteActivado perderSegundoReboteActivado;
    RevisarVictoriaEventoActivado revisarVictoriaEventoActivado;

    private void Start()
    {
        gameObject.transform.position = new Vector3(6, 3, 0);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;

        //Manejo de eventos
        bolaSoltadaEventActivado = new BolaSoltadaEventActivado();
        EventManagerJackses.AgregarInvocadorBolaSoltada(this);

        perderSegundoReboteActivado = new PerderSegundoReboteActivado();
        EventManagerJackses.AgregarInvocadorPerderSegundoRebote(this);

        revisarVictoriaEventoActivado = new RevisarVictoriaEventoActivado();
        EventManagerJackses.AgregarInvocadorRevisarVictoria(this);
    }

    private void OnMouseDown()
    {
        if (!MenuPausa.pausado)
        {
            if (!soltada)
            {
                soltada = true;
                rb2d.gravityScale = escalaGravedad;
                bolaSoltadaEventActivado.Invoke();
            }
            if (agarrable)
            {
                rb2d.velocity = Vector2.zero;
                rb2d.gravityScale = 0;
                GameObject.FindGameObjectWithTag("flechaTutorial").GetComponent<FlechaTutorial>().Deshabilitar();
                revisarVictoriaEventoActivado.Invoke();
            }
        }
        
    }

    public void AgregarBolaSoltadaListener(UnityAction listener)
    {
        bolaSoltadaEventActivado.AddListener(listener);
    }

    public void AgregarPerderSegundoReboteListener(UnityAction listener)
    {
        perderSegundoReboteActivado.AddListener(listener);
    }

    public void AgregarRevisarVictoriaListener(UnityAction listener)
    {
        revisarVictoriaEventoActivado.AddListener(listener);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        numeroRebotes++;
        if(numeroRebotes == 1)
        {
            agarrable = true;
        }
        if (numeroRebotes == 2)
        {
            rb2d.gravityScale = 1.5f;
            perderSegundoReboteActivado.Invoke();
        }
    }

}
