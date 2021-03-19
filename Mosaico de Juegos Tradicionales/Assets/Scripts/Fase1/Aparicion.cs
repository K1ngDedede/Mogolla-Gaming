using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aparicion : MonoBehaviour
{
    [SerializeField]
    float tiempo;

    Animator anim;
    SpriteRenderer spriteRenderer;
    Image image;
    Text text;
    private void Awake()
    {
        
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
        anim = gameObject.GetComponent<Animator>();
        text = gameObject.GetComponent<Text>();
        if (anim != null)
        {
            anim.enabled = false;
        }
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
        if (image != null)
        {
            image.enabled = false;
        }
        if (text != null)
        {
            text.enabled = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("Visibilizar", tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Visibilizar()
    {
        
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }
        if (anim != null)
        {
            anim.enabled = true;
        }
        if (image != null)
        {
            image.enabled = true;
        }
        if (text != null)
        {
            text.enabled = true;
        }

    }
}
