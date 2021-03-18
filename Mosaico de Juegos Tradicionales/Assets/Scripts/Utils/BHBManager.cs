using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BHBManager : MonoBehaviour
{
    
    void Start()
    {
        Image sapo = gameObject.GetComponent<Image>();
        sapo.alphaHitTestMinimumThreshold = 0.5f;
    }
    
}
