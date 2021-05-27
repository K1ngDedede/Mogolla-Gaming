using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GBGScroller : MonoBehaviour
{
    //clase Generic Background Scroller
    private Material bgm;
    
    [SerializeField]
    private Texture2D vic;
    
    private float offX;

    private float offY;

    [SerializeField]
    private float sX;

    [SerializeField]
    private float sY;

    private const string cogote = "cogote";
    private int state;
    void Start()
    {
        
        bgm = gameObject.GetComponent<Renderer>().material;
        bgm.mainTexture = vic;
        bgm.mainTextureScale = new Vector2(2f, 2f);
        vic.wrapMode = TextureWrapMode.Repeat;
        offX = HManager.OffX;
        offY = HManager.OffY;
        state = 0;
    }

    private void Awake()
    {
        if (HManager.Cogote)
        {
            vic = Resources.Load<Texture2D>("Utils/Sprites/cogote");
        }
    }

    private void OnDestroy()
    {
        HManager.OffX = offX;
        HManager.OffY = offY;
    }

    void Update()
    {
        offX += Time.deltaTime * sX;
        offY += Time.deltaTime * sY;
        bgm.mainTextureOffset = new Vector2(offX, offY);
        if (Input.anyKeyDown && state<=cogote.Length)
        {
            if (Input.GetKeyDown(cogote[state].ToString()))
            {
                state++;
            }
            else
            {
                state = 0;
            }
            if (state == cogote.Length)
            {
                HManager.Cogote = true;
                state++;
                vic = Resources.Load<Texture2D>("Utils/Sprites/cogote");
                vic.wrapMode = TextureWrapMode.Repeat;
                bgm.mainTexture = vic;
                HManager.pMusic();
            }
        }
        
    }
    
}
