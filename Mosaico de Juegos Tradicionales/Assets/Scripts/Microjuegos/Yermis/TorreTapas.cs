using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TorreTapas : MonoBehaviour
{
    Vector3 posInicial = new Vector3(0,0.5f,0);
    float incremento = 0.44f;
    int numeroTapas = 10;
    string ubicacionTapa = "Microjuegos/Yermis/Prefabs/";
    bool bolaDisparada = false;

    bool torreTumbada = false;

    float duracion = 4;

    BackwardsTimer timer;

    public bool BolaDisparada
    {
        set { bolaDisparada = value; }
    }

    public bool TorreTumbada
    {
        set { torreTumbada = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<BackwardsTimer>();
        timer.Duration = duracion;
        HUD.ActualizarTiempo(duracion);
        timer.Run();


        GameObject tapa;
        for(int i =0; i < numeroTapas; i++)
        {
            tapa = Resources.Load<GameObject>(ubicacionTapa + "Tapa");
            tapa.transform.position = posInicial;
            tapa.GetComponent<SpriteRenderer>().sortingOrder = i;
            Instantiate(tapa);
            
            posInicial.y += incremento;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Running)
        {
            HUD.ActualizarTiempo(timer.SecondsRemaining);
        }
        if (timer.Finished)
        {
            timer.Stop();
            if (!bolaDisparada)
            {
                bolaDisparada = true;
                GameObject.FindGameObjectWithTag("flechaRotatoria").GetComponent<FlechaYermis>().DispararBola();
            }
            Invoke("EvaluarSiguienteFase", 2);
        }
    }

    private void EvaluarSiguienteFase()
    {
        if (torreTumbada)
        {
            SceneManager.LoadScene("yermisAtaque");
        }
        else
        {
            SceneManager.LoadScene("yermisDefensa");
        }
    }

}
