using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaYermis : MonoBehaviour
{

    float fuerzaMinima = 5, fuerzaMaxima = 8;

    string ubicacionSprites = "Microjuegos/Yermis/Sprites/";
    bool ponchado = false;

    public bool Ponchado
    {
        get { return ponchado; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        float minPosX = ScreenUtils.ScreenLeft+1;
        float maxPosX = ScreenUtils.ScreenRight-1;
        float minPosY = -1.6f;
        float maxPosY = 3.7f;
        float posX = Random.Range(minPosX, maxPosX);
        float posY = Random.Range(minPosY, maxPosY);
        transform.position = new Vector3(posX, posY, 0);
        Sprite sprite;
        int opcionSprite = Random.Range(1, 3);
        if(opcionSprite == 1)
        {
            sprite = Resources.Load<Sprite>(ubicacionSprites + "persona");
        }
        else
        {
            sprite = Resources.Load<Sprite>(ubicacionSprites + "persona2");
        }
        GetComponent<SpriteRenderer>().sprite = sprite;
        int opcionOrientacion = Random.Range(1, 3);
        Vector3 escala = transform.localScale;
        if (opcionOrientacion > 1)
        {
            escala.x *= -1;
        }
        transform.localScale = escala;
    }

    private void Start()
    {
        Vector3 direccion = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), 0);
        float fuerza = Random.Range(fuerzaMinima, fuerzaMaxima);
        GetComponent<Rigidbody2D>().AddForce(direccion * fuerza, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bolaYermis"))
        {
            GameObject.FindGameObjectWithTag("efectoSonido").GetComponent<AudioSource>().Play();
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.gameObject);
            ponchado = true;
        }
    }
}
