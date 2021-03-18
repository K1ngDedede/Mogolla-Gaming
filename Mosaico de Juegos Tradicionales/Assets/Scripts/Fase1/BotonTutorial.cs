using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonTutorial : MonoBehaviour
{
    [SerializeField]
    float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        if (ConfigUtils.Fase == 1)
        {
            gameObject.SetActive(false);
            Invoke("Visibilizar", tiempo);
        }
        
    }

    public void Visibilizar()
    {
        gameObject.SetActive(true);
    }
}
