﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrollerHorizontal2 : MonoBehaviour
{
    private float scrollSpeed = 0.05f;
    private Renderer renderer;
    private Vector2 savedOffset;
    float offX = 0;

    void Start()
    {
        Texture2D sprite;
        if (!ConfigFase3Utils.JugandoEnContinuacion)
        {
            sprite = Resources.Load<Texture2D>("Cutscene/Fase3/fAsul");
        }
        else
        {
            sprite = Resources.Load<Texture2D>("Cutscene/Fase3/fMorado");
        }
        sprite.wrapMode = TextureWrapMode.Repeat;
        renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = sprite;
    }

    void Update()
    {
        //float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        //Vector2 offset = new Vector2(x, 0);
        //renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        offX += Time.deltaTime * scrollSpeed;
        renderer.sharedMaterial.mainTextureOffset = new Vector2(offX, 0);
    }
}
