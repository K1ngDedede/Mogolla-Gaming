using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    private Material bgm;

    private Texture2D vic;

    private Texture2D def;

    private bool state;

    private float offX;

    private float offY;

    private float sX;

    private float sY;
    void Start()
    {
        bgm = gameObject.GetComponent<Renderer>().material;
        vic = (Texture2D) Resources.Load ("Microjuegos/Trompo/Sprites/f1");
        def = (Texture2D) Resources.Load ("Microjuegos/Trompo/Sprites/ff");
        bgm.mainTexture = vic;
        bgm.mainTextureScale = new Vector2(5f, 5f);
        vic.wrapMode = TextureWrapMode.Repeat;
        def.wrapMode = TextureWrapMode.Repeat;
        state = false;
        state = true;
        offX = 0;
        offY = 0;
        sX = 0.1f;
        sY = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (state)
        {
            offX += Time.deltaTime * sX;
            offY += Time.deltaTime * sY;
            bgm.mainTextureOffset = new Vector2(offX, offY);
        }
    }

    public void halt()
    {
        state = !state;
        bgm.mainTexture = def;
    }
    
    
}
