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



    //float alturaMaxima = 3, alturaMinima = -2.53f;
    //float distancia;
    //float tiempoRecorrido = JacksesUtils.Duracion;
    //float velocidad;
    //bool agarrable = false, agarrada = false;

    //public bool Agarrable
    //{
    //    set { agarrable = value; }
    //}

    //public bool Agarrada
    //{
    //    get { return agarrada; }
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    gameObject.transform.position = new Vector3(6, 3, 0);
    //    rb2d = gameObject.GetComponent<Rigidbody2D>();
    //    rb2d.gravityScale = 0;
    //    distancia = alturaMaxima - alturaMinima;
    //    float totalDistanciaRecorrido = 3 * distancia;
    //    velocidad = totalDistanciaRecorrido / tiempoRecorrido;
    //    rb2d.velocity = new Vector2(0, -velocidad);

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 pos = transform.position;
    //    if(pos.y <= alturaMinima)
    //    {
    //        rb2d.velocity = new Vector2(0, velocidad);
    //    }
    //    if (pos.y >= alturaMaxima)
    //    {
    //        rb2d.velocity = new Vector2(0, -velocidad);
    //    }
    //}

    //private void OnMouseDown()
    //{
    //    if (agarrable)
    //    {
    //        agarrada = true;
    //    }
    //}




}
