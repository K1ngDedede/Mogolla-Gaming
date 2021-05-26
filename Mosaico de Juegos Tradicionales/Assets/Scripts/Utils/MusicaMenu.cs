using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaMenu : MonoBehaviour
{
    string ubicacionPrefabs = "Utils/Prefabs/";
    GameObject musica;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("musicaMenu") == null)
        {
            musica = Resources.Load<GameObject>(ubicacionPrefabs + "MusicaMenu");
            Instantiate(musica);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("musicaMenu"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestruirMusicaMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("musicaMenu"));
    }
}
