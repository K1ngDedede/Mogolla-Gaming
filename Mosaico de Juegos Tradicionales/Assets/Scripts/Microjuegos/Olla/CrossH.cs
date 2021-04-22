using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossH : MonoBehaviour
{
    protected Vector3 posMouse;

    void Update()
    {
        posMouse = Input.mousePosition;
        posMouse.z = -Camera.main.transform.position.z;
        posMouse = Camera.main.ScreenToWorldPoint(posMouse);
        gameObject.transform.position = posMouse; 
    }
}
