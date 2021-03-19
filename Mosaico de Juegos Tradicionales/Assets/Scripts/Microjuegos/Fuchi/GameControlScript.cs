using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
	
	public GameObject objectToDisable;
	public GameObject objectToDisable2;
	
	public static bool disabled = true;
	public static bool disabled2 = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if(!disabled2){
			objectToDisable2.SetActive(true);

		}
		else{
			objectToDisable2.SetActive(false);
		}
		
        if(disabled){
			objectToDisable.SetActive(false);

		}
		else{
			objectToDisable.SetActive(true);

		}

    }
}
