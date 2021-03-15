using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sHand : MonoBehaviour
{
    
    private static GameObject fh;

    private static SpriteRenderer fhRender;

    private static Sprite[] fhSprites;

    private IEnumerator cogotinho;

    private void Start()
    {
        fh = new GameObject("manos");
        fh.AddComponent(typeof(SpriteRenderer));
        fhRender = fh.GetComponent<SpriteRenderer>();
        fhSprites = new Sprite[2];
        fhSprites[0] = Resources.Load<Sprite>("Microjuegos/Trompo/Sprites/mano1");
        fhSprites[1] = Resources.Load<Sprite>("Microjuegos/Trompo/Sprites/mano2");
        fhRender.sprite = fhSprites[0];   
        fh.transform.position = new Vector3(4,1,0);
        fh.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        cogotinho = Handanim();
        StartCoroutine(cogotinho);
    }

    public void switchHand()
    {
        fh.transform.position = new Vector3(-fh.transform.position.x,1,0);
    }

    public void halt()
    {
        StopCoroutine(cogotinho);
    }
    
    IEnumerator Handanim() {
        int sI = 0;
        while (true) {
            fhRender.sprite = fhSprites[sI%2];
            sI++;
            yield return new WaitForSeconds(0.5f); 
        }
    }
}
