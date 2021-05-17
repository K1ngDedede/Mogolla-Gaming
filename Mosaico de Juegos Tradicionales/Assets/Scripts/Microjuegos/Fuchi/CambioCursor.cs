﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CambioCursor : MonoBehaviour
{
	private SpriteRenderer rend;
	public Sprite handCursor;
	public Sprite normalCursor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
		rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuPausa.pausado)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPos;

            if (Input.GetMouseButtonDown(0))
            {
                rend.sprite = handCursor;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                rend.sprite = normalCursor;
            }
        }
    }
}
