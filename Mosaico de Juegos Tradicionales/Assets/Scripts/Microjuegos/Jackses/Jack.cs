using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jack : MonoBehaviour
{
    Sprite sprite;
    SpriteRenderer spriteRenderer;
    string spritesLocation = "Microjuegos/Jackses/Sprites/";

    bool agarrable = false;

    AgarrarJackEventActivado agarrarJackEventActivado;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int numSprite = Random.Range(1, 5);
        
        switch (numSprite)
        {
            case 1:
                sprite = Resources.Load<Sprite>(spritesLocation + "jackrojo");
                break;
            case 2:
                sprite = Resources.Load<Sprite>(spritesLocation + "jackazul");
                break;
            case 3:
                sprite = Resources.Load<Sprite>(spritesLocation + "jackamarillo");
                break;
            case 4:
                sprite = Resources.Load<Sprite>(spritesLocation + "jackverde");
                break;
            default:
                break;
        }
        spriteRenderer.sprite = sprite;
        numSprite = Random.Range(1, 3);
        if(numSprite%2 == 0)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
            Vector3 pos = gameObject.transform.position;
            pos.y = -3.42f;
            gameObject.transform.position = pos;
        }

        //Agregar funcion HabilitarJack al manejador de eventos
        EventManagerJackses.AgregarBolaSoltadaListener(HabilitarJack);

        agarrarJackEventActivado = new AgarrarJackEventActivado();
        EventManagerJackses.AgregarInvocadorAgarrarJack(this);
    }

    public void AgregarAgarrarJackListener(UnityAction listener)
    {
        agarrarJackEventActivado.AddListener(listener);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HabilitarJack()
    {
        agarrable = true;
    }

    private void OnMouseDown()
    {
        if (!MenuPausa.pausado)
        {
            if (agarrable)
            {
                agarrarJackEventActivado.Invoke();
                Destroy(gameObject);
            }
        }
        
        
    }
}
