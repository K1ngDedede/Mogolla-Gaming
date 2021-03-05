using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaTutorial : MonoBehaviour
{
    GameObject bola;
    float offsetX = 1.5f, offsetY = -1.5f;

    // Start is called before the first frame update
    void Start()
    {
        bola = GameObject.FindGameObjectWithTag("Bola");
        Vector3 posBola = bola.transform.position;
        gameObject.transform.position = new Vector3(posBola.x + offsetX, posBola.y + offsetY, posBola.z);

    }

    // Update is called once per frame
    void Update()
    {
        bola = GameObject.FindGameObjectWithTag("Bola");
        Vector3 posBola = bola.transform.position;
        gameObject.transform.position = new Vector3(posBola.x + offsetX, posBola.y + offsetY, posBola.z);
    }
}
