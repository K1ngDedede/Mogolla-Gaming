using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRana : MonoBehaviour
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
        vic = (Texture2D)Resources.Load("Microjuegos/Coca/f2");
        bgm.mainTexture = vic;
        bgm.mainTextureScale = new Vector2(5f, 5f);
        vic.wrapMode = TextureWrapMode.Repeat;
        //def.wrapMode = TextureWrapMode.Repeat;
        state = true;
        offX = 0;
        offY = 0;
        sX = 0.1f;
        sY = 0.15f;
    }

    void Update()
    {
        if (state)
        {
            offX += Time.deltaTime * sX;
            offY += Time.deltaTime * sY;
            bgm.mainTextureOffset = new Vector2(offX, offY);
        }
    }


}
