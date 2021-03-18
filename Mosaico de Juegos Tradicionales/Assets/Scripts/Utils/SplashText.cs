using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashText : MonoBehaviour
{

    private int state;

    private float scale;

    [SerializeField]
    public float sp;

    [SerializeField]
    public int iterator;

    private int iteration;
    void Start()
    {
        state = 1;
        scale = 1;
    }

    
    void Update()
    {
        scale += Time.deltaTime * sp * state;
        iteration++;
        if (iteration % iterator == 0) state*=-1;
        gameObject.transform.localScale = new Vector3(scale,scale, 1);
    }
}
