using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YermisDefensa : MonoBehaviour
{
    Vector3 posMouse;
    string ubicacionSprites = "Microjuegos/Yermis/Sprites/";
    string ubicacionPrefabs = "Microjuegos/Yermis/Prefabs/";
    SpriteRenderer spriteRenderer;

    int numeroBolas = 5;
    int bolasDisparadas = 0;
    float duracionJuego = 12, intervaloBolas;
    float fuerzaMinBolas = 5, fuerzaMaxBolas = 10;
    float anguloMaxDisparo = 45;

    //Timers
    Timer timerBolas;
    BackwardsTimer timer;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        int opcionSprite = Random.Range(1, 3);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite sprite;
        if(opcionSprite == 1)
        {
            sprite = Resources.Load<Sprite>(ubicacionSprites + "persona");
        }
        else
        {
            sprite = Resources.Load<Sprite>(ubicacionSprites + "persona2");
        }
        spriteRenderer.sprite = sprite;
        opcionSprite = Random.Range(1, 3);
        if (opcionSprite == 1)
        {
            Vector3 escala = gameObject.transform.localScale;
            escala.x *= -1;
            gameObject.transform.localScale = escala;
        }
        intervaloBolas = duracionJuego / numeroBolas;
        timerBolas = gameObject.AddComponent<Timer>();
        timer = gameObject.AddComponent<BackwardsTimer>();

        timerBolas.Duration = intervaloBolas;
        timer.Duration = duracionJuego;
        timer.Run();
        timerBolas.Run();
        DispararBola();
    }

    // Update is called once per frame
    void Update()
    {
        SeguirMouse();
        ActualizarHUD();
        RevisarDisparo();
        if (timer.Finished)
        {
            Ganar();
            timerBolas.Stop();
        }
    }

    private void SeguirMouse()
    {
        posMouse = Input.mousePosition;
        posMouse.z = -Camera.main.transform.position.z;
        posMouse = Camera.main.ScreenToWorldPoint(posMouse);
        gameObject.transform.position = posMouse;
    }

    private void RevisarDisparo()
    {
        if (timerBolas.Finished && bolasDisparadas<numeroBolas-1)
        {
            DispararBola();
            bolasDisparadas++;
            timerBolas.Run();
        }
    }

    private void DispararBola()
    {
        int lado = Random.Range(1, 5);
        float fuerza = Random.Range(fuerzaMinBolas, fuerzaMaxBolas);
        float angulo = Random.Range(-anguloMaxDisparo/2, anguloMaxDisparo/2);
        GameObject bola = Resources.Load<GameObject>(ubicacionPrefabs + "BolaYermis");
        bola.GetComponent<BolaYermis>().Disparada = true;
        switch (lado)
        {
            case 1:
                DispararDesdeArriba(fuerza, angulo, bola);
                break;
            case 2:
                DispararDesdeAbajo(fuerza, angulo, bola);
                break;
            case 3:
                DispararDesdeDerecha(fuerza, angulo, bola);
                break;
            default:
                DispararDesdeIzquierda(fuerza, angulo, bola);
                break;
        }
    }

    private void DispararDesdeArriba(float fuerza, float angulo, GameObject bola)
    {
        float nuevoAngulo = angulo - 90;
        Vector3 direccion = new Vector3(Mathf.Cos(nuevoAngulo * Mathf.Deg2Rad), Mathf.Sin(nuevoAngulo * Mathf.Deg2Rad), 0);
        Vector3 posicion = new Vector3(0, ScreenUtils.ScreenTop + bola.GetComponent<CircleCollider2D>().radius, 0);
        bola.transform.position = posicion;
        Rigidbody2D rb2d = bola.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        Instantiate(bola);
        GameObject[] bolas = GameObject.FindGameObjectsWithTag("bolaYermis");
        foreach(GameObject ball in bolas)
        {
            if (!ball.GetComponent<BolaYermis>().Disparada)
            {
                rb2d = ball.GetComponent<Rigidbody2D>();
                rb2d.AddForce(direccion * fuerza, ForceMode2D.Impulse);
                ball.GetComponent<BolaYermis>().Disparada = true;
            }
        }
        
    }

    private void DispararDesdeAbajo(float fuerza, float angulo, GameObject bola)
    {
        float nuevoAngulo = angulo + 90;
        Vector3 direccion = new Vector3(Mathf.Cos(nuevoAngulo * Mathf.Deg2Rad), Mathf.Sin(nuevoAngulo * Mathf.Deg2Rad), 0);
        Vector3 posicion = new Vector3(0, ScreenUtils.ScreenBottom - bola.GetComponent<CircleCollider2D>().radius, 0);
        bola.transform.position = posicion;
        Rigidbody2D rb2d = bola.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        Instantiate(bola);
        GameObject[] bolas = GameObject.FindGameObjectsWithTag("bolaYermis");
        foreach (GameObject ball in bolas)
        {
            if (!ball.GetComponent<BolaYermis>().Disparada)
            {
                rb2d = ball.GetComponent<Rigidbody2D>();
                rb2d.AddForce(direccion * fuerza, ForceMode2D.Impulse);
                ball.GetComponent<BolaYermis>().Disparada = true;
            }
        }
    }

    private void DispararDesdeDerecha(float fuerza, float angulo, GameObject bola)
    {
        float nuevoAngulo = angulo;
        Vector3 direccion = new Vector3(Mathf.Cos(nuevoAngulo * Mathf.Deg2Rad), Mathf.Sin(nuevoAngulo * Mathf.Deg2Rad), 0);
        Vector3 posicion = new Vector3(ScreenUtils.ScreenLeft - bola.GetComponent<CircleCollider2D>().radius, 0, 0);
        bola.transform.position = posicion;
        Rigidbody2D rb2d = bola.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        Instantiate(bola);
        GameObject[] bolas = GameObject.FindGameObjectsWithTag("bolaYermis");
        foreach (GameObject ball in bolas)
        {
            if (!ball.GetComponent<BolaYermis>().Disparada)
            {
                rb2d = ball.GetComponent<Rigidbody2D>();
                rb2d.AddForce(direccion * fuerza, ForceMode2D.Impulse);
                ball.GetComponent<BolaYermis>().Disparada = true;
            }
        }
    }

    private void DispararDesdeIzquierda(float fuerza, float angulo, GameObject bola)
    {
        float nuevoAngulo = angulo+180;
        Vector3 direccion = new Vector3(Mathf.Cos(nuevoAngulo * Mathf.Deg2Rad), Mathf.Sin(nuevoAngulo * Mathf.Deg2Rad), 0);
        Vector3 posicion = new Vector3(ScreenUtils.ScreenRight + bola.GetComponent<CircleCollider2D>().radius, 0, 0);
        bola.transform.position = posicion;
        Rigidbody2D rb2d = bola.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        Instantiate(bola);
        GameObject[] bolas = GameObject.FindGameObjectsWithTag("bolaYermis");
        foreach (GameObject ball in bolas)
        {
            if (!ball.GetComponent<BolaYermis>().Disparada)
            {
                rb2d = ball.GetComponent<Rigidbody2D>();
                rb2d.AddForce(direccion * fuerza, ForceMode2D.Impulse);
                ball.GetComponent<BolaYermis>().Disparada = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bolaYermis"))
        {
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            Perder();
        }
    }

    private void ActualizarHUD()
    {
        HUDYermisDefensa.ActualizarTiempo(timer.SecondsRemaining);
    }

    private void Perder()
    {
        timer.Stop();
        print("derrota");
    }

    private void Ganar()
    {
        print("victoria");
    }
}
