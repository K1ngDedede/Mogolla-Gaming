using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    Rigidbody2D rb2d;
    bool segundoRebote = false;
    bool soltado;
    int rebotes = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(6, 3, 0);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        soltado = false;
    }



    public bool Soltado
    {
        get { return soltado; }
    }

    public bool SegundoRebote
    {
        get { return segundoRebote; }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Detener()
    {
        rb2d.velocity = new Vector2(0, 0);
        rb2d.gravityScale = 0;
        rebotes = 0;
        soltado = false;
    }

    private void OnMouseDown()
    {
        if (!soltado)
        {
            DejarCaer();
        }   
        if(rebotes == 1)
        {
            rb2d.velocity = new Vector2(0, 0);
            rb2d.gravityScale = 0;
            rebotes = 0;
            soltado = false;
        }
    }

    private void DejarCaer()
    {
        soltado = true;
        rb2d.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rebotes++;
        if (rebotes >= 2)
        {
            segundoRebote = true;
        }
    }
}
