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
    protected AudioSource bicPotas;
    protected Rigidbody2D pBody;

    void Awake()
    {
        sapo = GameObject.FindGameObjectWithTag("lmao").GetComponent<biquis>();
        bicPotas = gameObject.GetComponent<AudioSource>();
        pBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        string sapasso = "p"+ Random.Range(1, 7);
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sPath + sapasso);
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        transform.localScale = transform.localScale * sMod;
        bicPotas.pitch *= 1.5f / sMod;
        state = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print(pBody.velocity.magnitude);
        bicPotas.volume *= pBody.velocity.magnitude/3;
        bicPotas.Play();
        if (sapo == null)
        {
            sapo = GameObject.FindGameObjectWithTag("lmao").GetComponent<biquis>();
        }
        if (!state && sapo!=null)
        {
            state = true;
            sapo.colDetection();
        } 
    }
}
