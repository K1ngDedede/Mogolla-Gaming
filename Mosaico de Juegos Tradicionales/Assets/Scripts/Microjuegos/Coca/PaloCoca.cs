using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaloCoca : MonoBehaviour
{
    bool siguiendoMouse = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool SiguiendoMouse
    {
        get { return siguiendoMouse; }
        set { siguiendoMouse = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if(siguiendoMouse && !MenuPausa.pausado)
        {
            SeguirMouse();
        }
        
    }

    void SeguirMouse()
    {
        Vector3 posMouse = Input.mousePosition;
        posMouse.z = -Camera.main.transform.position.z;
        posMouse = Camera.main.ScreenToWorldPoint(posMouse);
        gameObject.transform.position = posMouse;
    }
}
