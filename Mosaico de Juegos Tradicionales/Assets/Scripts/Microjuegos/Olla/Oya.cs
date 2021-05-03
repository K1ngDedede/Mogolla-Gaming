using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Oya : MonoBehaviour
{
    protected const string sPath = "Microjuegos/Olla/Sprites/";
    protected const string pPath = "Microjuegos/Olla/Prefabs/";
    protected int jogadores = OllaUtils.Jogadores;
    protected float speedMax = OllaUtils.SpeedMax;
    protected float speedBol = OllaUtils.SpeedBol;
    protected Fase fase = OllaUtils._Fase;
    protected GameObject[] fellas;
    protected GameObject bol;
    protected GameObject hand;
    protected Sprite[] mongos;
    protected Sprite[] ollaS;
    protected Sprite[] handS;
    protected Vector3 target;
    protected int[] ballpath;
    protected int state;
    protected Vector3 sFlag;
    protected Vector3 targetS;
    protected Vector3 defS;
    protected Vector3 heightS;
    protected float dist;
    protected Vector3 far;
	protected float locTime;

    void Start()
    {
        fellas = new GameObject[jogadores];
        GameObject playerigga = Resources.Load<GameObject>(pPath+"mongo");
        hand = Instantiate(Resources.Load<GameObject>(pPath+"daHand"));
        bol = Instantiate(Resources.Load<GameObject>(pPath+"ball"));
        int mod = Random.Range(0, jogadores);
        for (int sapo = 0; sapo < jogadores; sapo++)
        {
            fellas[sapo] = Instantiate(playerigga); 
            if (sapo > 0)
            {
                fellas[sapo].GetComponent<SpriteRenderer>().color = Color.gray;
            }
            float alpha = (float) ((sapo+mod) * 2 * Math.PI / jogadores);
            float xalpha = (float) Math.Sin(alpha)*4f;
            float yalpha = (float) Math.Cos(alpha)*4f;
            fellas[sapo].transform.position = new Vector3(-xalpha,yalpha, 0);
            fellas[sapo].transform.eulerAngles = new Vector3(0,0,((sapo+mod)*360/jogadores));
        }
        ballpath = new int[3];
        ballpath[0] = Random.Range(1, jogadores);
        ballpath[1] = Random.Range(2, jogadores - 1);
        while (ballpath[1] == ballpath[0])
        {
            ballpath[1] = Random.Range(2, jogadores - 1);
        }
        ballpath[2] = 0;
        bol.transform.position = fellas[ballpath[0]].transform.position;

        state = -1;
        sFlag = Vector3.zero;
        far = Vector3.zero;
        targetS = new Vector3(0.2f, 0.2f, 1);
        defS = new Vector3(0.5f, 0.5f, 1);
        heightS = new Vector3(0.8f, 0.8f, 1);
        
        mongos = new Sprite[5];
        mongos[0] = Resources.Load<Sprite>(sPath + "mongo");
        mongos[1] = Resources.Load<Sprite>(sPath + "mongoS");
        mongos[2] = Resources.Load<Sprite>(sPath + "mongoC1");
        mongos[3] = Resources.Load<Sprite>(sPath + "mongoC2");
        mongos[4] = Resources.Load<Sprite>(sPath + "mongoPo");
        ollaS = new Sprite[2];
        ollaS[0] = Resources.Load<Sprite>(sPath + "olla1");
        ollaS[1] = Resources.Load<Sprite>(sPath + "olla2");
        handS = new Sprite[2];
        handS[0] = Resources.Load<Sprite>(sPath + "daHand");
        handS[1] = Resources.Load<Sprite>(sPath + "daHandS");

        StartCoroutine("grovel");
		locTime = Time.time;
    }

    
    void Update()
    {
        //c espera un tole al principio
        if (state == -1 && Time.time > locTime+2)
        {
            state = 0;
            dist = Vector3.Distance(fellas[ballpath[state]].transform.position,
                fellas[ballpath[state + 1]].transform.position);
        }
        //la mano sigue al cursor dentro de un radio
        boundHand();
        //el mongo del centro se mueve
        if (state < 6)
        {
            if (Vector3.Distance(transform.position, target) != 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speedMax * Time.deltaTime);
            }
            else
            {
                target = Random.insideUnitCircle*2.5f;
                transform.right = target-transform.position;
                transform.Rotate(Vector3.forward, 90);
            }
        }
        //la bola se mueve
        if (state < 3 && state >=0)
        {
            if (Vector3.Distance(bol.transform.position, fellas[ballpath[state]].transform.position) != 0)
            {
                bol.transform.position = Vector3.MoveTowards(bol.transform.position, fellas[ballpath[state]].transform.position,
                    speedBol * Time.deltaTime);
                //la bola hace como si subiese o bajase
                bol.transform.localScale = Vector3.Slerp(bol.transform.localScale, Vector3.Distance(bol.transform.position, fellas[ballpath[state]].transform.position) >= dist / 2 ? heightS : defS, Time.deltaTime);
            }
            else
            {
                if (state != 2)
                {
                    StartCoroutine("mongoReset");
                }
                state++;
                if (state < 2)
                {
                    dist = Vector3.Distance(fellas[ballpath[state]].transform.position,
                        fellas[ballpath[state + 1]].transform.position);
                }
            }
            //el sape
            if (Input.GetMouseButtonDown(0) && Vector3.Distance(bol.transform.position, hand.transform.position)<0.7f && !MenuPausa.pausado)
            {
                sFlag = Input.mousePosition;
                sFlag.z = -Camera.main.transform.position.z;
                sFlag = Camera.main.ScreenToWorldPoint(sFlag);
                StartCoroutine("sapeEnumerator");
                state = 5;
            }
        }else if (state == 3)
        {
            far = new Vector3(Random.Range(10,20),Random.Range(10,20),0);
            returnDef();
            state = 6;
        }else if (state == 5)
        {
            if (Vector3.Distance(bol.transform.position, sFlag) != 0)
            {
                bol.transform.position = Vector3.MoveTowards(bol.transform.position, sFlag,
                    speedBol*2.5f* Time.deltaTime);
                bol.transform.localScale = Vector3.Lerp(bol.transform.localScale, targetS, Time.deltaTime);
            }
            else if(Vector3.Distance(sFlag, transform.position)<1.2f)
            {
               //TODO reemplazar condición por hitbox, eventualmente 
               returnVic();
               state++;
            }
            else
            {
                returnDef();
                state=7;
            }
        }else if (state == 6)
        {
            bol.transform.position = Vector3.MoveTowards(bol.transform.position, far,
                speedBol*1.5f * Time.deltaTime);
            //bol.transform.localScale = Vector3.Lerp(bol.transform.localScale, targetS, Time.deltaTime);
        }
        
    }

    private void boundHand()
    {
        Vector3 p = Input.mousePosition;
        p.z = -Camera.main.transform.position.z;
        p = Camera.main.ScreenToWorldPoint(p);
        hand.transform.position = p;
        float r = 0.8f;
        float d = Vector3.Distance(fellas[0].transform.position, hand.transform.position);
        if (d > r)
        {
            Vector3 chain = hand.transform.position - fellas[0].transform.position;
            chain *= r / d;
            hand.transform.position = fellas[0].transform.position + chain;

        }
        hand.transform.right = transform.position - hand.transform.position;
        hand.transform.Rotate(Vector3.forward, -90);
    }

    private IEnumerator mongoReset()
    {
        SpriteRenderer temp = fellas[ballpath[state]].GetComponent<SpriteRenderer>();
        temp.sprite = mongos[1];
        yield return new WaitForSeconds(0.5f);
        temp.sprite = mongos[0];
    }

    private IEnumerator mongoClap(SpriteRenderer amogus)
    {
        yield return new WaitForSeconds(Random.Range(0f, 0.2f));
        while (true)
        {
            amogus.sprite = mongos[2];
            yield return new WaitForSeconds(0.2f);
            amogus.sprite = mongos[3];
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator sapeEnumerator()
    {
        SpriteRenderer temp = hand.GetComponent<SpriteRenderer>();
        temp.sprite = handS[1];
        yield return new WaitForSeconds(0.1f);
        temp.sprite = handS[0];
    }

    private IEnumerator grovel()
    {
        SpriteRenderer temp = gameObject.GetComponent<SpriteRenderer>();
        while (state < 6)
        {
            temp.sprite = ollaS[1];
            yield return new WaitForSeconds(0.25f);
            temp.sprite = ollaS[0];
            yield return new WaitForSeconds(0.25f);
        }
    }
    
    private void FadeMusica(float duracionFade)
    {
        GameObject musica = GameObject.FindGameObjectWithTag("musica");
        StartCoroutine(FadeAudioSource.StartFade(musica.GetComponent<AudioSource>(), duracionFade, 0));
    }

    private void FadeVolumen(float duracionFade)
    {
        GameObject musica = GameObject.FindGameObjectWithTag("musica");
        StartCoroutine(FadeAudioSource.StartFadeVolumen(musica.GetComponent<AudioSource>(), duracionFade, 0));
    }

    private void returnVic()
    {
        print("victoria");
        for (int sapasso = 1; sapasso < fellas.Length; sapasso++)
        {
            StartCoroutine("mongoClap", fellas[sapasso].GetComponent<SpriteRenderer>());
        }
        FadeVolumen(3);
        Invoke("returnVic2",3);
    }

    private void returnVic2()
    {
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.RegistrarVictoria();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                break;
            case Fase.FASE2:
                //llamar manejador de fase 2
                break;
            case Fase.FASE3:
                //llamar manejador de fase 3
                break;
            case Fase.MODOLIBRE:
                ManejadorModoLibre.Ganar();
                break;
        }
    }
    
    private void returnDef()
    {
        print("derrota");
        for (int sapasso = 1; sapasso < fellas.Length; sapasso++)
        {
            fellas[sapasso].GetComponent<SpriteRenderer>().sprite = mongos[4];
            fellas[sapasso].transform.right = fellas[0].transform.position - fellas[sapasso].transform.position;
            fellas[sapasso].transform.Rotate(Vector3.forward, -270);
        }
        fellas[0].GetComponent<SpriteRenderer>().color = new Color(237/255f,137/255f, 166/255f);
        hand.GetComponent<SpriteRenderer>().color = new Color(237/255f,137/255f, 166/255f);
        FadeMusica(2);
        Invoke("returnDef2", 3);
    }

    private void returnDef2()
    {
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.RegistrarPerdidaMicrojuego("Olla");
                ManejadorFase1.PerderVida();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                break;
            case Fase.FASE2:
                //llamar manejador de fase 2
                break;
            case Fase.FASE3:
                //llamar manejador de fase 3
                break;
            case Fase.MODOLIBRE:
                ManejadorModoLibre.Perder();
                break;
        }
    }
}
