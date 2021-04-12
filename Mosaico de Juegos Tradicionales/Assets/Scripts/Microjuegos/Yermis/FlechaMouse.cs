using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaMouse : MonoBehaviour
{
    float fuerza = 20;
    Vector3 direccion, posMouse;
    int disparos;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuPausa.pausado)
        {
            SeguirMouse();
        }
        
    }

    private void SeguirMouse()
    {
        posMouse = Input.mousePosition;
        posMouse.z = -Camera.main.transform.position.z;
        posMouse = Camera.main.ScreenToWorldPoint(posMouse);

        direccion = new Vector3(posMouse.x - transform.position.x, posMouse.y - transform.position.y, 0);
        gameObject.transform.right = direccion;
    }

    public void DispararBola()
    {
        GameObject bolaYermis = Resources.Load<GameObject>("Microjuegos/Yermis/Prefabs/BolaYermis");
        bolaYermis.transform.localScale = new Vector3(0.4f, 0.4f, 0);
        Instantiate(bolaYermis);
        bolaYermis.transform.position = new Vector3(0, -4.5f, 0);
        GameObject[] bolas;
        bolas = GameObject.FindGameObjectsWithTag("bolaYermis");
        foreach(GameObject bola in bolas)
        {
            BolaYermis bolaScript = bola.GetComponent<BolaYermis>();
            if (!bolaScript.Disparada)
            {
                bolaScript.Fuerza = fuerza;
                bolaScript.Disparar(new Vector3(0, 0, transform.rotation.eulerAngles.z));
            }
        }
        
    }
}
