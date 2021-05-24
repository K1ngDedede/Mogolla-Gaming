using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BotonSaltarFase2 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Image imageComponent = gameObject.GetComponent<Image>();
        if (ConfigUtils.Fase == 2 && ConfigUtils.PrimerIntentoFase)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
