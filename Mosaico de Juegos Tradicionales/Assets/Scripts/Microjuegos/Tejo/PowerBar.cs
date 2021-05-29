using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public GameObject powerBarGO;
    public Image PowerBarMask;
    public float barChangeSpeed = 1;
    float maxPowerBarValue = 100;
	Fase fase = TejoUtils.Fase;
    float currentPowerBarValue;
    bool powerIsIncreasing;
    bool PowerBarON;
	public static BackwardsTimer n;
	public static bool gana;
	public static int countT = 0;
	public Text temptimer;
    float angulo;
    int counter = 0;
    TejoMov tejo;
    FlechaMov flecha;

    // Start is called before the first frame update
    void Start()
    {
		countT = 0;
		gana = false;
        currentPowerBarValue = 0;
        powerIsIncreasing = true;
        PowerBarON = true;
		n = gameObject.AddComponent<BackwardsTimer>();
		n.Duration = TejoUtils.startingTime;
		GameObject tt = GameObject.FindGameObjectWithTag("RelojitoTimer");
        temptimer = tt.GetComponent<Text>();
		n.Run();
    }

    public void setFlecha(GameObject go)
    {
        flecha = go.GetComponent<FlechaMov>();
    }

    void Update()
    {
		GameObject tt = GameObject.FindGameObjectWithTag("RelojitoTimer");
		temptimer = tt.GetComponent<Text>();
		temptimer.text = n.SecondsRemaining.ToString()+"s";
        if (PowerBarON && counter > 20 && Input.GetMouseButtonDown(0))
        {
            PowerBarON = false;
            tejo.Throw(angulo, currentPowerBarValue);
            StopCoroutine(UpdatePowerBar());
            StartCoroutine(TurnOffPowerBar());
        }
		
    }

    public void startPowerBar(float angle, GameObject o)
    {
        tejo = o.GetComponent<TejoMov>();
        tejo.setBar(transform.gameObject);
        angulo = angle;
        currentPowerBarValue = 0;
        powerIsIncreasing = true;
        PowerBarON = true;
        StartCoroutine(UpdatePowerBar());
    }

    IEnumerator UpdatePowerBar()
    {
        while (PowerBarON)
        {
            if (!powerIsIncreasing)
            {
                currentPowerBarValue -= barChangeSpeed;
                if (currentPowerBarValue <= 0)
                {
                    powerIsIncreasing = true;
                }
            }
            if (powerIsIncreasing)
            {
                currentPowerBarValue += barChangeSpeed;
                if (currentPowerBarValue >= maxPowerBarValue)
                {
                    powerIsIncreasing = false;
                }
            }
            
            float fill = currentPowerBarValue / maxPowerBarValue;
            PowerBarMask.fillAmount = fill;
            yield return new WaitForSeconds(0.02f);
            counter++;
        }
        yield return null;
    }
    IEnumerator TurnOffPowerBar()
    {
        yield return new WaitForSeconds(0.5f);
        //powerBarGO.SetActive(false);
    }

    public void Res()
    {
        flecha.Res();
    }
	private void Ganar()
    {
        switch (fase)
        {
            case Fase.FASE1:
				ManejadorFase1.RegistrarVictoria();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
				Cursor.visible = true;
                break;
            case Fase.FASE2:
			Cursor.visible = true;
                //llamar manejador de fase 2
                break;
            case Fase.FASE3:
			Cursor.visible = true;
                //llamar manejador de fase 3
                break;
        }
    }
	
	private void Perder()
    {
        //timerJuego.Stop();
        switch (fase)
        {
            case Fase.FASE1:
				ManejadorFase1.RegistrarPerdidaMicrojuego("Tejo");
				ManejadorFase1.PerderVida();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
				Cursor.visible = true;
                break;
            case Fase.FASE2:
                //llamar manejador de fase 2
				Cursor.visible = true;
                break;
            case Fase.FASE3:
                //llamar manejador de fase 3
				Cursor.visible = true;
                break;
        }
	}
}