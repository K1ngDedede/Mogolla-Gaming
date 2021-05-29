using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
	
	public GameObject objectToDisable;
	public GameObject objectToDisable2;
	public GameObject objectToDisable3;
	public GameObject objectToDisable4;
	public GameObject objectToDisable5;
	public GameObject objectToDisable6;
	public static bool disabled = true;
	
	

    // Start is called before the first frame update
    void Start()
    {
		objectToDisable6.SetActive(false);
		if(TejoUtils.counter == 5){
			objectToDisable.SetActive(true);
			objectToDisable2.SetActive(true);
			objectToDisable3.SetActive(true);
			objectToDisable4.SetActive(true);
			objectToDisable5.SetActive(true);
		}
		if(TejoUtils.counter == 3){
			objectToDisable.SetActive(false);
			objectToDisable2.SetActive(false);
			objectToDisable3.SetActive(true);
			objectToDisable4.SetActive(true);
			objectToDisable5.SetActive(true);
		}
		if(TejoUtils.counter == 2){
			objectToDisable.SetActive(true);
			objectToDisable2.SetActive(false);
			objectToDisable3.SetActive(false);
			objectToDisable4.SetActive(false);
			objectToDisable5.SetActive(true);
		}
    }

    // Update is called once per frame
    void Update()
    {
		if(!disabled){
			objectToDisable6.SetActive(true);
		}
		else{
			objectToDisable6.SetActive(false);
		}

    }
}
