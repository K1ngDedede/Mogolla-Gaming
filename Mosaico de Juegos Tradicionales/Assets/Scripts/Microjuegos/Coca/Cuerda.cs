using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Codigo adaptado de https://www.youtube.com/watch?v=FcnvwtyxLds

public class Cuerda : MonoBehaviour
{
    LineRenderer lineRenderer;
    List<SegmentoCuerda> segmentosCuerda = new List<SegmentoCuerda>();
    float longSegmentoCuerda = 0.3f;
    int numeroSegmentos = 20;
    float anchoLinea = 0.1f;
    Vector2 posFinal;
    bool siguiendoTapa = false;
    bool siguiendoMouse = true;
    Vector2 gravedad = new Vector2(0f, -1f);

    public bool SiguiendoMouse
    {
        set { siguiendoMouse = value; }
    }

    public bool SiguiendoTapa
    {
        set { siguiendoTapa = value; }
    }

    public Vector2 PosFinal
    {
        get { return posFinal; }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.lineRenderer = GetComponent<LineRenderer>();
        Vector3 posInicialCuerda = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        for(int i = 0; i < numeroSegmentos; i++)
        {
            segmentosCuerda.Add(new SegmentoCuerda(posInicialCuerda));
            posInicialCuerda.y -= longSegmentoCuerda;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DibujarCuerda();
    }

    private void FixedUpdate()
    {
        Simular();
    }

    private void Simular()
    {
        
        for(int i = 1; i < numeroSegmentos; i++)
        {
            SegmentoCuerda primerSegmento = segmentosCuerda[i];
            Vector2 velocidad = primerSegmento.posActual - primerSegmento.posAnterior;
            primerSegmento.posAnterior = primerSegmento.posActual;
            primerSegmento.posActual += velocidad;
            primerSegmento.posActual += gravedad * Time.fixedDeltaTime;
            segmentosCuerda[i] = primerSegmento;
        }

        for(int i = 0; i< 20; i++)
        {
            AplicarRestricciones();
        }
    }

    private void AplicarRestricciones()
    {
        SegmentoCuerda primerSegmento = segmentosCuerda[0];
        if (siguiendoMouse)
        {
            primerSegmento.posActual = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            primerSegmento.posActual = GameObject.FindGameObjectWithTag("palo").transform.position;
        }
        segmentosCuerda[0] = primerSegmento;

        if (siguiendoTapa)
        {
            SegmentoCuerda ultimoSegmento = segmentosCuerda[numeroSegmentos - 1];
            ultimoSegmento.posActual = GameObject.FindGameObjectWithTag("tapa").transform.position;
            posFinal = ultimoSegmento.posActual;
            segmentosCuerda[numeroSegmentos - 1] = ultimoSegmento;
        }

        for(int i = 0; i < numeroSegmentos-1; i++)
        {
            SegmentoCuerda primerSeg = segmentosCuerda[i];
            SegmentoCuerda segundoSeg = segmentosCuerda[i + 1];
            float distancia = (primerSeg.posActual - segundoSeg.posActual).magnitude;
            float error = Mathf.Abs(distancia - longSegmentoCuerda);
            Vector2 cambioDireccion = Vector2.zero;
            if (distancia > longSegmentoCuerda)
            {
                cambioDireccion = (primerSeg.posActual - segundoSeg.posActual).normalized;
            }
            else if (distancia < longSegmentoCuerda)
            {
                cambioDireccion = (segundoSeg.posActual - primerSeg.posActual).normalized;
            }
            Vector2 cambio = cambioDireccion * error;
            if (i != 0)
            {
                primerSeg.posActual -= cambio * 0.5f;
                segmentosCuerda[i] = primerSeg;
                segundoSeg.posActual += cambio * 0.5f;
                segmentosCuerda[i + 1] = segundoSeg;
            }
            else
            {
                segundoSeg.posActual += cambio;
                segmentosCuerda[i + 1] = segundoSeg;
            }


        }
        posFinal = segmentosCuerda[numeroSegmentos - 1].posActual;
    }

    private void DibujarCuerda()
    {
        float anchoLinea = this.anchoLinea;
        lineRenderer.startWidth = anchoLinea;
        lineRenderer.endWidth = anchoLinea;

        Vector3[] posicionesCuerda = new Vector3[numeroSegmentos];
        for(int i = 0; i< numeroSegmentos; i++)
        {
            posicionesCuerda[i] = segmentosCuerda[i].posActual;
        }
        lineRenderer.positionCount = posicionesCuerda.Length;
        lineRenderer.SetPositions(posicionesCuerda);
    }

    public struct SegmentoCuerda
    {
        public Vector2 posActual;
        public Vector2 posAnterior;
        public SegmentoCuerda(Vector2 pos)
        {
            this.posActual = pos;
            this.posAnterior = pos;
        }
    }

}
