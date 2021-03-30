using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapa : MonoBehaviour
{
    string ubicacionSprites = "Microjuegos/Yermis/Sprites/";
    SpriteRenderer spriteRenderer;
    Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        int opcionSprite = Random.Range(1, 5);
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (opcionSprite)
        {
            case 1:
                sprite = Resources.Load<Sprite>(ubicacionSprites + "tapaRoja");
                break;
            case 2:
                sprite = Resources.Load<Sprite>(ubicacionSprites + "tapaNaranja");
                break;
            case 3:
                sprite = Resources.Load<Sprite>(ubicacionSprites + "tapaAmarilla");
                break;
            default:
                sprite = Resources.Load<Sprite>(ubicacionSprites + "tapaGris");
                break;
        }
        spriteRenderer.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
