using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chulo : MonoBehaviour
{
    Sprite chulo;
    Sprite equis;
    SpriteRenderer spriteRenderer;
    string ubicacion = "Cutscene/Fase2/";
    Animation anim;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animation>();
        chulo = Resources.Load<Sprite>(ubicacion + "chulo");
        equis = Resources.Load<Sprite>(ubicacion + "equis");
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Perder()
    {
        anim.Play("perderVida");
        Invoke("CambiarAEquis", 1.5f);
    }

    public void CambiarAEquis()
    {
        spriteRenderer.sprite = equis;
    }

    public void CambiarAChulo()
    {
        spriteRenderer.sprite = chulo;
    }
}
