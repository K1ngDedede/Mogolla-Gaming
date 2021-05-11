using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaFase2 : MonoBehaviour
{
    string prefabLocation = "Microjuegos/Jackses/Prefabs/";
    int explosiones = 10;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < explosiones; i++)
        {
            Invoke("SpawnPolvora", i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPolvora()
    {
        GameObject polvora = Resources.Load<GameObject>(prefabLocation + "Polvora");
        float posX = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
        float posY = Random.Range(ScreenUtils.ScreenBottom, ScreenUtils.ScreenTop);
        polvora.transform.position = new Vector3(posX, posY, 0);
        Instantiate(polvora);
    }

    public void Seguir()
    {
        SceneManager.LoadScene("menu1");
    }


}
