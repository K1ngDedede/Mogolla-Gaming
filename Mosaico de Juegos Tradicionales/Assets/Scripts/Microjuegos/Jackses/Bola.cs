using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    Rigidbody2D rb2d;
    float alturaMaxima = 3, alturaMinima = -2.53f;
    float distancia;
    float tiempoRecorrido = JacksesUtils.Duracion;
    float velocidad;
    bool agarrable = false, agarrada = false;

    public bool Agarrable
    {
        set { agarrable = value; }
    }

    public bool Agarrada
    {
        get { return agarrada; }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(6, 3, 0);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        distancia = alturaMaxima - alturaMinima;
        float totalDistanciaRecorrido = 3 * distancia;
        velocidad = totalDistanciaRecorrido / tiempoRecorrido;
        rb2d.velocity = new Vector2(0, -velocidad);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(pos.y <= alturaMinima)
        {
            rb2d.velocity = new Vector2(0, velocidad);
        }
        if (pos.y >= alturaMaxima)
        {
            rb2d.velocity = new Vector2(0, -velocidad);
        }
    }

    private void OnMouseDown()
    {
        if (agarrable)
        {
            agarrada = true;
        }
    }


}
