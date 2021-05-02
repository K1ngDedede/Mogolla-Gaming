using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroRana : MonoBehaviour
{
    Rigidbody2D rb2d;
    bool disparado;
    float anguloActual = 0;
    float incrementoAngulo = 500;
    float escalaMinima = 0.4f;
    float decrementoEscala = 0.6f;
    bool entro = false;
    float velocidadMovimiento = 2f;
    float velocidadFade = 1f;
    float rangoExistenciaMinX = -5;
    float rangoExistenciaMaxX = 5;
    Vector2 posicionEntrada;
    Vector3 rotacion;
    // Start is called before the first frame update
    void Start()
    {
        rotacion = new Vector3(0, 0, anguloActual);
        gameObject.transform.Rotate(rotacion);
    }

    // Update is called once per frame
    void Update()
    {
        Rotar();
        if (disparado)
        {
            ReducirEscala();
            RevisarUbicacion();
        }
        if (entro)
        {
            MoverAHueco();
            FadeAway();
        }
    }

    private void RevisarUbicacion()
    {
        Vector2 pos = gameObject.transform.position;
        if(pos.x<rangoExistenciaMinX || pos.x>rangoExistenciaMaxX)
        {
            FadeAway();
        }
    }

    private void ReducirEscala()
    {
        print(GetComponent<Rigidbody2D>().velocity.y);
        Vector3 escalaActual = gameObject.transform.localScale;
        if (escalaActual.x > escalaMinima)
        {
            escalaActual.x -= decrementoEscala * Time.deltaTime;
            escalaActual.y -= decrementoEscala * Time.deltaTime;
            gameObject.transform.localScale = escalaActual;
        }
    }

    private void Rotar()
    {
        anguloActual +=  incrementoAngulo * Time.deltaTime;
        rotacion = new Vector3(0, 0, anguloActual);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, anguloActual);
    }

    public void Disparar(Vector3 rotacion, float fuerza)
    {
        disparado = true;
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.gravityScale = 0;
        float anguloRad = rotacion.z * Mathf.Deg2Rad;
        Vector3 direccion = new Vector3(Mathf.Cos(anguloRad), Mathf.Sin(anguloRad), 0);
        rb2d.AddForce(direccion * fuerza, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void EntrarHueco(Vector2 posicionEntrada)
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.zero;
        rb2d.gravityScale = 0;
        entro = true;
        this.posicionEntrada = posicionEntrada;
    }

    private void MoverAHueco()
    {
        Vector2 posicionActual = gameObject.transform.position;
        if (posicionActual.x > posicionEntrada.x)
        {
            posicionActual.x -= velocidadMovimiento * Time.deltaTime;
        }
        else
        {
            posicionActual.x += velocidadMovimiento * Time.deltaTime;
        }
        if (posicionActual.y > posicionEntrada.y)
        {
            posicionActual.y -= velocidadMovimiento * Time.deltaTime;
        }
        else
        {
            posicionActual.y += velocidadMovimiento * Time.deltaTime;
        }
        gameObject.transform.position = posicionActual;
    }

    private void FadeAway()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a -= velocidadFade * Time.deltaTime;
        if(color.a <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
