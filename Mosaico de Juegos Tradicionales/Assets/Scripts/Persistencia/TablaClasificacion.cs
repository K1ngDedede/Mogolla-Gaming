using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.SceneManagement;
using System.Linq;

public class TablaClasificacion : MonoBehaviour
{
    Text gamerTagText;
    Text headerPosText;
    Text headerNombreText;
    Text headerPuntajeText;
    Text rankText;
    Text feedbackRegistroText;
    string gamerTag;
    string endpoint = "https://proyecto-de-grado-7e7d3-default-rtdb.firebaseio.com/";
    int puntaje;
    List<MiembroRanking> miembrosRankingList;
    MiembrosRanking miembrosRanking;
    MiembroRanking jugadorActual;
    int rankJugadorActual;
    float aumentoY = -30;
    int UILayer = 5;

    // Start is called before the first frame update
    void Start()
    {
        gamerTagText = GameObject.FindGameObjectWithTag("textoJuego").GetComponent<Text>();
        puntaje = ConfigFase3Utils.Puntaje;
        headerPosText = GameObject.FindGameObjectWithTag("posicion").GetComponent<Text>();
        headerNombreText = GameObject.FindGameObjectWithTag("nombre").GetComponent<Text>();
        headerPuntajeText = GameObject.FindGameObjectWithTag("puntaje").GetComponent<Text>();
        rankText = GameObject.FindGameObjectWithTag("rank").GetComponent<Text>();
        feedbackRegistroText = GameObject.FindGameObjectWithTag("feedbackRegistro").GetComponent<Text>();
        headerPosText.text = "";
        headerNombreText.text = "";
        headerPuntajeText.text = "";
        rankText.text = "";
        feedbackRegistroText.text = "";
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
        if(gamerTag.Any(c => char.IsDigit(c)))
        {
            feedbackRegistroText.text = "Su nombre no puede contener números.";
        }
        else if (FiltroNombres.Obscenidades.Contains(gamerTag.ToLower()) || gamerTag.Any(c => FiltroNombres.CaracteresProhibidos.Contains(c)))
        {
            feedbackRegistroText.text = "Nombre inválido.";
        }
        else
        {
            feedbackRegistroText.text = "";
            miembrosRankingList = new List<MiembroRanking>();
            RestClient.Get(endpoint + "tabla_clasificaciones/miembrosRanking.json").Then(response => {
                string texto = response.Text;
                texto = "{\"miembrosRanking\":" + texto + "}";
                //print(texto);
                MiembrosRanking miembrosRankingJson = JsonUtility.FromJson<MiembrosRanking>(texto);
                foreach (MiembroRanking miembroRanking in miembrosRankingJson.miembrosRanking)
                {
                    miembrosRankingList.Add(miembroRanking);
                }
                jugadorActual = new MiembroRanking { gamerTag = this.gamerTag, puntaje = ConfigFase3Utils.Puntaje };
                miembrosRankingList.Add(jugadorActual);
                miembrosRankingList.Sort(OrdenarPorPuntaje);
                rankJugadorActual = miembrosRankingList.IndexOf(jugadorActual) + 1;
                miembrosRanking = new MiembrosRanking { miembrosRanking = miembrosRankingList.ToArray() };
                ActualizarRanking();
            });
        }
        
    }

    private void ActualizarRanking()
    {
        RestClient.Put(endpoint + "tabla_clasificaciones.json", miembrosRanking).Then(response =>
        {
            DeshabilitarRegistro();
        });
    }

    public void VolverAMenu()
    {
        SceneManager.LoadScene("menu0");
    }

    private void DeshabilitarRegistro()
    {
        GameObject[] registros = GameObject.FindGameObjectsWithTag("registro");
        foreach(GameObject registro in registros)
        {
            registro.SetActive(false);
        }
        GameObject.FindGameObjectWithTag("feedbackRegistro").SetActive(false);
        ArmarTabla();
    }

    private int OrdenarPorPuntaje(MiembroRanking m1, MiembroRanking m2)
    {
        return -m1.puntaje.CompareTo(m2.puntaje);
    }

    private void ArmarTabla()
    {
        headerPosText.text = "Posicion";
        headerNombreText.text = "Nombre";
        headerPuntajeText.text = "Puntaje";
        rankText.text = "Su posicion en la tabla: " + rankJugadorActual+", con "+jugadorActual.puntaje + " puntos.";
        GameObject col1;
        GameObject col2;
        GameObject col3;
        Text textCol1;
        Text textCol2;
        Text textCol3;
        MiembroRanking miembro;
        GameObject headerPos = GameObject.FindGameObjectWithTag("posicion");
        GameObject headerNombre = GameObject.FindGameObjectWithTag("nombre");
        GameObject headerPuntaje = GameObject.FindGameObjectWithTag("puntaje");
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        for (int i = 0; i < 10; i++)
        {
            if (miembrosRanking.miembrosRanking.Length >= i + 1)
            {
                miembro = miembrosRanking.miembrosRanking[i];
                col1 = new GameObject("Col1", typeof(RectTransform));
                col1.layer = 5;
                textCol1 = col1.AddComponent<Text>();
                textCol1.alignment = TextAnchor.MiddleCenter;
                textCol1.text = ""+(i + 1);
                textCol1.fontSize = 30;
                textCol1.font = ArialFont;
                textCol1.color = Color.black;
                col1.transform.SetParent(headerPos.transform);
                col1.transform.localPosition = new Vector3(0,  aumentoY*(i+1), 0);


                col2 = new GameObject("Col2", typeof(RectTransform));
                col2.layer = UILayer;
                textCol2 = col2.AddComponent<Text>();
                textCol2.alignment = TextAnchor.MiddleCenter;
                textCol2.text = miembro.gamerTag.ToUpper();
                textCol2.fontSize = 30;
                textCol2.font = ArialFont;
                textCol2.color = Color.black;
                col2.transform.SetParent(headerNombre.transform);
                col2.transform.localPosition = new Vector3(0, aumentoY*(i+1), 0);



                col3 = new GameObject("Col3", typeof(RectTransform));
                col3.layer = UILayer;
                textCol3 = col3.AddComponent<Text>();
                textCol3.alignment = TextAnchor.MiddleCenter;
                textCol3.text = miembro.puntaje+"";
                textCol3.fontSize = 30;
                textCol3.font = ArialFont;
                textCol3.color = Color.black;
                col3.transform.SetParent(headerPuntaje.transform);
                col3.transform.localPosition = new Vector3(0, aumentoY * (i + 1), 0);

            }
        }
        
    }
}
