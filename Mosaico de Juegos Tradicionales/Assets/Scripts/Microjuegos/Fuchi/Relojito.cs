using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Relojito : MonoBehaviour
{
    
	public static float currentTime = FuchiUtils.currentTime;
	float startingTime = FuchiUtils.startingTime;
	[SerializeField] Text RelojitoTimer;
    static Text textoTiempo;


    // Start is called before the first frame update
    void Start()
    {

        currentTime = startingTime;
    }
	
	void Update()
	{
		currentTime -= 1*Time.deltaTime;
		RelojitoTimer.text = (currentTime.ToString("0")+ "s");
		if(currentTime <= 0)
		{
			currentTime = 0;
		}
	}

}
