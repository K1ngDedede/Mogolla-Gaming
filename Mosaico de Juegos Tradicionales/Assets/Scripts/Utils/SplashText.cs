using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SplashText : MonoBehaviour
{
    List<string> prompts;
    TextAsset promptsTextAsset;
    private int state;
    
    private float scale;

    [SerializeField]
    public float sp;

    [SerializeField]
    public int iterator;

    static System.Random rng = new System.Random();

    private int iteration;
    void Start()
    {
        state = 1;
        scale = 1;
        prompts = new List<string>();
        LeerArchivo();
        AsignarPrompt();
    }

    
    void Update()
    {
        scale += Time.deltaTime * sp * state;
        iteration++;
        if (iteration % iterator == 0) state*=-1;
        gameObject.transform.localScale = new Vector3(scale,scale, 1);
    }

    void LeerArchivo()
    {
        promptsTextAsset = Resources.Load<TextAsset>("Data/prompts");
        string[] datos = promptsTextAsset.text.Split('\n');
        foreach(string dato in datos)
        {
            prompts.Add(dato);
        }
    }

    private static int GenerarNumeroAleatorio(int max)
    {
        return rng.Next(max + 1);
    }

    void AsignarPrompt()
    {
        GetComponent<Text>().text = prompts[GenerarNumeroAleatorio(prompts.Count - 1)];
    }
}
