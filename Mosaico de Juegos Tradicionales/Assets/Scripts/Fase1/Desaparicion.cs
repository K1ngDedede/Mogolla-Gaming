using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desaparicion : MonoBehaviour
{
    [SerializeField]
    float tiempo;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Invisibilizar", tiempo);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Invisibilizar()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.enabled = false;
        }
        if(spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }
}
