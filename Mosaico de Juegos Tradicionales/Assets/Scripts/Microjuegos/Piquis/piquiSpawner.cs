using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class piquiSpawner : MonoBehaviour
{
    protected const string sPath = "Microjuegos/Piquis/Sprites/";
    protected bool state;
    protected biquis sapo;
    protected float sMod = piquisUtils.SMod;
    void Start()
    {
        string sapasso = "p"+ Random.Range(1, 7);
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sPath + sapasso);
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        transform.localScale = transform.localScale * sMod;
        sapo = GameObject.FindGameObjectWithTag("lmao").GetComponent<biquis>();
        state = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!state)
        {
            state = true;
            sapo.colDetection();
        }
    }
}
