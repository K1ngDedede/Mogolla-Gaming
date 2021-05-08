using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guias : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        SeguirCuerda();
    }

    private void SeguirCuerda()
    {
        Vector2 posFinalCuerda = GameObject.FindGameObjectWithTag("cuerda").GetComponent<Cuerda>().PosFinal;
        transform.position = posFinalCuerda;
    }

    
}
