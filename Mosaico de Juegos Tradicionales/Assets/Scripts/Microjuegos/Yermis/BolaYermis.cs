using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaYermis : MonoBehaviour
{
    float fuerza = 60;
    Rigidbody2D rb2d;
    bool disparada = false;

    public float Fuerza
    {
        set { fuerza = value; }
    }

    public bool Disparada
    {
        get { return disparada; }
    }

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disparar(Vector3 rotacion)
    {
        disparada = true;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        float anguloRad = rotacion.z * Mathf.Deg2Rad;
        Vector3 direccion = new Vector3(Mathf.Cos(anguloRad), Mathf.Sin(anguloRad), 0);
        rb2d.AddForce(direccion * fuerza, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tapaYermis"))
        {
            Camera.main.GetComponent<TorreTapas>().TorreTumbada = true;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
