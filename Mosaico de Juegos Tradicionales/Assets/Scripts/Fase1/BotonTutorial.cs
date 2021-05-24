using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BotonTutorial : MonoBehaviour
{
    [SerializeField]
    float tiempo;


    string ubicacion = "Misc/UI/";
    // Start is called before the first frame update
    void Start()
    {
        Image imageComponent = gameObject.GetComponent<Image>();
        if (ConfigUtils.Fase == 1 && ConfigUtils.PrimerIntentoFase)
        {
            gameObject.SetActive(false);
            Invoke("Visibilizar", tiempo);
            imageComponent.sprite = Resources.Load<Sprite>(ubicacion + "seguir");
        }
        else
        {
            imageComponent.sprite = Resources.Load<Sprite>(ubicacion + "saltar");
        }
        
    }

    public void Visibilizar()
    {
        gameObject.SetActive(true);
    }
}
