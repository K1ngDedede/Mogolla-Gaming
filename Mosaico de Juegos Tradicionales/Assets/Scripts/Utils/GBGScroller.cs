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
    void Start()
    {
        bgm = gameObject.GetComponent<Renderer>().material;
        bgm.mainTexture = vic;
        bgm.mainTextureScale = new Vector2(2f, 2f);
        vic.wrapMode = TextureWrapMode.Repeat;
        offX = 0;
        offY = 0;
    }

    
    void Update()
    {
        offX += Time.deltaTime * sX;
        offY += Time.deltaTime * sY;
        bgm.mainTextureOffset = new Vector2(offX, offY);
    }
    
}
