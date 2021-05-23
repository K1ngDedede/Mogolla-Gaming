using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class TablaClasificacion : MonoBehaviour
{
    Text gamerTagText;
    string gamerTag;
    string endpoint = "https://proyecto-de-grado-7e7d3-default-rtdb.firebaseio.com/";
    int puntaje;
    List<MiembroRanking> miembrosRankingList;
    MiembrosRanking miembrosRanking;

    // Start is called before the first frame update
    void Start()
    {
        gamerTagText = GameObject.FindGameObjectWithTag("textoJuego").GetComponent<Text>();
        puntaje = ConfigFase3Utils.Puntaje;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegistrarPuntaje()
    {
        gamerTag = gamerTagText.text;
        if(gamerTag == "")
        {
            gamerTag = "Anon";
        }
        miembrosRankingList = new List<MiembroRanking>();
        RestClient.Get(endpoint + "tabla_clasificaciones/miembrosRanking.json").Then(response => {
            string texto = response.Text;
            texto = "{\"miembrosRanking\":" + texto+"}";
            //print(texto);
            MiembrosRanking miembrosRankingJson = JsonUtility.FromJson<MiembrosRanking>(texto);
            foreach (MiembroRanking miembroRanking in miembrosRankingJson.miembrosRanking)
            {
                miembrosRankingList.Add(miembroRanking);
            }
            miembrosRankingList.Add(new MiembroRanking { gamerTag = this.gamerTag, puntaje = ConfigFase3Utils.Puntaje });
            miembrosRanking = new MiembrosRanking { miembrosRanking = miembrosRankingList.ToArray() };
            ActualizarRanking();
        });
    }

    private void ActualizarRanking()
    {
        RestClient.Put(endpoint + "tabla_clasificaciones.json", miembrosRanking).Then(response =>
        {
        });
    }
}
