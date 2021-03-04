using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour
{
    Vector3 posMouse;
    Sprite manoAbierta, manoCerrada;
    SpriteRenderer spriteRenderer;
    string spritesLocation = "Microjuegos/Jackses/Sprites/";
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        manoAbierta = Resources.Load<Sprite>(spritesLocation + "mano_abierta");
        manoCerrada = Resources.Load<Sprite>(spritesLocation + "mano_cerrada");
    }

    // Update is called once per frame
    void Update()
    {
        posMouse = Input.mousePosition;
        posMouse.z = -Camera.main.transform.position.z;
        posMouse = Camera.main.ScreenToWorldPoint(posMouse);
        gameObject.transform.position = posMouse;
        if (Input.GetMouseButtonDown(0))
        {
            spriteRenderer.sprite = manoCerrada;
        }
        if (Input.GetMouseButtonUp(0))
        {
            spriteRenderer.sprite = manoAbierta;
        }
    }

    //private void OnMouseDown()
    //{
    //    spriteRenderer.sprite = manoCerrada;
    //    print("mouse down");
    //}

    //private void OnMouseUp()
    //{
    //    spriteRenderer.sprite = manoAbierta;
    //    print("mouse up");
    //}
    
}
