using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HManager
{
    private static bool cogote = false;
    private static float offX;
    private static float offY;

    public static float OffX
    {
        get => offX;
        set => offX = value;
    }

    public static float OffY
    {
        get => offY;
        set => offY = value;
    }

    public static bool Cogote
    {
        get => cogote;
        set => cogote = value;
    }

    public static void pMusic()
    {
        AudioSource hog = GameObject.FindGameObjectWithTag("musicaMenu").GetComponent<AudioSource>();
        int pranked = hog.timeSamples;
        hog.clip = Resources.Load<AudioClip>("Utils/Misc/cogote");
        hog.timeSamples = pranked;
        hog.Play();
    }
}
