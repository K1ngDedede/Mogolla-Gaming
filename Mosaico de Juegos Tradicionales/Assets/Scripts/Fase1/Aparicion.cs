using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparicion : MonoBehaviour
{
    [SerializeField]
    float tiempo;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("Visibilizar", tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Visibilizar()
    {
        gameObject.SetActive(true);
    }
}
