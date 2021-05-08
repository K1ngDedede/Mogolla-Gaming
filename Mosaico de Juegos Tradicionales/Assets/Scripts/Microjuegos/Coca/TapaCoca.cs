using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapaCoca : MonoBehaviour
{
    bool siguiendoCuerda = true;
    float fuerzaX = 2;
    float fuerzaY = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (siguiendoCuerda)
        {
            SeguirCuerda();
        }
        
        
    }

    private void SeguirCuerda()
    {
        Vector2 posFinalCuerda = GameObject.FindGameObjectWithTag("cuerda").GetComponent<Cuerda>().PosFinal;
        transform.position = posFinalCuerda;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            siguiendoCuerda = false;
            GameObject.FindGameObjectWithTag("cuerda").GetComponent<Cuerda>().SiguiendoTapa = true;
            VerificarEncholada();
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        siguiendoCuerda = true;
        GameObject.FindGameObjectWithTag("cuerda").GetComponent<Cuerda>().SiguiendoTapa = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    private void VerificarEncholada()
    {
        float offset = 0.38f;
        GameObject palo = GameObject.FindGameObjectWithTag("palo");
        Vector3 posPalo = palo.transform.position;
        Vector3 posTapa = transform.position;
        if(posPalo.x<=posTapa.x + offset && posPalo.x>posTapa.x - offset)
        {
            palo.GetComponent<PaloCoca>().SiguiendoMouse = false;
            GameObject.FindGameObjectWithTag("cuerda").GetComponent<Cuerda>().SiguiendoMouse = false;
            palo.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            Camera.main.GetComponent<Coca>().Encholar();
        }
        else
        {
            
            Vector3 fuerza = new Vector3(fuerzaX,fuerzaY,0);
            if (posPalo.x > posTapa.x)
            {
                fuerza.x = -fuerzaX;
            }
            
            GetComponent<Rigidbody2D>().AddForce(fuerza, ForceMode2D.Impulse);
        }
    }
}
